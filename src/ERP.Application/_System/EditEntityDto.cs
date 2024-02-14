using Abp.Application.Services.Dto;
using ERP.ModificationsValidation;
using System;

namespace ERP._System
{
    public class EditEntityDto<TPrimaryKey> : EntityDto<TPrimaryKey>, IHasModificationTimeValidation
    {
        public DateTime? LastModificationTime { get; }
        public string LastModificationTimeStr { get; set; }
    }
}
