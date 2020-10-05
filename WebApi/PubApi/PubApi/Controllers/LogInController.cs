using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using PubApi.Models;

namespace PubApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogInController : ControllerBase
    {
        Logger log = LogManager.GetCurrentClassLogger();

        private readonly ILogger<LogInController> _logger;

        public LogInController(ILogger<LogInController> logger)
        {
            _logger = logger;
        }
        

        [HttpGet]
        public IEnumerable<Login> Get()
        {


            try
            {
                using (var context = new db843153744Context())
                {
                    return context.Login.ToList();
                }
            }
            catch (Exception e)
            {

                log.Debug("....................LogInController EXCEPTION  try to create context...............");
                log.Debug(".................Problem is " + e.Message);

                using (var context = new db843153744Context())
                {
                    return context.Login.ToList();
                }

            }
        }
    }
}
