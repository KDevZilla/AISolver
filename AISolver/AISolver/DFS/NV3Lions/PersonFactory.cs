using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.DFS.NV3Lions
{
    class PersonFactory
    {
        public static Person Create(Container.enPeople e)
        {
            Person c = new Person();
            switch (e)
            {
                case Container.enPeople.Lion1:
                    c = new Person("Lion 1", false, "H1");

                    break;
                case Container.enPeople.Lion2:
                    c = new Person("Lion 2", false, "H2");

                    break;
                case Container.enPeople.Lion3:
                    c = new Person("Lion 3", false, "H3");

                    break;
                case Container.enPeople.Sheep1:
                    c = new Person("Sheep 1", false, "W1");

                    break;
                case Container.enPeople.Sheep2:
                    c = new Person("Sheep 2", false, "W2");

                    break;
                case Container.enPeople.Sheep3:
                    c = new Person("Sheep 3", false, "W3");

                    break;

            }
            return c;
        }
    }
}
