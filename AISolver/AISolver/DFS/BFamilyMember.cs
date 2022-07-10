using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.DFS
{
    class BFamilyMember
    {
        public string Name = "";
        public int TimeTake = 0;
        public BFamilyMember Clone()
        {
            return new BFamilyMember(this.Name, this.TimeTake);
        }
        public BFamilyMember(string pName, int pTimeTake)
        {
            Name = pName;
            TimeTake = pTimeTake;

        }
    }
}

