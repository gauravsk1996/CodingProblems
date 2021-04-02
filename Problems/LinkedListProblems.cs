using System.Collections.Generic;

namespace CodingProblems
{
    public class Node
    {
        public string Value { get; set; }
        public Node NextNode { get; set; }
    }
    public class LinkedListProblems
    {
        public LinkedListProblems()
        {
            Node sixth = new()
            {
                Value = "Six",
                NextNode = null
            };
            Node fifth = new()
            {
                Value = "Five",
                NextNode = sixth
            };
            Node fourth = new()
            {
                Value = "Four",
                NextNode = fifth
            };
            Node third = new()
            {
                Value = "Three",
                NextNode = fourth
            };
            Node second = new()
            {
                Value = "Two",
                NextNode = third
            };
            Node first = new()
            {
                Value = "One",
                NextNode = second
            };
            IsCircular(first);
            RotateRight(first, 2);
        }

        /// <summary>
        /// Rotate the given link list to right by given number of positions
        /// eg. count is given 2 for list as below
        /// input list = 1->2->3->4->5->6
        /// output list = 5->6->1->2->3->4
        /// </summary>
        /// <param name="head">Start Node of Linked list</param>
        /// <param name="count">number of position to shift</param>
        private void RotateRight(Node head, int count)
        {
            Node currentNode = head;
            List<Node> nodesList = new();
            nodesList.Add(head);
            List<Node> newList = new();
            while (currentNode.NextNode != null)
            {
                nodesList.Add(currentNode.NextNode);
                currentNode = currentNode.NextNode;
            }
            if (count >= nodesList.Count)
            {
                count -= nodesList.Count;
            }
            if (count > 0)
            {
                for (int i = nodesList.Count - count; i < nodesList.Count; i++)
                {
                    newList.Add(nodesList[i]);
                }
                for (int i = 0; i < nodesList.Count - count; i++)
                {
                    newList.Add(nodesList[i]);
                }
                for(int i =0; i < newList.Count; i++)
                {
                    if(i+1 == newList.Count)
                    {
                        newList[i].NextNode = null;
                        break;
                    }
                    newList[i].NextNode = newList[i + 1];
                }
            }
        }

        /// <summary>
        /// Check if the given linked list is circular or not
        /// meaning any node points to previous node or not
        /// </summary>
        /// <param name="head">starting node of the Linked list</param>
        /// <returns>true if the linked list is circular else false</returns>
        private bool IsCircular(Node head)
        {
            Node currentNode = head;
            List<Node> nodesList = new List<Node>();
            nodesList.Add(head);
            while (currentNode.NextNode != null)
            {
                if (nodesList.Contains(currentNode.NextNode))
                {
                    return true;
                }
                nodesList.Add(currentNode.NextNode);
                currentNode = currentNode.NextNode;
            }
            return false;
        }
    }
}
