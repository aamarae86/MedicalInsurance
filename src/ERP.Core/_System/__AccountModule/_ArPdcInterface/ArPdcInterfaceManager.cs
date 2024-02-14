using Abp.Domain.Repositories;
using Abp.Events.Bus;
using ERP._System._ArPdcInterface;
using ERP.Core.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ApPdcInterface
{
    public class ArPdcInterfaceManager: IArPdcInterfaceManager
    {
        public IEventBus EventBus { get; set; }
    }
}
