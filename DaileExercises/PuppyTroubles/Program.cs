using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace PuppyTroubles
{
    class Program
    {
        class Node
        {
            public Node Parent { get; set; }
            public List<Node> Children { get; set; }

            public int Data { get; set; }


            public Node(int data)
            {
                Data = data;
                Children = new List<Node>();
            }

            public Node(int data, Node parent)
            {
                Data = data;
                Parent = parent;
                Children = new List<Node>();
            }

            public List<Node> GetWalkBack()
            {
                List<Node> result = new List<Node>();
                Node active = this;
                while (active != null)
                {
                    result.Add(active);
                    active = active.Parent;
                }
                return result;
            }

        }
        static void Main(string[] args)
        {
            List<int> treats = new List<int>() { 1, 2, 3 };

            List<Node> tree = BuildTree(treats);


            int combinations = GetCombinations(treats.Count);
            int result = 0;
            List<int> highestResult = new List<int>();

            //SwapTreats(treats, ref indexToMove);
            //if(HappinessTotal(treats) > result)
            //{
            //    result = HappinessTotal(treats);
            //    highestResult = treats;
            //}
            //indexToMove++;

            //while (combinations > 0)
            //{
            //    SwapTreats(treats, ref indexToMove);
            //    int happy = HappinessTotal(treats);

            //    if (happy > result)
            //    {
            //        result = happy;
            //        highestResult = new List<int>(treats);
            //    }
            //    combinations--;
            //}


            //Console.WriteLine("the list of treats: " + originalList);
            Console.WriteLine("highest happiness: " + result);
            Console.WriteLine("highest happiness distribution: " + PrintList(highestResult));
            Console.Read();

        }

        static string PrintList(List<int> list)
        {
            string result = "List: [";
            foreach (int i in list)
            {
                result += i + ", ";
            }
            result += "]";
            return result;
        }

        static List<List<int>> GetCombinations(List<Node> tree)
        {
            List<List<int>> comboList = new List<List<int>>();

        }

        static void SwapTreats(List<int> list, ref int indexToMove)
        {
            if (indexToMove == list.Count - 1)
            {
                indexToMove = 0;
            }
            int t = list[indexToMove];
            list.RemoveAt(indexToMove);
            list.Insert(++indexToMove, t);
        }

        static List<Node> BuildTree(List<int> treatsList)
        {
            List<Node> tree = new List<Node>();

            Node root = new Node(0, null);

            Node activeNode = root;
           // uint loopCount = 0;
            //uint expectedNumberOfLoops = 1000000;

            while (activeNode != null)
            {
//#if DEBUG
//                if (loopCount++ > expectedNumberOfLoops)
//                {
//                    if (MessageBox.Show("ERROR: POSSIBLE INF LOOP\n\nCONTINUE?", "INF LOOP", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes)
//                    {
//                        loopCount = 0;
//                    }
//                    else
//                    {
//                        return;
//                    }
//                }
//#endif
                //build treat list
                List<int> activeTreats = new List<int>(treatsList);
                foreach (Node parent in activeNode.GetWalkBack())
                {
                    activeTreats.Remove(parent.Data);
                }

                //if active node doesn't have all it's damn kids
                if (activeNode.Children.Count < activeTreats.Count)
                {
                    //give it all the damn kids
                    foreach (int num in activeTreats)
                    {
                        Node newNode = new Node(num, activeNode);
                        activeNode.Children.Add(newNode);
                    }
                }
                //already has damn kids
                else
                {
                    bool childrenHaveChildren = true;
                    //check each child has damn kids
                    foreach (Node child in activeNode.Children)
                    {
                        List<int> childTreats = new List<int>(activeTreats);
                        childTreats.Remove(child.Data);
                        if (child.Children.Count < childTreats.Count)
                        {
                            //if not make child activenode
                            activeNode = child;
                            childrenHaveChildren = false;
                        }
                        else
                        {
                            if (child.Children.Count == 0)//necessary?
                            {
                                //we have a leaf
                                tree.Add(child);
                            }
                        }

                    }
                    if (childrenHaveChildren)
                    {
                        activeNode = activeNode.Parent;
                    }
                }
            }
            return tree;
        }

        private static Node GetMatching(int dataValue, List<Node> list)
        {
            foreach (Node n in list)
            {
                if (n.Data == dataValue)
                {
                    return n;
                }
            }
            return null;
        }

        static int HappinessTotal(List<int> treats)
        {
            int result = 0;

            /*
             
             if( left > me nad right > me ) 
                -1
             
             if( left < me and right < me ) 
                +1
             * 
             else 0
             * 
             *
             */

            for (int i = 0; i < treats.Count; i++)
            {
                if (i == 0 && treats.Count > 1)
                {
                    if (treats[i] > treats[i + 1])
                    {
                        result++;
                    }
                    else if (treats[i] < treats[i + 1])
                    {
                        result--;
                    }
                    else
                    {
                        //neighbor equal so result no change
                    }
                }
                //not the first or the last
                else if (i != treats.Count - 1)
                {
                    if (treats[i] < treats[i - 1] && treats[i] < treats[i + 1])
                    {
                        result--;
                    }
                    else if (treats[i] > treats[i - 1] && treats[i] > treats[i + 1])
                    {
                        result++;
                    }
                    else
                    {
                        //either one neighbor larger or smaller or both equal either way no result change

                    }
                }
                else
                {
                    //last treat
                    if (treats[i] > treats[i - 1])
                    {
                        result++;
                    }
                    else if (treats[i] < treats[i - 1])
                    {
                        result--;
                    }
                    else
                    {
                        //equal with neighbor so no effect on result
                    }
                }
            }

            return result;
        }
    }
}
