using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver
{
    public class Util
    {
        private static Random R = new Random();
        public static int GetRandom(int Min, int Max)
        {
            return R.Next(Min, Max);
        }
        public static bool IsNumeric(String valueCheck)
        {
            try
            {
                int.Parse(valueCheck);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
