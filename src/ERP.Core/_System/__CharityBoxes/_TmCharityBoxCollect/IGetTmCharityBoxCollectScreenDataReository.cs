using ERP._System.__CharityBoxes._TmCharityBoxCollect.ProcDto;
using ERP._System.PostRecords.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollect
{
    public interface IGetTmCharityBoxCollectScreenDataReository
        : IExecuteProcedure<TmCharityBoxCollect, long, IdLangInputDto, TmCharityBoxCollectScreenDataOutput>
    {
    }
}
