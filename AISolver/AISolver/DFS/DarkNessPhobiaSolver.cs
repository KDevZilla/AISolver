using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.DFS
{
    class DarkNessPhobiaSolver : cBaseSolverManager<BDarkNessPhobiaTable>
    {

        public override void GenerateChild(BNode<BDarkNessPhobiaTable> CurrentNode)
        {
            if (CurrentNode.Value.SumTimeTake > 12)
            {
                return;
            }
            if (!IsInitial)
            {
                InitialCustom(CurrentNode);
            }
            int i;
            int j;
            HashSet<string> HavTried = new HashSet<string>();
            List<BNode<BDarkNessPhobiaTable>> lstNewNode = new List<BNode<BDarkNessPhobiaTable>>();
            if (CurrentNode.Value.CandleIsOn == BDarkNessPhobiaTable.enSide.Left)
            {
                HavTried = new HashSet<string>();
                foreach (string Name in CurrentNode.Value.LeftSide.Keys)
                {
                    foreach (string Name2 in CurrentNode.Value.LeftSide.Keys)
                    {
                        if (Name == Name2)
                        {
                            continue;
                        }
                        if (HavTried.Contains(Name + "_" + Name2) ||
                            HavTried.Contains(Name2 + "_" + Name))
                        {
                            continue;
                        }
                        if (CurrentNode.Value.CanMove(Name, Name2, BDarkNessPhobiaTable.enSide.Left))
                        {
                            HavTried.Add(Name + "_" + Name2);
                            HavTried.Add(Name2 + "_" + Name);

                            BDarkNessPhobiaTable NewTable = new BDarkNessPhobiaTable();
                            NewTable = CurrentNode.Value.Clone();
                            NewTable.Move(Name, Name2, BDarkNessPhobiaTable.enSide.Left);
                            BNode<BDarkNessPhobiaTable> NewNode = new BNode<BDarkNessPhobiaTable>(NewTable);
                            CurrentNode.AddChild(NewNode);
                        }

                    }

                    if (CurrentNode.Value.CanMove(Name, BDarkNessPhobiaTable.enSide.Left))
                    {
                        BDarkNessPhobiaTable NewTable = new BDarkNessPhobiaTable();
                        NewTable = CurrentNode.Value.Clone();
                        NewTable.Move(Name, BDarkNessPhobiaTable.enSide.Left);
                        BNode<BDarkNessPhobiaTable> NewNode = new BNode<BDarkNessPhobiaTable>(NewTable);
                        CurrentNode.AddChild(NewNode);

                    }
                }
            }
            else
            {
                HavTried = new HashSet<string>();
                int iLeastTimeTake = int.MaxValue;
                string NameofTheFast = "";
                foreach (string Name in CurrentNode.Value.RightSide.Keys)
                {
                    if (CurrentNode.Value.RightSide[Name].TimeTake < iLeastTimeTake)
                    {
                        NameofTheFast = Name;
                        iLeastTimeTake = CurrentNode.Value.RightSide[Name].TimeTake;
                    }

                }


                if (CurrentNode.Value.CanMove(NameofTheFast, BDarkNessPhobiaTable.enSide.Right))
                {
                    BDarkNessPhobiaTable NewTable = new BDarkNessPhobiaTable();
                    NewTable = CurrentNode.Value.Clone();
                    NewTable.Move(NameofTheFast, BDarkNessPhobiaTable.enSide.Right);
                    BNode<BDarkNessPhobiaTable> NewNode = new BNode<BDarkNessPhobiaTable>(NewTable);
                    CurrentNode.AddChild(NewNode);

                }

            }
        }

        public override void Initial()
        {
            throw new NotImplementedException();
        }

        public void InitialCustom(BNode<BDarkNessPhobiaTable> CurrentNode)
        {
            if (IsInitial)
            {
                return;
            }
            CurrentNode.Value.LeftSide.Add("Dad", new BFamilyMember("Dad", 1));
            CurrentNode.Value.LeftSide.Add("Mom", new BFamilyMember("Mom", 2));
            CurrentNode.Value.LeftSide.Add("Son", new BFamilyMember("Son", 4));
            CurrentNode.Value.LeftSide.Add("Daughter", new BFamilyMember("Daughter", 5));
            CurrentNode.Value.CandleIsOn = BDarkNessPhobiaTable.enSide.Left;
            IsInitial = true;


        }
        private string GetSolution(BNode<BDarkNessPhobiaTable> CurrentNode)
        {
            StringBuilder strB = new StringBuilder();
            strB.Append(GetString(CurrentNode));

            while (CurrentNode.Parent != null)
            {
                CurrentNode = CurrentNode.Parent;
                strB.Insert(0, GetString(CurrentNode) + Environment.NewLine);
            }
            return strB.ToString();
        }
        private String GetString(BNode<BDarkNessPhobiaTable> CurrentNode)
        {
            int i;
            int j;
            StringBuilder strB = new StringBuilder();
            foreach (string Name in CurrentNode.Value.LeftSide.Keys)
            {
                strB.Append(Name);
                strB.Append(",");
            }
            strB.Append("                          ");
            foreach (string Name in CurrentNode.Value.RightSide.Keys)
            {
                strB.Append(Name);
                strB.Append(",");
            }
            strB.Append("   [").Append(CurrentNode.Value.TimeTakeForThisMove.ToString()).Append("]");

            return strB.ToString();
        }

        public override bool IsSolve(BNode<BDarkNessPhobiaTable> CurrentNode)
        {
            if (IsSolved)
            {
                return IsSolved;
            }

            if (CurrentNode.Value.RightSide.Count == 4 &&
                CurrentNode.Value.SumTimeTake <= 12)
            {
                ResultDetail = GetSolution(CurrentNode);
                IsSolved = true;
            }

            return IsSolved;
        }

        protected override void LogResult(string str)
        {
            throw new NotImplementedException();
        }
    }
}

