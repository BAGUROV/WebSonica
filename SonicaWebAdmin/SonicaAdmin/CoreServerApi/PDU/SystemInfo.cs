using System;
using ProtoBuf;

namespace SonicaWebAdmin.SonicaAdmin.CoreServerApi.PDU
{
    [ProtoContract]
    public class SystemInfo
    {
        [ProtoMember(1)] public int MaxNumberOfClients { get; set; }
        [ProtoMember(2)] public string SoftwareVersion { get; set; }
        [ProtoMember(3)] public DateTime LaunchTime { get; set; }
        [ProtoMember(4)] public int SystemState { get; set; }
        [ProtoMember(6)] public int ProcessorCount { get; set; }

        [ProtoMember(7)] public TimeSpan SystemCreate { get; set; }
        [ProtoMember(8)] public TimeSpan SystemConfigurate { get; set; }
        [ProtoMember(9)] public TimeSpan SystemStart { get; set; }
        [ProtoMember(10)] public DateTime CoreLaunchedTime { get; set; }

        public static SystemInfo Create(
            int currentSystemState,
            int maxNumberOfClients,
            string softwareVersion,
            DateTime launchTime,
            int processorCount,
            TimeSpan systemCreate,
            TimeSpan systemConfigurate,
            TimeSpan systemStart,
            DateTime coreLaunchedTime)
        {
            return new SystemInfo
            {
                SystemState = currentSystemState,
                MaxNumberOfClients = maxNumberOfClients,
                LaunchTime = launchTime,
                SoftwareVersion = softwareVersion,
                ProcessorCount = processorCount,
                SystemCreate = systemCreate,
                SystemConfigurate = systemConfigurate,
                SystemStart = systemStart,
                CoreLaunchedTime = coreLaunchedTime
            };
        }
    }
}