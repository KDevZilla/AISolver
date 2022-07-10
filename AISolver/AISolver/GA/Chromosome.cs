using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.GA
{
    public class Chromosome
    {
        public int FitnesValue = 0;
        public Chromosome Clone()
        {
            Chromosome c = new Chromosome();
            List<int> NewList = new List<int>(this.lst);
            c.lst = NewList;
            c.FitnesValue = this.FitnesValue;
            return c;
        }
        public List<int> lst = new List<int>();

        public void OrderlstFromMaxToMin()
        {
            lst = lst.OrderByDescending(p => p).ToList();


        }
        public int GetSum()
        {
            int i;
            int iSum = 0;
            List<int> l = lst.ToList();
            for (i = 0; i < l.Count; i++)
            {
                iSum += l[i];
            }
            return iSum;
        }

        public string GetDetail()
        {
            StringBuilder strB = new StringBuilder();
            int i;
            strB.Append("FitnessValue:").Append(FitnesValue.ToString()).Append("\n")
                .Append("Sum:").Append(GetSum().ToString()).Append("\n")
                .Append(" ").Append(Environment.NewLine);
            OrderlstFromMaxToMin();
            for (i = 0; i < lst.Count; i++)
            {
                strB.Append(lst[i].ToString());
                if (i < lst.Count - 1)
                {
                    strB.Append(",");
                }
                else
                {
                    strB.Append("\n");
                }
            }
            strB.Append(Environment.NewLine);
            strB.Append("=================================");
            return strB.ToString();
        }
    }
}
