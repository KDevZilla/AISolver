using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AISolver.DFS.NV3Lions;
namespace AISolver.DFS
{
    class c3LionsSolver : cBaseSolverManager<NV3Lions.RiverCrossing3Lions>
    {

        public override void GenerateChild(BNode<NV3Lions.RiverCrossing3Lions> CurrentNode)
        {

            if (!IsInitial)
            {
                InitialCustom(CurrentNode);
            }
            //  BNode<NodeValue.cRiverCrossing3Lions> NewNode;
            int i;
            List<BNode<NV3Lions.RiverCrossing3Lions>> lst = new List<BNode<NV3Lions.RiverCrossing3Lions>>();

            //   cRiverCrossing3Lions NewState = null;
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

        private bool IsValidNewState(RiverCrossing3Lions NewState)
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

        private void AddNewState(List<BNode<NV3Lions.RiverCrossing3Lions>> plst, RiverCrossing3Lions NewState)
        {
            BNode<NV3Lions.RiverCrossing3Lions> NewNode = new BNode<NV3Lions.RiverCrossing3Lions>(NewState);

            plst.Add(NewNode);

            MarkVisited(NewNode.Value.GetHashCode());

        }

        private void ReleasePeopleFromBoat(BNode<NV3Lions.RiverCrossing3Lions> CurrentNode,
              Container.enSide CurrentSide,
          Container.enSide Opposite,
          List<BNode<NV3Lions.RiverCrossing3Lions>> lst)
        {
            RiverCrossing3Lions NewState = null;
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
        private void EnterBoat(BNode<NV3Lions.RiverCrossing3Lions> CurrentNode,
                NV3Lions.Container.enSide CurrentSide,
            NV3Lions.Container.enSide Opposite,
            List<BNode<NV3Lions.RiverCrossing3Lions>> lst)
        {
            RiverCrossing3Lions NewState = null;
            if (CurrentNode.Value.IsOnSide == Container.enSide.Right)
            {
                string strTest = "Hello";
            }
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
        public void InitialCustom(BNode<NV3Lions.RiverCrossing3Lions> CurrentNode)
        {
            if (IsInitial)
            {
                return;
            }

            //CurrentNode.Value = new cState();

            CurrentNode.Value.Left.Enter(Container.enPeople.Lion1);
            CurrentNode.Value.Left.Enter(Container.enPeople.Lion2);
            CurrentNode.Value.Left.Enter(Container.enPeople.Lion3);
            CurrentNode.Value.Left.Enter(Container.enPeople.Sheep1);
            CurrentNode.Value.Left.Enter(Container.enPeople.Sheep2);
            CurrentNode.Value.Left.Enter(Container.enPeople.Sheep3);


            IsInitial = true;
        }

        int iCountLoop = 0;

        public string Solution(BNode<NV3Lions.RiverCrossing3Lions> CurrentNode)
        {
            StringBuilder strB = new StringBuilder();
            BNode<NV3Lions.RiverCrossing3Lions> Parent = CurrentNode;
            while (Parent != null)
            {
                strB.Insert(0, Environment.NewLine + Parent.Value.LogInfo());
                Parent = Parent.Parent;
            }
            return "iCountLoop:" + iCountLoop.ToString() +
                Environment.NewLine + strB.ToString();
        }
        int iClosestSolutionValue = 0;
        public string ClosestSolutionDetail = "";
        public override bool IsSolve(BNode<NV3Lions.RiverCrossing3Lions> CurrentNode)
        {
            if (CurrentNode.Value.Right.PeopleCount > iClosestSolutionValue)
            {
                iClosestSolutionValue = CurrentNode.Value.Right.PeopleCount;
                ClosestSolutionDetail = Solution(CurrentNode);
            }

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
