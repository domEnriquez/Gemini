using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using HMSWebApp.Enums;

namespace HMSWebApp.Common
{
    public class StateHelpers
    {
        public static EntityState ConvertState(State state)
        {
            switch (state)
            {
                case State.Added:
                    return EntityState.Added;
                case State.Modified:
                    return EntityState.Modified;
                case State.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }
    }
}