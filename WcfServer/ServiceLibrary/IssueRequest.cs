using ProtoBuf;
using System.Runtime.Serialization;

namespace ServiceLibrary
{
    [DataContract]
    [ProtoContract]
    public class IssueRequest
    {
        [DataMember(Order = 0)]
        [ProtoMember(1)]
        public string UserName { get; set; }
    }
}
