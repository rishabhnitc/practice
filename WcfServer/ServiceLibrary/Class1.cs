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
    }

    [DataContract]
    public class IssueResponse
    {
        [DataMember]
        public List<Issue> Issue { get; set; }
    }

    [DataContract]
    public class IssueRequest
    {
        [DataMember]
        public string UserName { get; set; }
    }

    [DataContract]
    public class Issue
    {
        [DataMember]
        public int IssueId { get; set; }
        [DataMember]
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
