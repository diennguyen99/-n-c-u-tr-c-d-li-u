using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_quản_lý_sinh_viên
{
    class LinkedList<T>
    {
        public class Node
        {
            public string key;
            public T data;
            public Node pNext;
        }
        public Node pHead;
        public Node pTail;
        public int count;

        public LinkedList()
        {
            pHead = null;
            pTail = null;
            count = 0;
        }

        Node CreateNode(T info, string key)
        {
            Node pNode = new Node();
            if (pNode != null)
            {
                pNode.key = key;
                pNode.data = info;
                pNode.pNext = null;
            }
            return pNode;
        }

        Node CreateNode(T info)
        {
            Node pNode = new Node();
            if (pNode != null)
            {
                
                pNode.data = info;
                pNode.pNext = null;
            }
            return pNode;
        }

        public void Add(T info, string key)
        {
            Node pNode = CreateNode(info, key);
            if (pHead == null)
            {
                pHead = pTail = pNode;
            }
            else
            {
                pTail.pNext = pNode;
                pTail = pNode;
                pTail.pNext = null;
            }
            count++;
        }

        public void Remove(string key)
        {
            Node pDelete = pHead;
            Node pPre = null;

            while (pDelete != null)
            {
                if (pDelete.key == key)
                    break;
                pPre = pDelete;
                pDelete = pDelete.pNext;
            }
            if (pDelete == pHead)
            {
                pHead = pHead.pNext;
                pDelete.pNext = null;
                pDelete = null;
            }
            else if (pDelete.pNext == null)
            {
                pTail = pPre;
                pPre.pNext = null;
                pDelete = null;
            }
            else
            {
                pPre.pNext = pDelete.pNext;
                pDelete.pNext = null;
                pDelete = null;
            }

            count--;
        }

        public Node Search(string key)
        {
            Node pTemp = pHead;

            while (pTemp != null)
            {
                if(pTemp.key == key)
                {
                    return pTemp;
                }
                pTemp = pTemp.pNext;
            }
            return null;
        }
    }
}
