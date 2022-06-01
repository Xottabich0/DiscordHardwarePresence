using System.ServiceProcess;
using System;
using System.Linq;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;
using System.Text.RegularExpressions;
using System.Threading;

namespace DiscordHWRich
{
    public partial class Service1 : ServiceBase
    {
        //Ебанутый щиткод простите пожалуйста
        //const string applicationId = "913475055009300510";
        const string applicationId = "932005580527247420";
        static DiscordRpc.RichPresence presence;
        static DiscordRpc.EventHandlers handlers;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            presence = new DiscordRpc.RichPresence();
            handlers = new DiscordRpc.EventHandlers();
            DiscordRpc.Initialize(applicationId, ref handlers, true, "");
            DateTime foo = DateTime.Now;
            long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();
            presence.startTimestamp = unixTime;
            presence.largeImageKey = "bebrila";
            var comp = new Computer();
            comp.CPUEnabled = true;
            comp.GPUEnabled = true;
            comp.RAMEnabled = true; // код дешки лол XD BRUH LOL И да мне похуй на плюсы потому что сложно. ахахахахахах.
            //var gpuLoad = 0;
            comp.Open();
            var cpuname = comp.Hardware.First(h => h.HardwareType == HardwareType.CPU);
            var gpuname = comp.Hardware.First(h => h.HardwareType == HardwareType.GpuNvidia);
            var cpuLoad = comp.Hardware.First(h => h.HardwareType == HardwareType.CPU).Sensors.Last(s => s.SensorType == SensorType.Load && s.Name == "CPU Total");
            var cpuTemp = comp.Hardware.First(h => h.HardwareType == HardwareType.CPU).Sensors.Last(s => s.SensorType == SensorType.Temperature && s.Name == "CPU Package");
            var cpuWatt = comp.Hardware.First(h => h.HardwareType == HardwareType.CPU).Sensors.Last(s => s.SensorType == SensorType.Power && s.Name == "CPU Package");
            var cpuClock = comp.Hardware.First(h => h.HardwareType == HardwareType.CPU).Sensors.Last(s => s.SensorType == SensorType.Clock && s.Name == "CPU Core #2");
            var gpuTemp = comp.Hardware.First(h => h.HardwareType == HardwareType.GpuNvidia).Sensors.First(s => s.SensorType == SensorType.Temperature);
            var gpuLoad = comp.Hardware.First(h => h.HardwareType == HardwareType.GpuNvidia).Sensors.First(s => s.SensorType == SensorType.Load);
            var gpuClock = comp.Hardware.First(h => h.HardwareType == HardwareType.GpuNvidia).Sensors.First(s => s.SensorType == SensorType.Clock);
            var ramLoad = comp.Hardware.First(h => h.HardwareType == HardwareType.RAM).Sensors.First(s => s.Name == "Used Memory");
            var ramAvailable = comp.Hardware.First(h => h.HardwareType == HardwareType.RAM).Sensors.First(s => s.Name == "Available Memory");
            Action Tab1 = () =>
            {
                comp.Hardware.ToList().ForEach(h => h.Update());
                presence.state = $"{Regex.Replace(gpuname.Name, @"NVIDIA NVIDIA GeForce", "")}: {gpuTemp.Value}°C {Math.Round((double)gpuLoad.Value)}%";
                presence.details = $"{Regex.Replace(cpuname.Name, @"(\d+)th Gen", "")} {cpuTemp.Value}°C {Math.Round((double)cpuWatt.Value)}W";
                DiscordRpc.UpdatePresence(presence);
            };
            Action Tab2 = () =>
            {
                comp.Hardware.ToList().ForEach(h => h.Update());
                presence.details = $"CPU: {Math.Round((double)cpuLoad.Value)}% {Math.Round((double)cpuClock.Value / 1000, 1)}GHz";
                presence.state = $"RAM: {Math.Round((double)ramLoad.Value)}/{Math.Round((double)(ramAvailable.Value + ramLoad.Value))}GB DDR4";
                DiscordRpc.UpdatePresence(presence);
            };
            var task = Task.Run(async () =>
            {
                while (true)
                {
                    Tab1();
                    await Task.Delay(4000);
                    Tab1();
                    await Task.Delay(4000);
                    Tab2();
                    await Task.Delay(4000);
                    Tab2();
                    await Task.Delay(4000);
                }
            });
        }

        protected override void OnStop()
        {
        }
    }
}
