using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.DFS.NVJap
{
    class PersonFactory
    {
        public static Person Create(Container.enPeople e)
        {
            Person c = new Person();
            switch (e)
            {
                case Container.enPeople.Dad:
                    c = new Person("Dad", false, "D");
                    break;
                case Container.enPeople.Mom:
                    c = new Person("Mom", false, "M");
                    break;
                case Container.enPeople.Daughter1:
                    c = new Person("Daughter1", false, "DA1");
                    break;
                case Container.enPeople.Daughter2:
                    c = new Person("Daughter2", false, "DA2");
                    break;
                case Container.enPeople.Son1:
                    c = new Person("Son1", false, "S1");
                    break;
                case Container.enPeople.SOn2:
                    c = new Person("Son2", false, "S2");
                    break;
                case Container.enPeople.Cop:
                    c = new Person("Cop", false, "C");
                    break;
                case Container.enPeople.Robber:
                    c = new Person("Robber", false, "R");
                    break;

            }
            return c;
        }
    }
}
