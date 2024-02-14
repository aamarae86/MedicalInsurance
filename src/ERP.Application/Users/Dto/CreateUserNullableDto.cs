﻿using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using ERP.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP.Users.Dto
{
    [AutoMapTo(typeof(User))]
    public class CreateUserNullableDto //: IShouldNormalize
    {
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; }

        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }

  
        [StringLength(AbpUserBase.MaxSurnameLength)]
        public string Surname { get; set; }

   
        //[EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }

        public string[] RoleNames { get; set; }


        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
       // [DisableAuditing]
        public string Password { get; set; }

        //public void Normalize()
        //{
        //    if (RoleNames == null)
        //    {
        //        RoleNames = new string[0];
        //    }
        //}
    }
}
