using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.BreathFirst
{
    public class Bucket : CarryWater
    {

        public Bucket(int pMaximumLitre) : base(pMaximumLitre)
        {
            _MaximumLitre = pMaximumLitre;

        }

        public Bucket(int pMaximumLitre, bool IsWell)
            : base(pMaximumLitre)
        {
            _MaximumLitre = pMaximumLitre;
            if (IsWell)
            {
                InitialLitre(_MaximumLitre);
            }

        }
        protected override void FetchFrom(CarryWater c)
        {

            if (!c.CanFetch)
            {
                throw new Exception("Cannot fetch from unfetch able Object such as Well");
            }


            c.MoveWaterTo(this);


            //throw new NotImplementedException();
        }
    }
}
