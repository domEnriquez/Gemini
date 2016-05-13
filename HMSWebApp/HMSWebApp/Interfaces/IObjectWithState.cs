using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMSWebApp.Enums;

namespace HMSWebApp.Interfaces
{
    public interface IObjectWithState
    {
        State State { get; set; } 
    }
}