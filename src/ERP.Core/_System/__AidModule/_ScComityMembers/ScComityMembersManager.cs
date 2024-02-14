using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._ScComityMembers
{
    public class ScComityMembersManager:IScComityMembersManager
    {
        private readonly IRepository<ScComityMembers, long> _repoCommitteeMembers;

        public ScComityMembersManager(IRepository<ScComityMembers, long> repoCommitteeMembers)
        {
            _repoCommitteeMembers = repoCommitteeMembers;
        }
    }
}
