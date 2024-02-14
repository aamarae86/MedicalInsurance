using ERP._System.__CharityBoxes._TmDamagedCharityBoxs.ProcDto;
using ERP._System.PostRecords.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CharityBoxes._TmDamagedCharityBoxs
{
    public interface IGetTmDamagedCharityBoxesScreenDataRepository
        : IExecuteProcedure<TmDamagedCharityBoxs, long, IdLangInputDto, TmDamagedCharityBoxesScreenDataOutput>
    {
    }
}
