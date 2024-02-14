using ERP._System;
using ERP.Authorization.Users;
using ERP.MultiTenancy.Input;
using ERP.MultiTenancy.Output;

namespace ERP.MultiTenancy.Proc
{
    public interface ICheckDublicatedEmailAbpUserRepository : IExecuteProcedure<User, long, CheckDublicatedEmailAbpUserInput, DublicatedEmailAbpUserOutput>
    {}
}
