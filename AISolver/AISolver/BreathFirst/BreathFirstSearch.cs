using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.BreathFirst
{
    public class BreathFirstSearch
    {
        /*
        private void Add(cTreeBucketSystem Tree, cBucketSystem BChild,cCarryWater MainCarry,cCarryWater BeingFecthedBy)
        {
            cTreeBucketSystem child = new cTreeBucketSystem(BChild);
            MainCarry.MoveWaterTo(BeingFecthedBy);
            Tree.Nodes.Add(child);
        }
        */
        private TreeBucketSystem MainTree = null;

        private bool IsDuplicationWithOtherTree(TreeBucketSystem pMainTree, TreeBucketSystem CheckTree)
        {
            foreach (TreeBucketSystem Item in pMainTree.Nodes)
            {
                if (Item.HasChild)
                {
                    if (IsDuplicationWithOtherTree(Item, CheckTree))
                    {
                        return true;
                    }
                }
                else
                {
                    if (Item.Table.IsEqualWith(CheckTree.Table))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void AddNewChild(TreeBucketSystem Tree, int From, int To)
        {

            BucketSystem BucSystem = BucketSystem.CopyFrom(Tree.Table);
            TreeBucketSystem child = new TreeBucketSystem(BucSystem);
            string ID = "";

            ID = Tree.Table.ID + "." + (Tree.Nodes.Count + 1).ToString();

            child.Table.setID(ID);
            BucSystem.Fetch(From, To);

            if (!IsDuplicationWithOtherTree(MainTree, child))
            {
                Tree.Add(child);
            }
            //Tree.Nodes.Add(child);

        }
        private int MaxLoop = 10000;

        private void GenerateChildren(TreeBucketSystem Tree)
        {
            int i = 0;
            int j = 0;

            BucketSystem cB = Tree.Table;
            /*
            cBucket B4 = cB.GetBySizeOfBucket(4);
            cBucket B2 = cB.GetBySizeOfBucket(2);
            cBucket Well = cB.Well;
            */

            for (i = 0; i < cB.Lst.Count; i++)
            {
                Bucket FirstBucket = cB.Lst[i];
                for (j = 0; j < cB.Lst.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }


                    Bucket SecondBucket = cB.Lst[j];
                    if (FirstBucket.CanMoveWaterTo(SecondBucket))
                    {
                        AddNewChild(Tree, FirstBucket.ID, SecondBucket.ID);
                    }
                }
            }
            Tree.Sort();

            /*
            Tree.Nodes.Clear();
            Tree.Nodes.AddRange(Tree.Nodes.OrderBy(o => o.Table.Score).ToList());
             */
            //Tree.Nodes = Tree.Nodes.OrderBy(o => o.Table.Score).ToList();

            /*
            Tree.Nodes = Tree.Nodes.OrderBy (o=> o.Table.s
            objListOrder.OrderBy(o => o.OrderDate).ToList();
            */
        }
        private int LoopCount = 0;

        private void KeepSolution(TreeBucketSystem Tree)
        {
            StringBuilder strB = new StringBuilder();
            TreeBucketSystem cTemp = Tree;
            strB.Append("LoopCount:").Append(LoopCount.ToString()).Append(Environment.NewLine);
            strB.Append("========= Begin to Solve =======").Append(Environment.NewLine);
            Stack<String> MyStack = new Stack<string>();
            while (cTemp.HasParent)
            {
                MyStack.Push(cTemp.Table.GetInfo());
                //strB.Append(cTemp.Table.ShowValue());
                strB.Append(Environment.NewLine);
                cTemp = cTemp.Parent;
            }
            string strTemp = "";

            while (MyStack.Count > 0)
            {
                strB.Append(MyStack.Pop()).Append(Environment.NewLine);
            }
            strB.Append("========== End =========").Append(Environment.NewLine);
            _Solution = strB.ToString();

        }
        private string _Solution = "";
        public string Solution
        {
            get { return _Solution; }
        }
        public TreeBucketSystem BreathFirstSolve(TreeBucketSystem Tree)
        {
            MainTree = Tree;
            Queue<TreeBucketSystem> MyQueue = new Queue<TreeBucketSystem>();
            MyQueue.Enqueue(Tree);

            Tree.HasDiscovered = true;
            LoopCount = 0;
            while (MyQueue.Count > 0)
            {
                LoopCount++;
                if (LoopCount >= MaxLoop)
                {
                    return null;
                }
                Tree = MyQueue.Dequeue();
                //KeepSolution(Tree);
                //cWriteLog.WriteLog("   <== Get" + N.ToString());

                //   cWriteLog.WriteLog("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                int i;
                GenerateChildren(Tree);
                for (i = 0; i < Tree.Nodes.Count; i++)
                {

                    TreeBucketSystem child = Tree.Nodes[i];
                   // cWriteLog.WriteLog(child.Table.GetInfo());
                    //KeepSolution(child);
                    if (child.Table.IsGoalReached())
                    {
                      //  cWriteLog.WriteLog("Found");
                        KeepSolution(child);
                        return child;
                    }
                    /*
                    if (IsSolved(child))
                    {
                        
                    }
                    */

                    if (!child.HasDiscovered)
                    {
                        //cWriteLog.WriteLog(child.Tab + " Has not Discovered Yet");
                        //cWriteLog.WriteLog(child.Tab + "   Push ==>" + child.ToString());
                        MyQueue.Enqueue(child);
                        child.HasDiscovered = true;
                    }
                    else
                    {
                        //cWriteLog.WriteLog(child. + " Has Discovered");
                    }
                }
            }
            return null;
        }
    }
}