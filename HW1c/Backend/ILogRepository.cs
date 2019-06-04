using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HW1c.Models;

namespace HW1c.Backend
{

    /// <summary>
    /// Define an interface which contains the methods for the Log repository.
    /// All CRUDi aspects
    /// </summary>
    public interface ILogRepository
    {
        LogModel Create(LogModel data);
        LogModel Read(String id);
        LogModel Update(LogModel data);
        Boolean Delete(String id);
        List<LogModel> Index();
    }
}