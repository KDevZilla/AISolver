using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.BreathFirst
{
    public class BucketSystem
    {
        /*
        private cBucket _B1 = new cBucket(1);
        private cBucket _B4 = new cBucket(4);
        
        public cBucket B1 { get { return _B1; } }
        public cBucket B4 { get { return _B4; } }
        */
        public string GetInfo2()
        {
            int i;
            StringBuilder strB = new StringBuilder();
            strB.Append("ID:").Append(this.ID).Append(Environment.NewLine);
            strB.Append(_LogProcessMessage);
            strB.Append("Well:").Append(Well.Litre.ToString()).Append(Environment.NewLine);
            for (i = 1; i < Lst.Count; i++)
            {
                strB.Append("B[").Append(Lst[i].ID).Append("]").Append(Lst[i].Litre.ToString()).Append(Environment.NewLine);
            }
            strB.Append("   Score:").Append(Score.ToString()).Append(Environment.NewLine);
            strB.Append("==================================");
            return strB.ToString();
        }

        public string GetInfo()
        {
            int i;
            StringBuilder strB = new StringBuilder();
            //   strB.Append("ID:").Append(this.ID).Append(Environment.NewLine);
            strB.Append(_LogProcessMessage);
            //  strB.Append("Well:").Append(Well.Litre.ToString()).Append(Environment.NewLine);

            for (i = 1; i < Lst.Count; i++)
            {
                strB.Append("B[").Append(Lst[i].ID).Append("]").Append(Lst[i].Litre.ToString()).Append(Environment.NewLine);
            }
            //   strB.Append("   Score:").Append(Score.ToString()).Append(Environment.NewLine);
            strB.Append("==================================");
            return strB.ToString();
        }
        public Bucket Well { get { return _lst[0]; } }
        private List<Bucket> _lst = new List<Bucket>();
        public List<Bucket> Lst
        {
            get { return _lst; }
        }
        private int _LitreGoal = 0;
        private int LitreGoal
        {
            get { return _LitreGoal; }
        }
        private void InitialBucket(params int[] arrBucket)
        {
            int i = 0;
            Array.Sort(arrBucket);
            Array.Reverse(arrBucket);
            for (i = 0; i < arrBucket.Length; i++)
            {
                _lst.Add(new Bucket(arrBucket[i]));

            }
            //_lst = _lst.OrderBy(o => o.MaximumLitre).ToList();
        }

        private Dictionary<int, Bucket> _Dic = null;
        private string _ID = "";
        public void setID(string pID)
        {
            _ID = pID;
        }
        public string ID
        {
            get { return _ID; }
        }
        public Bucket GetBySizeOfBucket(int iSize)
        {
            if (_Dic == null)
            {
                _Dic = new Dictionary<int, Bucket>();
            }
            if (!_Dic.ContainsKey(iSize))
            {
                int i;
                for (i = 0; i < _lst.Count; i++)
                {
                    if (_lst[i].MaximumLitre == iSize)
                    {
                        _Dic.Add(iSize, _lst[i]);
                        break;
                    }
                }
            }

            return _Dic[iSize];
        }
        int _Score = int.MinValue;
        private void ClearScore()
        {
            _Score = int.MinValue;
        }
        public int Score
        {
            get
            {
                if (_Score == int.MinValue)
                {
                    _Score = 0;
                    int i;
                    for (i = 1; i < Lst.Count; i++)
                    {
                        _Score += Lst[i].Litre;
                    }
                    _Score = _LitreGoal - Score;
                    if (_Score > 0)
                    {
                        _Score *= -1;
                    }
                }
                return _Score;

            }
        }
        public bool IsEqualWith(BucketSystem AnotherBucketSystem)
        {
            int i = 0;
            for (i = 1; i < this.Lst.Count; i++)
            {
                if (this.Lst[i].Litre != AnotherBucketSystem.Lst[i].Litre)
                {
                    return false;
                }
            }
            return true;
        }

        public BucketSystem(int pLitreofWaterInWell, int pLitreGoal, params int[] arrBucket)
        {

            Bucket MyWell = new Bucket(pLitreofWaterInWell, true);

            _lst.Add(MyWell);


            _LitreGoal = pLitreGoal;
            if (arrBucket != null)
            {
                if (arrBucket.Length > 0)
                {
                    this.InitialBucket(arrBucket);
                }
            }

        }
        public static BucketSystem CopyFrom(BucketSystem From)
        {
            BucketSystem NewBucketSystem = new BucketSystem(From.Well.MaximumLitre, From.LitreGoal);
            int i;
            for (i = 1; i < From.Lst.Count; i++)
            {
                Bucket newB = new Bucket(From.Lst[i].MaximumLitre);
                newB.InitialLitre(From.Lst[i].Litre);
                NewBucketSystem.Lst.Add(newB);
            }
            NewBucketSystem.Well.InitialLitre(From.Well.Litre);

            return NewBucketSystem;
        }
        /*
        public cBucketSystem Clone()
        {
            cBucketSystem MyClone = new cBucketSystem(Well.MaximumLitre,LitreGoal );
           

            return MyClone;
        }
         */
        private string _LogProcessMessage = "";
        private string LogProcessMessage
        {
            get { return _LogProcessMessage; }
        }
        private void LogProcess(string str)
        {
            _LogProcessMessage += str + Environment.NewLine;
        }
        public void Fetch(Bucket From, Bucket To)
        {
            string FromID = From.ID.ToString();
            string ToID = To.ID.ToString();

            if (FromID == "30")
            {
                FromID = "Well";
            }
            else
            {
                FromID = "Bucket[" + FromID + "]";
            }

            if (ToID == "30")
            {
                ToID = "Well";
            }
            else
            {
                ToID = "Bucket[" + ToID + "]";
            }
            LogProcess("Move From " + FromID + " to " + ToID);
            From.MoveWaterTo(To);
            this.ClearScore();
        }

        public void Fetch(int FromSize, int ToSize)
        {
            //LogProcess("Move From " +  + " to " + To.ID);
            Bucket From = this.GetBySizeOfBucket(FromSize);
            Bucket To = this.GetBySizeOfBucket(ToSize);
            Fetch(From, To);

        }
        public bool IsGoalReached()
        {
            int i;
            int iSum = 0;
            for (i = 1; i < _lst.Count; i++)
            {
                iSum += _lst[i].Litre;
                if (iSum > this.LitreGoal)
                {
                    return false;
                }
            }

            if (iSum != this.LitreGoal)
            {
                return false;
            }

            return true;
        }
    }
}
