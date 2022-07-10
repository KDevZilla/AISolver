using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.DFS.NV3Lions
{
    public class Container
    {
        public static bool IsCapableOfControlBoat(enPeople e)
        {
            return true;
        }
        public enum enPeople
        {
            Lion1,
            Lion2,
            Lion3,
            Sheep1,
            Sheep2,
            Sheep3
        }
        public enum enSide
        {
            Left,
            Right
        }
        /*
           foreach (enPeople  i in Enum.GetValues (typeof(enPeople )))
            {
                cPerson P = cPersonFactory.Create(i);
                DicPerson.Add(i, P);

            }
         */
        private bool IsAllOn(params enPeople[] eArr)
        {
            int i;
            for (i = 0; i < eArr.Length; i++)
            {
                if (!DicPerson[eArr[i]].IsOnContainer)
                    return false;
            }
            return true;
        }

        private bool IsAtLeastOneOn(params enPeople[] eArr)
        {
            int i;
            for (i = 0; i < eArr.Length; i++)
            {
                if (DicPerson[eArr[i]].IsOnContainer)
                    return true;
            }
            return false;
        }
        private bool IsAtLeastOneOff(params enPeople[] eArr)
        {
            int i;
            for (i = 0; i < eArr.Length; i++)
            {
                if (DicPerson[eArr[i]].IsOnContainer)
                    return false;
            }
            return true;
        }
        public bool IsValidContainer()
        {
            int iCountLion = 0;
            int iCountSheep = 0;
            if (DicPerson[enPeople.Lion1].IsOnContainer)
            {
                iCountLion++;
            }
            if (DicPerson[enPeople.Lion2].IsOnContainer)
            {
                iCountLion++;
            }
            if (DicPerson[enPeople.Lion3].IsOnContainer)
            {
                iCountLion++;
            }

            if (DicPerson[enPeople.Sheep1].IsOnContainer)
            {
                iCountSheep++;
            }
            if (DicPerson[enPeople.Sheep2].IsOnContainer)
            {
                iCountSheep++;
            }
            if (DicPerson[enPeople.Sheep3].IsOnContainer)
            {
                iCountSheep++;
            }
            if (iCountSheep > 0)
            {
                if (iCountLion > iCountSheep)
                {
                    return false;
                }
            }
            return true;
        }
        private string IsPersonon(bool Status, string Name)
        {
            if (Status)
            {
                return Name + ",";
            }
            return "";
        }

        public string GetHashCode()
        {
            StringBuilder strB = new StringBuilder();
            foreach (enPeople i in Enum.GetValues(typeof(enPeople)))
            {
                string ShortName = DicPerson[i].ShortName.Substring(0, 1);
                strB.Append(IsPersonon(DicPerson[i].IsOnContainer, ShortName));


            }

            return strB.ToString().Replace(",", "");
        }
        public string GetToString()
        {
            StringBuilder strB = new StringBuilder();
            foreach (enPeople i in Enum.GetValues(typeof(enPeople)))
            {
                strB.Append(IsPersonon(DicPerson[i].IsOnContainer, DicPerson[i].Name));


            }
            return strB.ToString();
        }

        public Dictionary<enPeople, Person> DicPerson = new Dictionary<enPeople, Person>();


        private int MaxPeople = 0;
        public Container Clone()
        {
            Container NewContainer = new Container(this.MaxPeople);
            NewContainer.PeopleCount = this.PeopleCount;

            foreach (enPeople i in Enum.GetValues(typeof(enPeople)))
            {
                NewContainer.DicPerson[i] = this.DicPerson[i].Clone();


            }
            return NewContainer;
        }
        private void SwitchTo(Person P, bool switchTo)
        {
            if (P.IsOnContainer == switchTo)
            {
                System.Diagnostics.Debug.Assert(P.IsOnContainer != switchTo);
            }
            P.IsOnContainer = switchTo;
        }
        public void Release(enPeople P)
        {
            SwitchTo(DicPerson[P], false);


            _PeopleCount--;

        }
        private int _PeopleCount = 0;
        public int PeopleCount
        {
            get
            {
                return _PeopleCount;
            }
            set
            {
                _PeopleCount = value;
            }
        }
        public void Enter(enPeople P)
        {
            if (_PeopleCount >= MaxPeople)
            {
                //   throw new Exception("We can handle only " + MaxPeople);
                String Error = "We can handle only " + MaxPeople;
            }
            _PeopleCount++;
            SwitchTo(DicPerson[P], true);

        }
        public Container(int pMaxPeople)
        {
            MaxPeople = pMaxPeople;

            foreach (enPeople i in Enum.GetValues(typeof(enPeople)))
            {
                Person P = PersonFactory.Create(i);
                DicPerson.Add(i, P);

            }


        }

    }
}


