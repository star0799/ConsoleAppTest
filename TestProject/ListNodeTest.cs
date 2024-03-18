using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Model;

namespace TestProject
{
    public class ListNodeTest
    {
        [Test]
        public void Main()
        {
            ListNode node = new ListNode();
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(5);
            //var result = head.Length;
            //var result = head.ToString(",");
            //var result = head.IsNull();
            var result = head.Get(1);
            //var result = head.RemoveAtIndex(2);
            //var result = head.AddAtIndex(4,7);
        }    
    }
}
