using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.DFS.NV3Lions
{
    public class RiverCrossing3Lions
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
        public RiverCrossing3Lions()
        {
            Side.Add(Container.enSide.Left, new Container(6));
            Side.Add(Container.enSide.Right, new Container(6));

        }
        public RiverCrossing3Lions Clone()
        {
            RiverCrossing3Lions New = new RiverCrossing3Lions();
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
            string SpaceLeft = "           ";
            String SpaceRight = "           ";
            bool IsFromRighToLeft = true;
            string strLogInfo = "";
            if (IsFromRighToLeft)
            {
                if (IsOnSide == Container.enSide.Left)
                {

                    SpaceLeft = "";
                }
                else
                {
                    SpaceRight = "";
                }

                strLogInfo = "[" + Right.GetToString() + "]" + SpaceRight +
                        "<_" + Boat.GetToString() + "_>" + SpaceLeft +
                        "[" + Left.GetToString() + "]";
            }
            else
            {
                if (IsOnSide == Container.enSide.Left)
                {

                    SpaceLeft = "";
                }
                else
                {
                    SpaceRight = "";
                }

                strLogInfo = "[" + Left.GetToString() + "]" + SpaceLeft +
               "<_" + Boat.GetToString() + "_>" + SpaceRight +
               "[" + Right.GetToString() + "]    ";
            }
            return strLogInfo;


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


