using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServiceLibrary
{
    [ProtoContract]
    [DataContract]
    public class BigObject
    {
        [ProtoMember(1)]
        [DataMember(Order = 0)]
        public List<short> Data { get; set; }

        [ProtoMember(2)]
        [DataMember(Order = 0)]
        public string Name { get; set; }

        [ProtoMember(3)]
        [DataMember(Order = 0)]
        public Guid ID { get; set; }
    }
}
