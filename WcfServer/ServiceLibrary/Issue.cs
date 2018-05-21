using ProtoBuf;
using System.Runtime.Serialization;

namespace ServiceLibrary
{
    [DataContract]
    [ProtoContract]
    public class Issue
    {
        [DataMember(Order = 0)]
        [ProtoMember(1)]
        public int IssueId { get; set; }
        [DataMember(Order = 1)]
        [ProtoMember(2)]
        public string Title { get; set; }
    }
}
