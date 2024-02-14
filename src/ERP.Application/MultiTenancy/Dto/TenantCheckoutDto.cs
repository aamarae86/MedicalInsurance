using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.MultiTenancy.Dto
{

    public class TenantCheckoutDto
    {
        public string SessionId { get; set; }
        public int TenentId { get; set; }
        public IEnumerable<UserCheckoutDto> UsersModel { get; set; }
    }

    public class UserCheckoutDto
    {
        public int UserId { get; set; }
        public decimal Price { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int NOfMonthes { get; set; }
        public string NewSubEndDate { get; set; }
      
    }


    //public class TenantCheckoutDto
    //{
    //    public int UserId { get; set; }
    //    public decimal Price { get; set; }
    //    public string UserName { get; set; }
    //    public string Email { get; set; }
    //    public int NOfMonthes { get; set; }
    //    public string NewSubEndDate { get; set; }
    //    public string SessionId { get; set; }
    //    public int TenentId { get; set; }
    //}



    public class TenantCheckoutResponseDto
    {
        public int NOfMonthes { get; set; }
        public int TenentId { get; set; }
        public string TransactionNumber { get; set; }
    }
    public class CompleteTenantCheckoutDto: TenantCheckoutResponseDto { } 



}
