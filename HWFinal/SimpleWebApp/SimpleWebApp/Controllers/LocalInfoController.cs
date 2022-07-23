using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Sockets;

namespace SimpleWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocalInfoController : ControllerBase
    {
        private readonly ILogger<LocalInfoController> _logger;
        public LocalInfoController(ILogger<LocalInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet("getlocalinfo")]
        public LocalInfo GetLocalInfo()
        {
            var currentDateTime = DateTime.Now;
            var myHost = Dns.GetHostEntry(Dns.GetHostName());
            var myIp = string.Empty;
            foreach (var ipaddr in myHost.AddressList)
            {
                if (ipaddr.AddressFamily == AddressFamily.InterNetwork)
                {
                    myIp = ipaddr.ToString();
                }
            }

            return new LocalInfo()
            {
                Date = currentDateTime.ToString("MM-dd-yyyy"),
                Time = currentDateTime.ToString("HH:mm"),
                TimeZone = TimeZoneInfo.Local.StandardName,
                HostName = myHost.HostName,
                IpAddress = myIp
            };
        }

    }
}
