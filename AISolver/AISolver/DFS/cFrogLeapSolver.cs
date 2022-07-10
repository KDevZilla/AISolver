using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.DFS
{
    class cFrogLeapSolver : cBaseSolverManager<string[]>
    {



        private string GetHashCode(string[] str)
        {
            StringBuilder strB = new StringBuilder();
            int i;
            for (i = 0; i < str.Length; i++)
            {
                if (str[i] == " ")
                {
                    strB.Append("   ");
                }
                else
                {
                    strB.Append(str[i]);
                }
            }
            return strB.ToString();
        }
        public override void GenerateChild(BNode<string[]> CurrentNode)
        {
            if (!IsInitial)
            {
                Initial();
            }
            int j;
            int i;
            int iLastPosition = CurrentNode.Value.Length - 1;
            int iFirstPosition = 0;

            for (i = 0; i < CurrentNode.Value.Length; i++)
            {
                string Frog = "";
                if (CurrentNode.Value[i] == " ")
                {
                    continue;
                }
                int Direction = 0;
                if (CurrentNode.Value[i] == "A")
                {
                    Frog = "A";
                    Direction = 1;
                }
                else
                {
                    Frog = "B";
                    Direction = -1;
                }

                int NextJumpPosition = i + Direction;
                if (NextJumpPosition <= iLastPosition &&
                    NextJumpPosition >= iFirstPosition)
                {
                    //  continue;
                    if (CurrentNode.Value[NextJumpPosition] == " ")
                    {
                        string[] NewMatrix = (string[])CurrentNode.Value.Clone();
                        NewMatrix[i] = " ";
                        NewMatrix[NextJumpPosition] = Frog;
                        if (!IsVisisted(GetHashCode(NewMatrix)))
                        {
                            //DFS.cNodeArray NewNode = new DFS.cNodeArray(NewMatrix);
                            CurrentNode.AddChild(NewMatrix);
                            MarkVisited(GetHashCode(NewMatrix));
                        }

                    }
                }


                int NextJumpOverPosition = i + (Direction * 2);
                if (NextJumpOverPosition <= iLastPosition &&
                    NextJumpOverPosition >= iFirstPosition)
                {
                    if (CurrentNode.Value[NextJumpPosition] != " " &&
                        CurrentNode.Value[NextJumpOverPosition] == " ")
                    {
                        //NextJumpPosition = i + Direction;
                        string[] NewMatrix = (string[])CurrentNode.Value.Clone();
                        NewMatrix[i] = " ";
                        NewMatrix[NextJumpOverPosition] = Frog;
                        if (!IsVisisted(GetHashCode(NewMatrix)))
                        {
                            CurrentNode.AddChild(NewMatrix);
                            MarkVisited(GetHashCode(NewMatrix));
                        }

                    }
                }


            }
        }

        public override void Initial()
        {
            // throw new NotImplementedException();
        }
        public string CustomTraveltoRoot(BNode<string[]> CurrentNode)
        {

            StringBuilder strB = new StringBuilder();
            strB.Append(GetHashCode(CurrentNode.Value));
            BNode<string[]> Par = CurrentNode.Parent;
            //            BNode<T> Par = this.Parent;
            while (Par != null)
            {
                strB.Insert(0, GetHashCode(Par.Value) + Environment.NewLine);
                Par = Par.Parent;
            }
            return strB.ToString();
        }
        public override bool IsSolve(BNode<string[]> CurrentNode)
        {

            if (
                   CurrentNode.Value[0] == "B" &&
                   CurrentNode.Value[1] == "B" &&
                   CurrentNode.Value[2] == "B" &&
                   CurrentNode.Value[4] == "A" &&
                   CurrentNode.Value[5] == "A" &&
                   CurrentNode.Value[6] == "A")

            {
                ResultDetail = CustomTraveltoRoot(CurrentNode);

                //ResultDetail = //GetDetailFromcNodeArray(CurrentNode);
                return true;
            }
            return false;
        }

        protected override void LogResult(string str)
        {
            throw new NotImplementedException();
        }
    }
}