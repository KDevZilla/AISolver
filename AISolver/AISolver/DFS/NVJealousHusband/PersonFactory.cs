using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.DFS.NVJealousHusband
{
    class PersonFactory
    {
        public static Person Create(Container.enPeople e)
        {
            Person c = new Person();
            switch (e)
            {
                case Container.enPeople.Husband1:
                    c = new Person("Husband 1", false, "H1");

                    break;
                case Container.enPeople.Husband2:
                    c = new Person("Husband 2", false, "H2");

                    break;
                case Container.enPeople.Husband3:
                    c = new Person("Husband 3", false, "H3");

                    break;
                case Container.enPeople.Wife1:
                    c = new Person("Wife 1", false, "W1");

                    break;
                case Container.enPeople.Wife2:
                    c = new Person("Wife 2", false, "W2");

                    break;
                case Container.enPeople.Wife3:
                    c = new Person("Wife 3", false, "W3");

                    break;

            }
            return c;
        }
    }
}

