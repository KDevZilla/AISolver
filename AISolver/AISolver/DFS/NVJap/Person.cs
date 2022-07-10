using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.DFS.NVJap
{
    public class Person
    {
        public string Name = "";
        public bool IsOnContainer = false;
        public string ShortName = "";
        public Person()
        {
        }
        public Person(string pName, bool pIsOnContainer, string pShotName)
        {
            Name = pName;
            IsOnContainer = pIsOnContainer;
            ShortName = pShotName;
        }
        public Person Clone()
        {
            Person NewPerson = new Person(this.Name, this.IsOnContainer, this.ShortName);
            return NewPerson;
        }
    }
}
