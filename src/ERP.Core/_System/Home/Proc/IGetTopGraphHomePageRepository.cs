﻿using ERP._System.Home.Input;
using ERP._System.Home.Ouput;
using ERP.Authorization.Users;

namespace ERP._System.Home.Proc
{
    public interface IGetTopGraphHomePageRepository : IExecuteProcedure<User, long, GetTopGraphHomePageInput, GetTopGraphHomePageOutput>
    { }
}
