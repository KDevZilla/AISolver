using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AISolver.DFS.NVJealousHusband;
namespace AISolver.DFS
{
    class JealousHBSolver : cBaseSolverManager<NVJealousHusband.RiverCrossingJH>
    {

        public override void GenerateChild(BNode<NVJealousHusband.RiverCrossingJH> CurrentNode)
        {

            if (!IsInitial)
            {
                InitialCustom(CurrentNode);
            }
            //  BNode<NodeValue.cRiverCrossingJH> NewNode;
            int i;
            List<BNode<NVJealousHusband.RiverCrossingJH>> lst = new List<BNode<NVJealousHusband.RiverCrossingJH>>();

            //   cRiverCrossingJH NewState = null;
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

        private bool IsValidNewState(RiverCrossingJH NewState)
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

        private void AddNewState(List<BNode<NVJealousHusband.RiverCrossingJH>> plst, RiverCrossingJH NewState)
        {
            BNode<NVJealousHusband.RiverCrossingJH> NewNode = new BNode<NVJealousHusband.RiverCrossingJH>(NewState);

            plst.Add(NewNode);

            MarkVisited(NewNode.Value.GetHashCode());

        }

        private void ReleasePeopleFromBoat(BNode<NVJealousHusband.RiverCrossingJH> CurrentNode,
              Container.enSide CurrentSide,
          Container.enSide Opposite,
          List<BNode<NVJealousHusband.RiverCrossingJH>> lst)
        {
            RiverCrossingJH NewState = null;
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
        private void EnterBoat(BNode<NVJealousHusband.RiverCrossingJH> CurrentNode,
                NVJealousHusband.Container.enSide CurrentSide,
            NVJealousHusband.Container.enSide Opposite,
            List<BNode<NVJealousHusband.RiverCrossingJH>> lst)
        {
            RiverCrossingJH NewState = null;
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
        public void InitialCustom(BNode<NVJealousHusband.RiverCrossingJH> CurrentNode)
        {
            if (IsInitial)
            {
                return;
            }

            //CurrentNode.Value = new cState();

            CurrentNode.Value.Left.Enter(Container.enPeople.Husband1);
            CurrentNode.Value.Left.Enter(Container.enPeople.Husband2);
            CurrentNode.Value.Left.Enter(Container.enPeople.Husband3);
            CurrentNode.Value.Left.Enter(Container.enPeople.Wife1);
            CurrentNode.Value.Left.Enter(Container.enPeople.Wife2);
            CurrentNode.Value.Left.Enter(Container.enPeople.Wife3);


            IsInitial = true;
        }

        int iCountLoop = 0;

        public string Solution(BNode<NVJealousHusband.RiverCrossingJH> CurrentNode)
        {
            StringBuilder strB = new StringBuilder();
            BNode<NVJealousHusband.RiverCrossingJH> Parent = CurrentNode;
            while (Parent != null)
            {
                strB.Insert(0, Environment.NewLine + Parent.Value.LogInfo());
                Parent = Parent.Parent;
            }
            return "iCountLoop:" + iCountLoop.ToString() +
                Environment.NewLine + strB.ToString();
        }
        public override bool IsSolve(BNode<NVJealousHusband.RiverCrossingJH> CurrentNode)
        {

            if (CurrentNode.Value.Right.PeopleCount == 6)
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
