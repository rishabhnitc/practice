using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace ServiceLibrary
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class NotificationService : INotificationService
    {
        public void Register()
        {
            
        }
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
