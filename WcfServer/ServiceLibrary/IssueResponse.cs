using ProtoBuf;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServiceLibrary
{
    [DataContract]
    [ProtoContract]
    public class IssueResponse
    {
        [DataMember(Order = 0)]
        [ProtoMember(1)]
        public List<Issue> Issue { get; set; }
    }
}
