using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HW1c.Models;
using HW1c.Backend;

namespace HW1c.Backend
{
    public class LogBackend
    {
        #region SingletonPattern
        private static volatile LogBackend instance;
        private static object syncRoot = new object();

        private LogBackend() { }

        public static LogBackend Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new LogBackend();
                    }
                }

                return instance;
            }
        }
        #endregion SingletonPattern

        // Hook up the Repositry
        private ILogRepository repository = new LogRepositoryMock();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public LogModel Create(LogModel data)
        {
            var myData = repository.Create(data);
            return myData;
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LogModel Read(string id)
        {
            var myData = repository.Read(id);
            return myData;
        }
        
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public LogModel Update(LogModel data)
        {
            var myData = repository.Update(data);
            return myData;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            var myData = repository.Delete(id);
            return myData;
        }

        /// <summary>
        ///  Returns the List of Logs
        /// </summary>
        /// <returns></returns>
        public LogViewModel Index()
        {
            var myData = new LogViewModel();
            myData.LogList = repository.Index();

            return myData;
        }
    }
}