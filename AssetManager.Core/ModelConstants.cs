using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core
{
    public static class ModelConstants
    {
        public static class AssetStatuses
        {
            public const int New = 1;
            public const int Assigned = 2;
            public const int Unassigned = 3;
            public const int Discarded = 4;
            public const int ApprovalPending = 5;
        }

        public static class ApprovalStatuses
        {
            public const int Pending = 1;
            public const int Approved = 2;
            public const int Rejected = 3;
        }

        public static class Departments
        {
            public const int System = -1;
        }

        public static class JobTitles
        {
            public const int SystemAdministrator = -1;
        }

        public static class Staff
        {
            public static Guid SystemAdministrator = new Guid("8b6bcca1-88a7-4e1c-9d2b-12b0f7030f05");
        }
    }
}
