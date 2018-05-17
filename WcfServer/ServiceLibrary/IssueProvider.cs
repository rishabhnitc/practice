using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    public interface IIssueProvider
    {

    }
    public class IssueProvider : IIssueProvider
    {
        private static int count;
        public IssueProvider()
        {
            Console.WriteLine("Create IssueProvider" + count);
            count++;
        }
    }
}
