using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    [ServiceContract]
    public interface IBartService
    {
        [OperationContract]
        IssueResponse GetIssue(string id, IssueRequest request);
        [OperationContract]
        BigObject GetBigObject(int size);
    }

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

    [DataContract]
    [ProtoContract]
    public class IssueResponse
    {
        [DataMember(Order = 0)]
        [ProtoMember(1)]
        public List<Issue> Issue { get; set; }
    }

    [DataContract]
    [ProtoContract]
    public class IssueRequest
    {
        [DataMember(Order = 0)]
        [ProtoMember(1)]
        public string UserName { get; set; }
    }

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




    public class BartService : IBartService
    {
        private static int count;
        public BartService(IIssueProvider issueProvider)
        {
            Console.WriteLine("Created Service Instance :" + count);
            count++;
        }

        public BigObject GetBigObject(int size)
        {
            var obj = new BigObject
            {
                Name = "My big object",
                ID = Guid.NewGuid()
            };

            obj.Data = BuildBigData(size);
            return obj;
        }

        private List<short> BuildBigData(int size)
        {
            Random rand = new Random();
            List<short> data = new List<short>();
            for (int i = 0; i < size; ++i)
            {
                data.Add((short)rand.Next(short.MaxValue));
            }

            return data;
        }

        public IssueResponse GetIssue(string id, IssueRequest request)
        {
            return new IssueResponse
            {
                Issue = new List<Issue> {
                    new Issue              {                   IssueId =123,                   Title = "Issue Title" +123        },
                    new Issue        {                            IssueId = 124,                   Title = "Issue Title" + 124        }
                                        }
            };
        }
    }
}
