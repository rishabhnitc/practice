using ProtoBuf;
using System;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    [ProtoContract]
    [ServiceContract]
    public interface IBartService
    {
        [OperationContract]
        IssueResponse GetIssue(string id, IssueRequest request);
        [OperationContract]
        BigObject GetBigObject(int size);
    }

    [ProtoContract]
    [ServiceContract]
    public interface INotificationService
    {
        [OperationContract]
        void Register();
    }

    public interface IHeartBeatCallback
    {
        [OperationContract(IsOneWay = true)]
        void BroadcastToClient(DateTimeOffset serverTime);
    }
}
