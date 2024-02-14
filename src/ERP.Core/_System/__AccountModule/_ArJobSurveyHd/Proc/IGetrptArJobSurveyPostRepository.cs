using ERP._System.PostRecords.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ArJobSurveyHd.Proc
{
    public interface IGetrptArJobSurveyPostRepository : IExecuteProcedure<ArJobSurveyHd, long, GetrptArJobSurveyPostInput, PostOutput>
    {
    }
}
