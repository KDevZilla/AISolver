using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.DFS.NVJap
{
    public class cRiverCrossingJapState
    {
        public Container Left
        {
            get
            {
                return Side[Container.enSide.Left];
            }
        }

        public Container Right
        {
            get
            {
                return Side[Container.enSide.Right];
            }

        }
        public Container Boat = new Container(2);
        //public cContainer Right = new cContainer(8);
        public Container.enSide IsOnSide = Container.enSide.Left;
        public Dictionary<Container.enSide, Container> Side = new Dictionary<Container.enSide, Container>();
        public cRiverCrossingJapState()
        {
            Side.Add(Container.enSide.Left, new Container(8));
            Side.Add(Container.enSide.Right, new Container(8));

        }
        public cRiverCrossingJapState Clone()
        {
            cRiverCrossingJapState New = new cRiverCrossingJapState();
            New.Side[Container.enSide.Left] = this.Side[Container.enSide.Left].Clone();
            New.Side[Container.enSide.Right] = this.Side[Container.enSide.Right].Clone();

            New.Boat = this.Boat.Clone();
            New.IsOnSide = this.IsOnSide;
            return New;
        }

        public string GetHashCode()
        {
            return Left.GetHashCode() + "_" +
                Boat.GetHashCode() + "_" +
                Right.GetHashCode() + "___" + IsOnSide.ToString();

        }
        public string LogInfo()
        {
            string SpaceLeft = "      ";
            String SpaceRight = "      ";
            if (IsOnSide == Container.enSide.Left)
            {

                SpaceLeft = "";
            }
            else
            {
                SpaceRight = "";
            }
            return

                "[" + Left.GetToString() + "]" + SpaceLeft +
                "<_" + Boat.GetToString() + "_>" + SpaceRight +
                "[" + Right.GetToString() + "]    ";
            //+GetHashCode();
        }
        public int Score
        {
            get
            {
                return Right.PeopleCount;
            }
        }

        public bool IsValid()
        {
            return Left.IsValidContainer() &&
                Boat.IsValidContainer() &&
                Right.IsValidContainer();


        }
    }
}
