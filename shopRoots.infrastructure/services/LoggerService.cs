using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using shopRootsAdmin.core.interfaces;
using shopRootsAdmin.core.models;
namespace shopRoots.infrastructure.services
{
    public class LoggerService : Ilogger
    {

        private readonly IRepository<logModel> _loggerSvc;
        public LoggerService(IRepository<logModel> logger) {
            _loggerSvc = logger;
        }

        public async Task<logModel> Log(string message)
        {
            var loggerModel = new logModel();
            loggerModel.message = message;
            return  await _loggerSvc.Create(loggerModel);
        }
    }
}
