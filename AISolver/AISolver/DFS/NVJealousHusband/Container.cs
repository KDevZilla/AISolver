using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.DFS.NVJealousHusband
{
    public class Container
    {
        public static bool IsCapableOfControlBoat(enPeople e)
        {
            return true;
        }
        public enum enPeople
        {
            Husband1,
            Husband2,
            Husband3,
            Wife1,
            Wife2,
            Wife3
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

            if (IsAtLeastOneOn(enPeople.Wife1) &&
                IsAtLeastOneOn(enPeople.Husband2, enPeople.Husband3) &&
                !IsAtLeastOneOn(enPeople.Husband1))
            {
                return false;
            }
            if (IsAtLeastOneOn(enPeople.Wife2) &&
                IsAtLeastOneOn(enPeople.Husband1, enPeople.Husband3) &&
                !IsAtLeastOneOn(enPeople.Husband2))
            {
                return false;
            }
            if (IsAtLeastOneOn(enPeople.Wife3) &&
                IsAtLeastOneOn(enPeople.Husband1, enPeople.Husband2) &&
                !IsAtLeastOneOn(enPeople.Husband3))
            {
                return false;
            }
            /*
            if (MaxPeople == 2)
            {
                if (PeopleCount > 0)
                {
                    if (!(IsAtLeastOneOn(enPeople.Mom, enPeople.Dad, enPeople.Cop)))
                    {
                        return false;
                    }
                }
            }
             */
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
                strB.Append(IsPersonon(DicPerson[i].IsOnContainer, DicPerson[i].ShortName));


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



