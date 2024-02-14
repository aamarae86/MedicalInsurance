using Abp.Application.Services.Dto;
using AutoMapper;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Calender.Dto
{
    public class CalenderMemoDto : AuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
        public string Memo { get; set; }
        public string MemoDate { get; set; }
        public long UserId { get; set; }
    }
}
