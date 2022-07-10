using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.BreathFirst
{
    public abstract class CarryWater
    {
        protected int _MaximumLitre = 0;
        public int MaximumLitre
        {
            get { return _MaximumLitre; }
        }
        public int ID
        {
            get { return _MaximumLitre; }
        }
        public CarryWater(int pMaximumLitre)
        {
            _MaximumLitre = pMaximumLitre;
        }
        public void InitialLitre(int pLitre)
        {
            _Litre = pLitre;
        }
        private int _Litre = 0;
        public int Litre
        {
            get { return _Litre; }
        }
        public override string ToString()
        {
            return "Litre:" + Litre.ToString();
        }
        public int AvilableSpaceToTakeWater
        {
            get { return _MaximumLitre - _Litre; }
        }
        public bool IsEmpty
        {
            get { return (_Litre == 0); }
        }
        public bool IsFull
        {
            get { return (_Litre == _MaximumLitre); }
        }

        public string GetInfo()
        {
            StringBuilder strB = new StringBuilder();
            strB.Append("Max:").Append(MaximumLitre.ToString())
                .Append(Environment.NewLine)
                .Append("Ligre:").Append(Litre.ToString())
                .Append(Environment.NewLine)
                .Append("Avilable:").Append(AvilableSpaceToTakeWater.ToString())
                .Append(Environment.NewLine);
            return strB.ToString();

        }
        public bool CanMoveWaterTo(CarryWater AnotherBucket)
        {
            if (this.IsEmpty)
            {
                return false;
            }
            if (AnotherBucket.IsFull)
            {
                return false;
            }
            return true;
        }
        public void MoveWaterTo(CarryWater AnotherBucket)
        {
            int NumberOFFreeSpace = AnotherBucket.AvilableSpaceToTakeWater;
            int MoveLitre = 0;


            if (NumberOFFreeSpace < _Litre)
            {
                MoveLitre = NumberOFFreeSpace;
            }
            else
            {
                MoveLitre = _Litre;

            }

            _Litre -= MoveLitre;
            AnotherBucket._Litre = AnotherBucket._Litre + MoveLitre;

            //TBucket._Litre = TBucket._Litre ;

        }
        public virtual bool CanFetch
        {
            get { return true; }
        }
        protected abstract void FetchFrom(CarryWater c);

    }
}
