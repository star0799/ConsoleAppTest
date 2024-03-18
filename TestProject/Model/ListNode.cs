using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Model
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
        #region overrideToString()
        //public override string ToString()
        //{
        //    ListNode current = this;
        //    StringBuilder sb = new StringBuilder();
        //    while (current != null)
        //    {
        //        sb.Append(current.val).Append(" -> ");
        //        current = current.next;
        //    }
        //    sb.Append("null");
        //    return sb.ToString();
        //}
        #endregion
        public string ToString(string symbol)
        {
            string result = string.Empty;
            ListNode current = this;
            while (current != null)
            {
                result += $"{current.val}{symbol}";
                current = current.next;
            }
            result = result.Substring(0, result.Length - 1);
            return result;
        }

        public int Length
        {
            get
            {
                int length = 0;
                ListNode current = this;
                while (current != null)
                {
                    length++;
                    current = current.next;
                }
                return length;
            }
        }
        public bool IsNull()
        {
            return this == null;
        }
        public int Get(int index)
        {
            ListNode current = this;
            int count = 0;
            while (current != null && count < index)
            {
                current = current.next;
                count++;
            }
            return current.val;
        }
        public ListNode RemoveAtIndex(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            if (index == 0)
            {
                return this.next;
            }

            ListNode current = this;
            int count = 0;
            while (current != null && count < index - 1)
            {
                current = current.next;
                count++;
            }

            current.next = current.next.next;
            return this;
        }

        public ListNode AddAtIndex(int index, int value)
        {
            ListNode addNode = new ListNode(value);
            if (index == 0)
            {
                addNode.next = this;
                return addNode;
            }
            ListNode current=this;
            int count = 0;
            while (current != null && count < index-1)
            {
                current = current.next;
                count++;
            }
            addNode.next = current.next;
            current.next = addNode;
            return this;
        }
    }
}
