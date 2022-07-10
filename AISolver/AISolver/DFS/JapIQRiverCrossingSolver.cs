using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AISolver.DFS.NVJap;

namespace AISolver.DFS
{
    public class JapIQRiverCrossingSolver : cBaseSolverManager<NVJap.cRiverCrossingJapState>
    {

        public override void GenerateChild(BNode<NVJap.cRiverCrossingJapState> CurrentNode)
        {

          

            if (!IsInitial)
            {
                InitialCustom(CurrentNode);
            }
            //  BNode<NodeValue.cRiverCrossingJapState> NewNode;
            int i;
            List<BNode<NVJap.cRiverCrossingJapState>> lst = new List<BNode<NVJap.cRiverCrossingJapState>>();

            //   cRiverCrossingJapState NewState = null;
            //    String strHashCode = "";
            Container.enSide CurrentSide;
            Container.enSide Opposite;
            if (CurrentNode.Value.IsOnSide == Container.enSide.Left)
            {
                CurrentSide = Container.enSide.Left;
                Opposite = Container.enSide.Right;
            }
            else
            {
                CurrentSide = Container.enSide.Right;
                Opposite = Container.enSide.Left;
            }
            // KeepLog("Current Side:" + CurrentSide.ToString());
            if (CurrentNode.Value.Boat.PeopleCount > 0)
            {
                ReleasePeopleFromBoat(CurrentNode, CurrentSide, Opposite, lst);
                //   KeepLog("     ReleaseFromBoat:" + lst.Count.ToString());
            }
            else
            {

                EnterBoat(CurrentNode, CurrentSide, Opposite, lst);
                //  KeepLog("     Enter Boat:" + lst.Count.ToString());

            }




            //lst.OrderBy(x => x.Value.Score);

            for (i = 0; i < lst.Count; i++)
            {
                CurrentNode.AddChild(lst[i]);
            }

        }

        public override void Initial()
        {
            throw new NotImplementedException();
        }

        private bool IsValidNewState(cRiverCrossingJapState NewState)
        {
            if (!NewState.IsValid())
            {
                return false;
            }

            String strHashCode = NewState.GetHashCode();
            if (IsVisisted(strHashCode))
            {
                return false;
            }


            return true;
        }

        private void AddNewState(List<BNode<NVJap.cRiverCrossingJapState>> plst, cRiverCrossingJapState NewState)
        {
            BNode<NVJap.cRiverCrossingJapState> NewNode = new BNode<NVJap.cRiverCrossingJapState>(NewState);

            plst.Add(NewNode);

            MarkVisited(NewNode.Value.GetHashCode());

        }

        private void ReleasePeopleFromBoat(BNode<NVJap.cRiverCrossingJapState> CurrentNode,
              Container.enSide CurrentSide,
          Container.enSide Opposite,
          List<BNode<NVJap.cRiverCrossingJapState>> lst)
        {
            cRiverCrossingJapState NewState = null;
            foreach (Container.enPeople First in Enum.GetValues(typeof(Container.enPeople)))
            {
                if (!CurrentNode.Value.Boat.DicPerson[First].IsOnContainer)
                {
                    continue;
                }

                if (CurrentNode.Value.Boat.PeopleCount == 2)
                {
                    foreach (Container.enPeople Second in Enum.GetValues(typeof(Container.enPeople)))
                    {

                        if (First == Second)
                        {
                            continue;
                        }
                        if (!CurrentNode.Value.Boat.DicPerson[Second].IsOnContainer)
                        {
                            continue;
                        }

                        NewState = CurrentNode.Value.Clone();

                        NewState.Side[CurrentSide].Enter(First);
                        NewState.Side[CurrentSide].Enter(Second);
                        NewState.Boat.Release(First);
                        NewState.Boat.Release(Second);
                        if (!IsValidNewState(NewState))
                        {
                            continue;
                        }
                        //NewState.IsOnSide = Opposite;
                        AddNewState(lst, NewState);
                    }
                }
                else
                {
                    if (First == Container.enPeople.Mom &&
                        CurrentSide == Container.enSide.Left)
                    {
                        string Remark = "";
                    }
                    NewState = CurrentNode.Value.Clone();

                    NewState.Side[CurrentSide].Enter(First);
                    NewState.Boat.Release(First);
                    if (!IsValidNewState(NewState))
                    {
                        continue;
                    }
                    // NewState.IsOnSide = Opposite;
                    AddNewState(lst, NewState);
                }
            }
        }
        private void EnterBoat(BNode<NVJap.cRiverCrossingJapState> CurrentNode,
                NVJap.Container.enSide CurrentSide,
            NVJap.Container.enSide Opposite,
            List<BNode<NVJap.cRiverCrossingJapState>> lst)
        {
            cRiverCrossingJapState NewState = null;
            foreach (Container.enPeople First in Enum.GetValues(typeof(Container.enPeople)))
            {
                if (!CurrentNode.Value.Side[CurrentSide].DicPerson[First].IsOnContainer)
                {
                    continue;
                }
                if (!Container.IsCapableOfControlBoat(First))
                {
                    continue;
                }

                foreach (Container.enPeople Second in Enum.GetValues(typeof(Container.enPeople)))
                {

                    if (First == Second)
                    {
                        continue;
                    }
                    if (!CurrentNode.Value.Side[CurrentSide].DicPerson[Second].IsOnContainer)
                    {
                        continue;
                    }
                    if (First == Container.enPeople.Cop &&
                        Second == Container.enPeople.Robber &&
                        CurrentSide == Container.enSide.Right)
                    {
                        string Remark = "";
                    }
                    NewState = CurrentNode.Value.Clone();

                    NewState.Side[CurrentSide].Release(First);
                    NewState.Side[CurrentSide].Release(Second);
                    NewState.Boat.Enter(First);
                    NewState.Boat.Enter(Second);
                    NewState.IsOnSide = Opposite;
                    if (!IsValidNewState(NewState))
                    {
                        continue;
                    }
                    AddNewState(lst, NewState);
                }

                NewState = CurrentNode.Value.Clone();
                NewState.Side[CurrentSide].Release(First);
                NewState.Boat.Enter(First);
                NewState.IsOnSide = Opposite;
                if (!IsValidNewState(NewState))
                {
                    continue;
                }
                AddNewState(lst, NewState);

            }

        }
        private StringBuilder strBLog = new StringBuilder();
        private void KeepLog(String str)
        {
            strBLog.Append(str).Append(Environment.NewLine);
        }
        public string GetLog()
        {
            return strBLog.ToString();
        }
        public void InitialCustom(BNode<NVJap.cRiverCrossingJapState> CurrentNode)
        {
            if (IsInitial)
            {
                return;
            }

            //CurrentNode.Value = new cState();

            CurrentNode.Value.Left.Enter(Container.enPeople.Dad);
            CurrentNode.Value.Left.Enter(Container.enPeople.Mom);
            CurrentNode.Value.Left.Enter(Container.enPeople.Daughter1);
            CurrentNode.Value.Left.Enter(Container.enPeople.Daughter2);
            CurrentNode.Value.Left.Enter(Container.enPeople.Son1);
            CurrentNode.Value.Left.Enter(Container.enPeople.SOn2);
            CurrentNode.Value.Left.Enter(Container.enPeople.Cop);
            CurrentNode.Value.Left.Enter(Container.enPeople.Robber);

            IsInitial = true;
        }

        int iCountLoop = 0;

        public string Solution(BNode<NVJap.cRiverCrossingJapState> CurrentNode)
        {
            StringBuilder strB = new StringBuilder();
            BNode<NVJap.cRiverCrossingJapState> Parent = CurrentNode;
            while (Parent != null)
            {
                strB.Insert(0, Environment.NewLine + Parent.Value.LogInfo());
                Parent = Parent.Parent;
            }
            return "iCountLoop:" + iCountLoop.ToString() +
                Environment.NewLine + strB.ToString();
        }
        public override bool IsSolve(BNode<NVJap.cRiverCrossingJapState> CurrentNode)
        {

            if (CurrentNode.Value.Right.PeopleCount == 8)
            {
                ResultDetail = Solution(CurrentNode);

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
