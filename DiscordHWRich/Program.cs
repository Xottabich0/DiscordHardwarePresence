using System.ServiceProcess;
using System;
using System.Linq;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;
using System.Text.RegularExpressions;
using System.Threading;

namespace DiscordHWRich
{
    //start function
    static class Program
    {
        //const string applicationId = "913475055009300510";
        const string applicationId = "932005580527247420";
        static DiscordRpc.RichPresence presence;
        static DiscordRpc.EventHandlers handlers;
        static void Main(string[] args)
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
