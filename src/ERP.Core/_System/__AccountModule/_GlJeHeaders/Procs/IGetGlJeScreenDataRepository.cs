using ERP._System._GlJeHeaders.ProcDto;
using ERP._System.PostRecords.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._GlJeHeaders.Procs
{
    public interface IGetGlJeScreenDataRepository
         : IExecuteProcedure<GlJeHeaders, long, IdLangInputDto, GlJeScreenDataOutput>
    {
    }
}
