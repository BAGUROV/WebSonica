using System;

namespace SonicaWebAdmin.Services
{
    public class AvtukCoreMetrics
    {
        public AvtukCoreMetrics()
        {

        }
        public double RamUsageBytes { get; set; }
        public double CpuUsagePercent { get; set; }
        public TimeSpan IdleTime { get; set; }
        public TimeSpan ProcessingTime { get; set; }
        public int ProcessedOperationsCount { get; set; }
        public int FailedOperationsCount { get; set; }
        public TimeSpan SlowestOperationTime { get; set; }
        public string SlowestOperationName { get; set; }
        public int QueueLength { get; set; }
        public TimeSpan MeasurementPeriod { get; set; } 
        public TimeSpan ResponseTime { get; set; }
        public float CpuTemperature { get; set; }

        public bool IsNtpEnabled { get; set; }
    }
}