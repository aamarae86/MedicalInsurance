using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AidModule._ScCampains.Procs;
using ERP._System.__HR._HrPersonsAdditionHd.Proc;
using ERP._System.__HR._HrPersonsDeduction;
using ERP._System.__HR._HrPersonsDeduction.Dto;
using ERP._System.__Warehouses._IvItems;
using ERP._System.__Warehouses.__IvInventorySetting.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP._System.__Warehouses._IvInventorySetting;
using ERP.Authorization.Users;
using ERP._System.__Warehouses._IvUserWarehousesPrivileges;
using ERP._System.__SalesModule._IvSaleHd.Dto;
using ERP.Core.Helpers.Extensions;
using ERP._System.__Warehouses._IvWarehouseItems;
using ERP._System.__SalesModule._IvSaleHd.Proc;
using ERP._System.__SalesModule._IvSaleHd.ProcDto;
using ERP._System._ArCustomers;
using ERP._System.__Warehouses._IvItems.Dto;
using ERP._System.__SalesModule._IvReturnSaleHd;
using System.Collections;
using Newtonsoft.Json;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System.Runtime.Serialization;
using ERP._System._ApBanks;
using Abp.UI;

namespace ERP._System.__SalesModule._IvSaleHd
{
    [AbpAuthorize]
    public class IvSaleHdAppService : AsyncCrudAppService<IvSaleHd, IvSaleHdDto, long, IvSaleHdPagedDto, IvSaleHdCreateDto, IvSaleHdEditDto>, IIvSaleHdAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IRepository<IvSaleTr, long> _repoIvSaleTr;
        private readonly IRepository<IvWarehouseItems, long> _repoIvWarehouseItems;
        private readonly IRepository<IvItems, long> _repoIvitems;
        private readonly IRepository<IvInventorySettingPriceList, long> _repoIvInventorySettingPriceList;
        private readonly IIvSaleHdPostRepository _ivSaleHdPostRepository;
        private readonly IGetSalesScreenDataRepository _repoSalesScreen;
        private readonly IRepository<ArCustomers, long> _repoArCustomers;
        private readonly IRepository<IvReturnSaleTr, long> _repoIvReturnSaleTr;
        private readonly IRepository<ApBanks, long> _apBanksRepo;

        public IvSaleHdAppService(IRepository<IvSaleHd, long> repository,
             IRepository<IvSaleTr, long> repoIvSaleTr,
             IRepository<IvWarehouseItems, long> repoIvWarehouseItems,
             IRepository<IvItems, long> repoIvitems,
             IRepository<IvInventorySettingPriceList, long> repoIvInventorySettingPriceList,
             IGetCounterRepository getCounterRepository,
             IIvSaleHdPostRepository ivSaleHdPostRepository,
             IRepository<ArCustomers, long> repoArCustomers,
             IRepository<IvReturnSaleTr, long> repoIvReturnSaleTr,
             IRepository<ApBanks, long> apBanks,
             IGetSalesScreenDataRepository repoSalesScreen) : base(repository)
        {

            _ivSaleHdPostRepository = ivSaleHdPostRepository;
            _repoProcCounter = getCounterRepository;
            _repoIvSaleTr = repoIvSaleTr;
            _repoIvWarehouseItems = repoIvWarehouseItems;
            _repoIvitems = repoIvitems;
            _repoIvInventorySettingPriceList = repoIvInventorySettingPriceList;
            _repoSalesScreen = repoSalesScreen;
            _repoArCustomers = repoArCustomers;
            _repoIvReturnSaleTr = repoIvReturnSaleTr;
            _apBanksRepo = apBanks;


            CreatePermissionName = PermissionNames.Pages_IvSaleHd_Insert;
            UpdatePermissionName = PermissionNames.Pages_IvSaleHd_Update;
            DeletePermissionName = PermissionNames.Pages_IvSaleHd_Delete;
            GetAllPermissionName = PermissionNames.Pages_IvSaleHd;
        }

        public override async Task<PagedResultDto<IvSaleHdDto>> GetAll(IvSaleHdPagedDto input)
        {

            var iqueryable = Repository.GetAllIncluding(x => x.IvWarehouses, x => x.ArCustomers, x => x.FndLookupStatusLkp, x => x.IvSaleTrs);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.IvSaleNumber))
                iqueryable = iqueryable.Where(z => z.IvSaleNumber.Contains(input.Params.IvSaleNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.IvSaleDate))
            {
                DateTime dt = (DateTime)DateTimeController.ConvertToDateTime(input.Params.IvSaleDate);
                iqueryable = iqueryable.Where(z => z.IvSaleDate == dt);
            }
            if (input.Params != null && input.Params.IvWarehouseId != 0)
                iqueryable = iqueryable.Where(z => z.IvWarehouseId == input.Params.IvWarehouseId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.LpoNo))
                iqueryable = iqueryable.Where(z => z.LpoNo.Contains(input.Params.LpoNo));

            if (input.Params != null && input.Params.ArCustomerId != 0)
                iqueryable = iqueryable.Where(z => z.ArCustomerId == input.Params.ArCustomerId);


            if (input.Params != null && input.Params.StatusLkpId != 0)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);


            var count = await iqueryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            iqueryable = iqueryable.DynamicOrderBy(listOrder);
            iqueryable = iqueryable.Skip(input.SkipCount);
            var data = await iqueryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<IvSaleHdDto>());
            foreach (var item in data2)
            {
                //(Qty*unitprice)+taxamount
                item.Amount = item.IvSaleTrDetails.Sum(x => (x.Qty * x.UnitPrice + x.TaxAmount))- (item.Discount==null?0:item.Discount) + (item.DeliveryCharges == null ? 0 : item.DeliveryCharges);

            }
            var PagedResultDto = new PagedResultDto<IvSaleHdDto>()
            {
                Items = data2 as IReadOnlyList<IvSaleHdDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async override Task<IvSaleHdDto> Create(IvSaleHdCreateDto input)
        {
            try
            {
                CheckCreatePermission();                
                input.IvSaleNumber = await GetSaleNumber();                
                var IvSaleHdList = ObjectMapper.Map<IvSaleHd>(input);
                var insertedItem = await Repository.InsertAndGetIdAsync(IvSaleHdList);
                if (input.IvSaleTrdetails != null && input.IvSaleTrdetails.Count > 0)
                    foreach (var item in input.IvSaleTrdetails)
                        await InsertSalesListData(item, IvSaleHdList.Id);

                

                return new IvSaleHdDto { 
                Id= insertedItem

                };

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private async Task InsertSalesListData(IvSaleTrDto IvSaleTrListDto, long masterId)
        {
            try
            {
                IvSaleTrListDto.IvSaleHdId = masterId;
                var itemDetails = await _repoIvitems.FirstOrDefaultAsync(x => x.Id == IvSaleTrListDto.IvItemId);
                if (itemDetails.AvgCost == null || itemDetails.AvgCost == 0)
                {
                    throw new UserFriendlyException(itemDetails.ItemName+" "+ "AvgCost is missing");
                    //throw new UserFriendlyException("Please log in before attemping to change password.");
                }
                IvSaleTrListDto.AvgCost = itemDetails.AvgCost;
                var IvSaleList = ObjectMapper.Map<IvSaleTr>(IvSaleTrListDto);               
                _ = await _repoIvSaleTr.InsertAsync(IvSaleList);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async override Task<IvSaleHdDto> Update(IvSaleHdEditDto input)
        {
            try
            {
                
                CheckUpdatePermission();

                var current = await Repository.GetAsync(input.Id);

                if (input.IvSaleDate == null)
                    input.IvSaleDate = current.IvSaleDate.ToString(Formatters.DateTimeFormat);

                ObjectMapper.Map(input, current);

                _ = await Repository.UpdateAsync(current);

                try {
                    await CRUD_IvSaletr(input.IvSaleTrDetails, input.Id);
                } catch (Exception ex) {
                    string msg = ex.Message;
                } 


                return new IvSaleHdDto { };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public async Task<bool> UpdateCreditRef(dynamic input)
        {
            try
            {
                var id = Convert.ToInt16(input.Id);
                CheckUpdatePermission();
                var current = await Repository.GetAsync(id);
               current.CreditCardRef = Convert.ToString(input.CreditCardRef);
                _ = await Repository.UpdateAsync(current);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task<bool> UpdateSalesMan(dynamic input)
        {
            try
            {
                var id = Convert.ToInt16(input.Id);
                if (input.FndSalesMenId == null)
                    return false;
                CheckUpdatePermission();
                var current = await Repository.GetAsync(id);
                current.FndSalesMenId = Convert.ToInt32(input.FndSalesMenId);
                _ = await Repository.UpdateAsync(current);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        //public async Task<PostOutput> PostHrSales(PostDto postDto)
        //{

        //    long saleid = Repository.GetAll().OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();
        //    var saleHd = new PostDto()
        //    {
        //        Id = saleid,
        //        UserId = AbpSession.UserId ?? 0,
        //        Lang = _app.Reqlanguage
        //    };
        //    var result = await _ivSaleHdPostRepository.Execute(saleHd, "IvSaleHdPost");

        //    return result.FirstOrDefault();
        //}
        public async Task<PostOutput> PostHrSales(PostDto postDto)
        {
            var saleHd = new PostDto()
            {
                Id = postDto.Id,
                UserId = AbpSession.UserId ?? 0,
                Lang = _app.Reqlanguage
            };
            var result = await _ivSaleHdPostRepository.Execute(saleHd, "IvSaleHdPost");

            return result.FirstOrDefault();
        }
        private async Task CRUD_IvSaletr(ICollection<IvSaleTrDto> IvSaleTrsListDtos, long masterId)
        {
            try
            {
                if (IvSaleTrsListDtos != null && IvSaleTrsListDtos.Count > 0)
                {
                    foreach (var item in IvSaleTrsListDtos)
                    {
                        if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                        {
                            var IvSaleTrList = await _repoIvSaleTr.GetAsync((long)item.Id);

                            item.IvSaleHdId = masterId;

                            ObjectMapper.Map(item, IvSaleTrList);

                            //if (IvSaleTrList != null)
                            //    IvSaleTrList.IvItems = null;

                            _ = await _repoIvSaleTr.UpdateAsync(IvSaleTrList);
                        }
                        else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                        {
                            await InsertSalesListData(item, masterId);
                        }
                        else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                        {
                            await _repoIvSaleTr.DeleteAsync((long)item.Id);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<IvSaleTrDto>> GetAllSaleslistDetails(EntityDto<long> input)
        {
            var listData = await _repoIvSaleTr.GetAllIncluding(x => x.IvItems, x => x.IvSaleHd,x=>x.FndTaxType,x=>x.IvItems.IvUnits)
                               .Where(d => d.IvSaleHdId == input.Id).ToListAsync();

            var listDto = ObjectMapper.Map<List<IvSaleTrDto>>(listData);
            foreach (var item in listDto)
            {
                item.ItemName = item.IvItems.ItemName;
                //(Qty*unitprice)+taxamount
                item.totbeforetax = item.Qty * item.UnitPrice;
                item.Totalamount = item.totbeforetax + item.TaxAmount;
                item.FndTaxtypeId = item.FndTaxtypeId;
                item.FndTaxType= item.FndTaxType;
                item.Avilablequantity= item.Avilablequantity;
                item.UnitPrice= item.UnitPrice;
                item.UnitName = item.IvItems.IvUnits.UnitName;
                item.ItemNumber = item.IvItems.ItemNumber;
                item.Discount = item.Discount;
            }

            return listDto;

        }
        //public async Task<IvSaleHdDto> GetDetailAsync(EntityDto<long> input)
        //   => ObjectMapper.Map<IvSaleHdDto>(await Repository.GetAllIncluding(x => x.IvWarehouses, x => x.FndSalesMen, x => x.Currency, x => x.ArCustomers, x => x.FndLookupStatusLkp, x => x.IvPriceListHd,x=>x.FndLookupPaymentMethodLkp,x=>x.IvSaleTrs) .Where(z => z.Id == input.Id).FirstOrDefaultAsync());

        public async Task<IvSaleHdDto> GetDetailAsync(EntityDto<long> input)
        {
            var listData = await Repository.GetAllIncluding(x => x.IvWarehouses, x => x.FndSalesMen, x => x.Currency, x => x.ArCustomers, x => x.FndLookupStatusLkp, x => x.IvPriceListHd, x => x.FndLookupPaymentMethodLkp, x => x.IvSaleTrs,x=>x.ApBankAccounts).Where(z => z.Id == input.Id).FirstOrDefaultAsync();
            var mappedObj=ObjectMapper.Map<IvSaleHdDto>(listData); 
            mappedObj.IvSaleTrList= ObjectMapper.Map<List<IvSaleTrDto>>(listData.IvSaleTrs) ;
            foreach (var item in mappedObj.IvSaleTrList)
            {
                var itemDetails = _repoIvitems.FirstOrDefault(x => x.Id == item.IvItemId);
                item.ItemName = itemDetails.ItemName;
                item.ItemNumber = itemDetails.ItemNumber;
            }
            //get bank name by bankaccess id
            if (listData.ApBankAccounts != null)
            {
                var bank =await _apBanksRepo.FirstOrDefaultAsync(x => x.Id == listData.ApBankAccounts.BankId);
                mappedObj.BankName = bank.BankNameEn;
            }
            
            return mappedObj;

        }
        public async Task<IvSaleHdDto> GetSalesInQueryDetailAsync(EntityDto<long> input)
        {
            var obj = ObjectMapper.Map<IvSaleHdDto>(await Repository.GetAllIncluding(x => x.IvWarehouses, x => x.FndSalesMen, x => x.Currency, x => x.ArCustomers, x => x.FndLookupStatusLkp, x => x.IvPriceListHd, x => x.FndLookupPaymentMethodLkp, x => x.ApBankAccounts).Where(z => z.Id == input.Id).FirstOrDefaultAsync());

            if (obj.ApBankAccounts != null)
            {
                var bank = await _apBanksRepo.FirstOrDefaultAsync(x => x.Id == obj.ApBankAccounts.BankId);
                obj.BankName = bank.BankNameEn;
            }
            return obj;
        }

        private async Task<string> GetSaleNumber()
        {
            var counterInput = new GetCounterInputDto { CounterName = "IvSaleHd", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? string.Empty;
        }

        public async Task<List<SalesScreenDataOutput>> GetSalesScreenData(IdLangInputDto input)
        {
            var result = await _repoSalesScreen.Execute(input, "GetSalesScreenData");

            return result.ToList();
        }



        public async Task<Select2PagedResult> GetSalesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
           

            List<IvSaleHd> data = null;
            if (string.IsNullOrEmpty(searchTerm))
            {
                data = await Repository.GetAllIncluding(z => z.IvWarehouses, x => x.Currency, x => x.ArCustomers, x => x.FndSalesMen, x => x.FndLookupStatusLkp)
                  .Where(z => string.IsNullOrEmpty(searchTerm))
                  .ToListAsync();
            }
            else
            {
                data = await Repository.GetAllIncluding(z => z.IvWarehouses, x => x.Currency, x => x.ArCustomers, x => x.FndSalesMen, x => x.FndLookupStatusLkp)
                 .Where(z => z.IvSaleNumber.Contains(searchTerm))
                 .ToListAsync();
            }


            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.IvSaleNumber : z.IvSaleNumber }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<IvSaleHdDto> GetSaleData(long Id)
        {
            var result = await Repository.GetAllIncluding(x => x.IvWarehouses, x => x.FndSalesMen, x => x.Currency, x => x.ArCustomers, x => x.FndLookupStatusLkp, x => x.IvPriceListHd,x=>x.IvSaleTrs)
                                              .Where(z => z.Id == Id).FirstOrDefaultAsync();

            var listDto = ObjectMapper.Map<IvSaleHdDto>(result);

            return listDto;
        }





        public async Task<Select2PagedResult> GetIvSaleHd_IvSaleTr_NumSelect2(long ArCustomerId, int pageSize, int pageNumber, string lang)
        {

            var data = await Repository.GetAll().Include(x => x.IvSaleTrs)
                                                .Where(z => z.StatusLkpId == 31614 && z.ArCustomerId == ArCustomerId)
                                                .GroupBy(x => new { x.IvSaleNumber, x.IvSaleDate, x.Id })
                                    .Select(x => new { Id = x.Key.Id, IvSaleNumber = x.Key.IvSaleNumber, Date = x.Key.IvSaleDate.Date.ToString(), Amount = x.Sum(s => s.IvSaleTrs.Sum(m => m.UnitPrice * m.Qty + m.TaxAmount)) }) //, 
                                    .ToListAsync();

            var data2 = await Repository.GetAll().Include(x => x.IvSaleTrs)
                                                .Where(z => z.StatusLkpId == 31614 && z.ArCustomerId == ArCustomerId)
                                                .GroupBy(x => new { x.IvSaleNumber, x.IvSaleDate, x.Id })
                                    .Select(x => new { Id = x.Key.Id, IvSaleNumber = x.Key.IvSaleNumber, Date = x.Key.IvSaleDate.Date.ToString(), Amount = x.Select(v => v.IvSaleTrs.Sum(m => m.UnitPrice * m.Qty + m.TaxAmount)) }) //, 
                                    .ToListAsync();


            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.IvSaleNumber, altText = JsonConvert.SerializeObject(z) }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetIvitemBySaleSelect2(string searchTerm, int pageSize, int pageNumber, string lang, long IvSaleHdId)
        {
            var saledata = _repoIvSaleTr.GetAll().Where(x=>x.IvSaleHdId==IvSaleHdId);
            var IvSaleTrlist = new List<IvSaleTr>();
            foreach (var sale in saledata)
            {
                var returnsaledata = _repoIvReturnSaleTr.GetAll().Where(x=>x.IvSaleTrId==sale.Id);
                var GetSum = returnsaledata.Sum(x => x.RQty);
                if(sale.Qty> GetSum)
                {
                    IvSaleTrlist.Add(sale);

                }
            }
            var data = (from s in IvSaleTrlist
                        join n in _repoIvitems.GetAll()
                        on s.IvItemId equals n.Id
                        select new IvItemsDto
                        {
                            Id = n.Id,
                            ItemName = n.ItemName,
                            ItemNumber = n.ItemNumber
                        }).ToList();





            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.ItemName : z.ItemName, altText = z.ItemNumber.ToString() }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };



            return select2pagedResult;


            //return null;
        }


        #region Sales Inquery
        public async Task<PagedResultDto<IvSaleHdDto>> GetAllInQuerySales(IvSaleHdPagedDto input)
        {

            var iqueryable = Repository.GetAllIncluding(x => x.IvWarehouses, x => x.ArCustomers, x => x.FndLookupStatusLkp, x => x.IvSaleTrs);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.IvSaleNumber))
                iqueryable = iqueryable.Where(z => z.IvSaleNumber.Contains(input.Params.IvSaleNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.IvSaleDate))
            {
                DateTime dt = (DateTime)DateTimeController.ConvertToDateTime(input.Params.IvSaleDate);
                iqueryable = iqueryable.Where(z => z.IvSaleDate == dt);
            }
            if (input.Params != null && input.Params.IvWarehouseId != 0)
                iqueryable = iqueryable.Where(z => z.IvWarehouseId == input.Params.IvWarehouseId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.LpoNo))
                iqueryable = iqueryable.Where(z => z.LpoNo.Contains(input.Params.LpoNo));

            if (input.Params != null && input.Params.ArCustomerId != 0)
                iqueryable = iqueryable.Where(z => z.ArCustomerId == input.Params.ArCustomerId);


            if (input.Params != null && input.Params.StatusLkpId != 0)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpId);

              if (input.Params != null && input.Params.FndSalesMenId != null && input.Params.FndSalesMenId != 0 )
                iqueryable = iqueryable.Where(z => z.FndSalesMenId == input.Params.FndSalesMenId);

            var count = await iqueryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            iqueryable = iqueryable.DynamicOrderBy(listOrder);
            iqueryable = iqueryable.Skip(input.SkipCount);
            var data = await iqueryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<IvSaleHdDto>());
            foreach (var item in data2)
            {
                //(Qty*unitprice)+taxamount
                //item.Amount = item.IvSaleTrDetails.Sum(x => (x.Qty * x.UnitPrice + x.TaxAmount - x.Discount));

                //decimal? totalQty = 0;//item.IvSaleTrDetails.Sum(x => x.Qty);
                // item.IvSaleTrDetails.Sum(x => x.Qty * (x.UnitPrice - item.Discount));
                
                decimal? totalCost = 0; //item.IvSaleTrDetails.Sum(x => x.LastCost);
                decimal? totalAmount = 0;
                
                foreach (var elem in item.IvSaleTrDetails)
                {
                    elem.Discount = elem.Discount==null?0 : elem.Discount;
                    //totalQty +=elem.Qty;
                    totalAmount += elem.Qty * elem.UnitPrice + elem.TaxAmount;//- elem.Discount;
                    //var itemDetail = _repoIvitems.FirstOrDefault(x => x.Id == elem.IvItemId);
                    totalCost += (elem.AvgCost == null ? 0 : elem.AvgCost * elem.Qty);  //(itemDetail.AvgCost==null?0: itemDetail.AvgCost)  * elem.Qty;
                   
                }
                item.Discount = item.Discount == null ? 0 : item.Discount;
                item.Amount= totalAmount- item.Discount+(item.DeliveryCharges==null?0:item.DeliveryCharges);
                item.TotalCost = totalCost;
               
            }
            var PagedResultDto = new PagedResultDto<IvSaleHdDto>()
            {
                Items = data2 as IReadOnlyList<IvSaleHdDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }
        public async Task<List<IvSaleTrDto>> GetAllSalesInQuerylistDetails(EntityDto<long> input)
        {
            var listData = await _repoIvSaleTr.GetAllIncluding(x => x.IvItems, x => x.IvSaleHd,x=>x.FndTaxType)
                               .Where(d => d.IvSaleHdId == input.Id).ToListAsync();


            var listDto = ObjectMapper.Map<List<IvSaleTrDto>>(listData);
            foreach (var item in listDto)
            {

                item.Discount= item.Discount==null? 0 : item.Discount;

                item.ItemName = item.IvItems.ItemName;
                //(Qty*unitprice)+taxamount
                item.totbeforetax = (item.Qty * (item.UnitPrice))-item.Discount;
                item.Totalamount = item.Qty * (item.UnitPrice) + item.TaxAmount-item.Discount;
                item.TotalCost = item.TrCost * item.Qty;
                item.LastCost = _repoIvitems.FirstOrDefault(x => x.Id == item.IvItemId).LastCost;
                item.AvgCost = item.AvgCost==null?0:item.AvgCost *item.Qty;
               
                item.profitamount = item.totbeforetax - (item.AvgCost);
                item.profit = (item.profitamount / item.totbeforetax) * 100;

                item.ItemNumber= item.IvItems.ItemNumber;
            }

            return listDto;

        }
        #endregion



        public async Task<string> GetPaymentMethodBySaleId(EntityDto<long> input)
        {
            var item = await Repository.GetAllIncluding( x => x.FndLookupPaymentMethodLkp).Where(z => z.Id == input.Id).FirstOrDefaultAsync();
           
            return item.FndLookupPaymentMethodLkp.NameEn;

        }






    }
}
