using ProtoBuf;

namespace SonicaWebAdmin.SonicaAdmin.CoreServerApi.PDU
{
    [ProtoContract]
    public class ProjectInfo
    {
        [ProtoMember(1)] public string ProjectName      { get; set; }
        [ProtoMember(2)] public long   AtomsCount       { get; set; }
        [ProtoMember(3)] public long   BlocksCount      { get; set; }
        [ProtoMember(4)] public long   ActiveLinksCount { get; set; }
        [ProtoMember(5)] public long   LostLinksCount   { get; set; }

        public static ProjectInfo Create(
            string projectName, 
            long atomsCount, 
            long blockCount, 
            long activeLinksCount,
            long lostLinksCount)
        {
            return new ProjectInfo
            {
                ProjectName      = projectName,
                AtomsCount       = atomsCount,
                ActiveLinksCount = activeLinksCount,
                BlocksCount      = blockCount,
                LostLinksCount   = lostLinksCount
            };
        }
    }
}