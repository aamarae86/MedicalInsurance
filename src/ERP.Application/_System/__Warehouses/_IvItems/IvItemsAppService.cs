using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ERP._System.__Warehouses._IvItems.Dto;
using ERP._System.__Warehouses._IvPriceListHd;
using ERP._System.__Warehouses._IvWarehouseItems;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._FndTaxType;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvItems
{
    public class IvItemsAppService : AsyncCrudAppService<IvItems, IvItemsDto, long, IvItemsPagedDto, IvItemsCreateDto, IvItemsEditDto>,
        IIvItemsAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IIvItemsManager _ivItemsManager;
        private readonly IRepository<IvWarehouseItems, long> _repoIvWarehouseItems;
        private readonly IRepository<IvPriceListTr, long> _repoIvPriceListTr;
        private readonly IRepository<FndTaxType, long> _repoFndTaxType;

        public IvItemsAppService(IRepository<IvItems, long> repository,
            IRepository<IvWarehouseItems, long> repoIvWarehouseItems,
            IRepository<IvPriceListTr, long> repoIvPriceListTr,
            IRepository<FndTaxType, long> repoFndTaxType,
            IGetCounterRepository repoProcCounter, IIvItemsManager ivItemsManager
            ) : base(repository)
        {
            _repoProcCounter = repoProcCounter;
            _ivItemsManager = ivItemsManager;
            _repoIvWarehouseItems = repoIvWarehouseItems;
            _repoIvPriceListTr = repoIvPriceListTr;
            _repoFndTaxType = repoFndTaxType;


            CreatePermissionName = PermissionNames.Pages_IvItems_Insert;
            UpdatePermissionName = PermissionNames.Pages_IvItems_Update;
            DeletePermissionName = PermissionNames.Pages_IvItems_Delete;
            GetAllPermissionName = PermissionNames.Pages_IvItems;
        }

        protected override IQueryable<IvItems> CreateFilteredQuery(IvItemsPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(z => z.IvItemsTypesConfigure, z => z.IvUnits,z=>z.FndTaxType);

            if (input.Params != null && input.Params.IvItemsTypesConfigureId != null && input.Params.IvItemsTypesConfigureId != 0)
                iqueryable = iqueryable.Where(z => z.IvItemsTypesConfigureId == input.Params.IvItemsTypesConfigureId);

            if (input.Params != null && input.Params.IvUnitId != null && input.Params.IvUnitId != 0)
                iqueryable = iqueryable.Where(z => z.IvUnitId == input.Params.IvUnitId);

            if (input.Params != null && input.Params.IvItemName != null && input.Params.IvItemName != "")
                iqueryable = iqueryable.Where(z => z.ItemName.Contains(input.Params.IvItemName));

            if (input.Params != null && input.Params.IvItemNumber != null && input.Params.IvItemNumber != "")
                iqueryable = iqueryable.Where(z => z.ItemNumber == input.Params.IvItemNumber);

            if (input.Params != null && input.Params.IvItemBarcode != null && input.Params.IvItemBarcode != "")
                iqueryable = iqueryable.Where(z => z.ItemBarcode.Contains(input.Params.IvItemBarcode));

            return iqueryable;
        }

        public async Task<IvItemsDto> GetDetailAsync(EntityDto<long> input)
           => ObjectMapper.Map<IvItemsDto>(await Repository.GetAllIncluding(z => z.IvItemsTypesConfigure, z => z.IvUnits, z => z.FndLookupValues,z=>z.FndTaxType).Where(z => z.Id == input.Id).FirstOrDefaultAsync());

        public async override Task<IvItemsDto> Create(IvItemsCreateDto input)
        {
            CheckCreatePermission();

            var counterInput = new GetCounterInputDto { CounterName = "IvItems", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            input.ItemNumber = result?.FirstOrDefault()?.OutputStr ?? string.Empty;

            if (input.IsItemObsolete == true) input.ObsoleteDate = DateTime.Now;

            return await base.Create(input);
        }

        public async override Task<IvItemsDto> Update(IvItemsEditDto input)
        {
            CheckUpdatePermission();

            var current = await Repository.GetAsync(input.Id);

            if (input.IsItemObsolete == true) input.ObsoleteDate = DateTime.Now;
            else input.ObsoleteDate = null;

            ObjectMapper.Map(input, current);

            _ = await Repository.UpdateAsync(current);

            return new IvItemsDto { };
        }


        public async Task<Select2PagedResult> GetIvitemBywarehouseIdAndPricelistidSelect2(string searchTerm, int pageSize, int pageNumber, string lang, long IvWarehouseId, long IvPriceListHdId)
        {
            var _ivwarehous = _repoIvWarehouseItems.GetAll();
            var _ivpriceListTr = _repoIvPriceListTr.GetAll();
            //var itemIds = _repoIvWarehouseItems.GetAll()
            //                      .Join(inner: _ivpriceListTr,
            //                        outerKeySelector: f => f.IvItemId,
            //                        innerKeySelector: s => s.IvItemId,
            //                        (f,s)=> new {f,s })
            //                      .GroupBy(c=>c.f.IvItemId.Value)
            //                      .Select(c=>c.Key)
            //                      .ToList();
            //var items = Repository.GetAllList(x => itemIds.Contains(x.Id));
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var data = _repoIvWarehouseItems.GetAll()
                               .Join(inner: _ivpriceListTr,
                                 outerKeySelector: f => f.IvItemId,
                                 innerKeySelector: s => s.IvItemId,
                                 (f, s) => new { f, s })
                               .Where(s => s.s.IvPriceListHdId == IvPriceListHdId && s.f.IvWarehouseId == IvWarehouseId)
                               .Join(inner: Repository.GetAll().Where(x=>x.ItemName.Contains(searchTerm)),
                                     outerKeySelector: f => f.f.IvItemId,
                                     innerKeySelector: item => item.Id,
                                     resultSelector: (f, item) => new
                                     {
                                         id = item.Id,
                                         ItemName = item.ItemName,
                                         item.AvgCost,
                                         item.TaxPercentageLkpId,
                                         item.ItemNumber,
                                         price = f
                                      .s.Price,
                                         CurrentOnHand = f.f.CurrentOnHand
                                     }).Distinct()
                               .ToList();

                var result = data.OrderBy(q => q.id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.id, text = lang == "ar-EG" ? z.ItemName : z.ItemName, altText = z.ItemNumber.ToString() }).ToList();

                var select2pagedResult = new Select2PagedResult
                {
                    Total = data.Count(),
                    Results = result
                };



                return select2pagedResult;
            }
            else {
                var data = _repoIvWarehouseItems.GetAll()
                                   .Join(inner: _ivpriceListTr,
                                     outerKeySelector: f => f.IvItemId,
                                     innerKeySelector: s => s.IvItemId,
                                     (f, s) => new { f, s })
                                   .Where(s => s.s.IvPriceListHdId == IvPriceListHdId && s.f.IvWarehouseId == IvWarehouseId)
                                   .Join(inner: Repository.GetAll(),
                                         outerKeySelector: f => f.f.IvItemId,
                                         innerKeySelector: item => item.Id,
                                         resultSelector: (f, item) => new
                                         {
                                             id = item.Id,
                                             ItemName = item.ItemName,
                                             item.AvgCost,
                                             item.TaxPercentageLkpId,
                                             item.ItemNumber,
                                             price = f
                                          .s.Price,
                                             CurrentOnHand = f.f.CurrentOnHand
                                         }).Distinct()
                                   .ToList();

                var result = data.OrderBy(q => q.id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.id, text = lang == "ar-EG" ? z.ItemName : z.ItemName, altText = z.ItemNumber.ToString() }).ToList();

                var select2pagedResult = new Select2PagedResult
                {
                    Total = data.Count(),
                    Results = result
                };



                return select2pagedResult;

            }
         

         


            //return null;
        }



        public async Task<Select2PagedResult> GetIvitemNumersBywarehouseIdAndPricelistidSelect2(string searchTerm, int pageSize, int pageNumber, string lang, long IvWarehouseId, long IvPriceListHdId)
        {
            var _ivwarehous = _repoIvWarehouseItems.GetAll();
            var _ivpriceListTr = _repoIvPriceListTr.GetAll();
            
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var data = _repoIvWarehouseItems.GetAll()
                               .Join(inner: _ivpriceListTr,
                                 outerKeySelector: f => f.IvItemId,
                                 innerKeySelector: s => s.IvItemId,
                                 (f, s) => new { f, s })
                               .Where(s => s.s.IvPriceListHdId == IvPriceListHdId && s.f.IvWarehouseId == IvWarehouseId)
                               .Join(inner: Repository.GetAll().Where(x => x.ItemName.Contains(searchTerm)),
                                     outerKeySelector: f => f.f.IvItemId,
                                     innerKeySelector: item => item.Id,
                                     resultSelector: (f, item) => new
                                     {
                                         id = item.Id,
                                         ItemName = item.ItemName,
                                         item.AvgCost,
                                         item.TaxPercentageLkpId,
                                         item.ItemNumber,
                                         price = f
                                      .s.Price,
                                         CurrentOnHand = f.f.CurrentOnHand
                                     }).Distinct()
                               .ToList();

                var result = data.OrderBy(q => q.id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id =Convert.ToInt64(z.ItemNumber), text = lang == "ar-EG" ? z.ItemName : z.ItemName, altText = z.ItemNumber.ToString() }).ToList();

                var select2pagedResult = new Select2PagedResult
                {
                    Total = data.Count(),
                    Results = result
                };



                return select2pagedResult;
            }
            else
            {
                var data = _repoIvWarehouseItems.GetAll()
                                   .Join(inner: _ivpriceListTr,
                                     outerKeySelector: f => f.IvItemId,
                                     innerKeySelector: s => s.IvItemId,
                                     (f, s) => new { f, s })
                                   .Where(s => s.s.IvPriceListHdId == IvPriceListHdId && s.f.IvWarehouseId == IvWarehouseId)
                                   .Join(inner: Repository.GetAll(),
                                         outerKeySelector: f => f.f.IvItemId,
                                         innerKeySelector: item => item.Id,
                                         resultSelector: (f, item) => new
                                         {
                                             id = item.Id,
                                             ItemName = item.ItemName,
                                             item.AvgCost,
                                             item.TaxPercentageLkpId,
                                             item.ItemNumber,
                                             price = f
                                          .s.Price,
                                             CurrentOnHand = f.f.CurrentOnHand
                                         }).Distinct()
                                   .ToList();

                var result = data.OrderBy(q => q.id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = Convert.ToInt64(z.ItemNumber), text = lang == "ar-EG" ? z.ItemName : z.ItemName, altText = z.ItemNumber.ToString() }).ToList();

                var select2pagedResult = new Select2PagedResult
                {
                    Total = data.Count(),
                    Results = result
                };



                return select2pagedResult;

            }





            //return null;
        }



        public IvItemsDto GetItemData(string input, long Id)
        {
            var data = Repository.GetAllIncluding(x=>x.IvUnits,x=>x.FndTaxType).Where(x => x.Id == Id).FirstOrDefault();
            IvItemsDto ModelDto = new IvItemsDto();
            ObjectMapper.Map(data, ModelDto);
            var itemdto = new IvItemsDto
            {
                Id = ModelDto.Id,
                FndTaxtypeId = ModelDto.FndTaxtypeId,
                IvUnitId= ModelDto.IvUnitId,
                IvUnits= ModelDto.IvUnits,
                Percentage=ModelDto.FndTaxType?.Percentage ?? 0

            };
            return itemdto;

        }

        public IvItemsDto GetItemDatadetails(string input, long Id, long IvWarehouseId, long IvPriceListHdId)
        {
            try
            {

                var _ivwarehous = _repoIvWarehouseItems.GetAll();
                var _ivpriceListTr = _repoIvPriceListTr.GetAll();
                //var data = _repoIvWarehouseItems.GetAll()
                //                      .Join(inner: _ivpriceListTr,
                //                        outerKeySelector: f => f.IvItemId,
                //                        innerKeySelector: s => s.IvItemId,
                //                        (f, s) => new { f, s }).Where(s => s.s.IvPriceListHdId == IvPriceListHdId && s.f.IvWarehouseId == IvWarehouseId && s.f.IvItemId == Id)
                //                      .Join(inner: Repository.GetAll(),
                //                            outerKeySelector: f => f.f.IvItemId,
                //                            innerKeySelector: item => item.Id,
                //                            resultSelector: (f, item) => new IvItemsDto
                //                            {
                //                                Id = item.Id,
                //                                ItemName = item.ItemName,
                //                                AvgCost = item.AvgCost.HasValue ? item.AvgCost : 0,
                //                                FndTaxtypeId = item.FndTaxtypeId,
                //                                ItemNumber = item.ItemNumber,
                //                                price = f.s.Price,
                //                                CurrentOnHand = f.f.CurrentOnHand,
                //                            }).Distinct()
                //                      .SingleOrDefault();


                var data = (from a in _repoIvWarehouseItems.GetAll()
                                     join b in _ivpriceListTr on a.IvItemId equals b.IvItemId
                                     join s in Repository.GetAll()
                                     on b.IvItemId equals s.Id
                                    join pg in _repoFndTaxType.GetAll()
                                     on s.FndTaxtypeId equals pg.Id into pgs
                                       from m in pgs.DefaultIfEmpty()
                                       .Where(s => b.IvPriceListHdId == IvPriceListHdId && a.IvWarehouseId == IvWarehouseId && a.IvItemId == Id)
                            select new IvItemsDto
                            {
                                Id = s.Id,
                                ItemName = s.ItemName,
                                AvgCost = s.AvgCost.HasValue ? s.AvgCost : 0,
                                FndTaxtypeId = s.FndTaxtypeId,
                                ItemNumber = s.ItemNumber,
                                price = b.Price,
                                CurrentOnHand = a.CurrentOnHand,
                                Percentage=m.Percentage
                            }).AsQueryable().Distinct().FirstOrDefault();



                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IvItemsDto> GetItemDataByBarcode(string barcode, long IvPriceListHdId,long IvWarehouseId)
        {
            barcode = barcode.Trim();
             var data = await Repository.GetAllIncluding(x => x.IvUnits, x => x.FndTaxType).FirstOrDefaultAsync(x=>x.ItemBarcode==barcode);

            if (barcode.Length < 10)
                return null;

            decimal qty = 1;
            int weight = 0;
            if (data == null) {
                var newBarcode = barcode.Substring(4, 3);

                data = await Repository.GetAllIncluding(x => x.IvUnits, x => x.FndTaxType).FirstOrDefaultAsync(x => x.ItemBarcode == newBarcode && x.ItemBarcode.Length==3);
                
                qty = 0;
                try {
                    barcode = barcode.Substring(barcode.Length - 6);
                    _ = int.TryParse(barcode, out weight);
                    qty = (decimal)weight / 10000;
                }
                catch (Exception ex)
                { 
                
                }

                if (data == null) {
                    return null;
                }
            }
            var itemPriceList =await _repoIvPriceListTr.GetAll().FirstOrDefaultAsync(x => x.IvPriceListHdId == IvPriceListHdId && x.IvItemId == data.Id);
            var warehouse =await _repoIvWarehouseItems.GetAll().FirstOrDefaultAsync(x => x.IvWarehouseId == IvWarehouseId && x.IvItemId == data.Id);
            IvItemsDto ModelDto = new IvItemsDto();
            
            ObjectMapper.Map(data, ModelDto);
            //var itemdto = new IvItemsDto
            //{
            //    Id = ModelDto.Id,
            //    FndTaxtypeId = ModelDto.FndTaxtypeId,
            //    IvUnitId = ModelDto.IvUnitId,
            //    IvUnits = ModelDto.IvUnits,
            //    Percentage = ModelDto.FndTaxType?.Percentage ?? 0,
            //    price= itemPriceList.Price,

            //};
            ModelDto.UnitName = data.IvUnits.UnitName;
            ModelDto.UnitPrice = itemPriceList==null?0: itemPriceList.Price;
            ModelDto.Avilablequantity = warehouse==null?0: warehouse.CurrentOnHand;

            ModelDto.ItemOrdQty = qty;
            return ModelDto;

        }
        public async Task<IvItemsDto> GetItemDataById(long id, long IvPriceListHdId, long IvWarehouseId)
        {

            var data = await Repository.GetAllIncluding(x => x.IvUnits, x => x.FndTaxType).FirstOrDefaultAsync(x => x.Id == id);

            
            var itemPriceList = await _repoIvPriceListTr.GetAll().FirstOrDefaultAsync(x => x.IvPriceListHdId == IvPriceListHdId && x.IvItemId == data.Id);
            var warehouse = await _repoIvWarehouseItems.GetAll().FirstOrDefaultAsync(x => x.IvWarehouseId == IvWarehouseId && x.IvItemId == data.Id);
            IvItemsDto ModelDto = new IvItemsDto();

            ObjectMapper.Map(data, ModelDto);
            
            ModelDto.UnitName = data.IvUnits.UnitName;
            ModelDto.UnitPrice = itemPriceList == null ? 0 : itemPriceList.Price;
            ModelDto.Avilablequantity = warehouse == null ? 0 : warehouse.CurrentOnHand;
            if(ModelDto.Avilablequantity>0 && ModelDto.Avilablequantity<1)
                ModelDto.ItemOrdQty = ModelDto.Avilablequantity;
            else
                ModelDto.ItemOrdQty = 1;
            return ModelDto;

        }


        public async Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
           => await _ivItemsManager.GetIvItemsSelect2(searchTerm, pageSize, pageNumber, lang);
    }
}
