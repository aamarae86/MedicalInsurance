using Abp.Events.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ApPdcInterface
{
    public class ApPdcInterfaceManager: IApPdcInterfaceManager
    {
        public IEventBus EventBus { get; set; }
    }
}
