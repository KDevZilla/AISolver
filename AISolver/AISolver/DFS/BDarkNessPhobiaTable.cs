using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.DFS
{
    class BDarkNessPhobiaTable
    {
        public enSide CandleIsOn = enSide.Left;
        private int _SumTimeTakes = 0;
        public int SumTimeTake
        {
            get
            {
                return _SumTimeTakes;
            }
        }
        public BDarkNessPhobiaTable Clone()
        {
            BDarkNessPhobiaTable NewTable = new BDarkNessPhobiaTable();
            int i;
            foreach (string strName in LeftSide.Keys)
            {

                NewTable.LeftSide.Add(strName, LeftSide[strName].Clone());
            }

            foreach (string strName in RightSide.Keys)
            {

                NewTable.RightSide.Add(strName, RightSide[strName].Clone());
            }
            NewTable.CandleIsOn = this.CandleIsOn;
            NewTable._SumTimeTakes = this.SumTimeTake;
            return NewTable;
        }
        public Dictionary<string, BFamilyMember> LeftSide = new Dictionary<string, BFamilyMember>();
        public Dictionary<string, BFamilyMember> RightSide = new Dictionary<string, BFamilyMember>();
        public enum enSide
        {
            Left,
            Right
        }

        public bool CanMove(string Member, enSide From)
        {
            if (CandleIsOn != From)
            {
                return false;
            }

            if (CandleIsOn == enSide.Left)
            {
                if (!LeftSide.ContainsKey(Member))
                {
                    return false;
                }
            }
            if (CandleIsOn == enSide.Right)
            {
                if (!RightSide.ContainsKey(Member))
                {
                    return false;
                }
            }
            return true;
        }
        private int _TimeTakeForMove = 0;
        public int TimeTakeForThisMove
        {
            get
            {
                return _TimeTakeForMove;
            }
        }
        public bool CanMove(string Member, string AndMember, enSide From)
        {
            if (CandleIsOn != From)
            {
                return false;
            }

            if (CandleIsOn == enSide.Left)
            {
                if (!(LeftSide.ContainsKey(Member) &&
                      LeftSide.ContainsKey(AndMember))
                    )
                {
                    return false;
                }
            }
            if (CandleIsOn == enSide.Right)
            {
                if (!RightSide.ContainsKey(Member) &&
                      RightSide.ContainsKey(AndMember))
                {
                    return false;
                }
            }
            return true;
        }
        public int Move(string Member, enSide From)
        {
            int TimeTake = InternalMove(Member, From);
            _TimeTakeForMove = TimeTake;
            _SumTimeTakes += TimeTake;
            SwitchCandleSide();
            return TimeTake;
        }
        private int InternalMove(string Member, enSide From)
        {
            BFamilyMember M = null;
            if (From == enSide.Left)
            {
                M = LeftSide[Member];
                LeftSide.Remove(Member);
                RightSide.Add(Member, M);
            }
            else
            {
                M = RightSide[Member];
                RightSide.Remove(Member);
                LeftSide.Add(Member, M);
            }
            return M.TimeTake;
        }
        private void SwitchCandleSide()
        {
            if (CandleIsOn == enSide.Left)
            {
                CandleIsOn = enSide.Right;
            }
            else
            {
                CandleIsOn = enSide.Left;
            }
        }
        public int Move(string Member, string andMember, enSide From)
        {
            int TimeTakeFirstMember = 0;
            int TimeTakeSecondMember = 0;

            TimeTakeFirstMember = InternalMove(Member, From);
            TimeTakeSecondMember = InternalMove(andMember, From);
            SwitchCandleSide();

            if (TimeTakeFirstMember > TimeTakeSecondMember)
            {
                _TimeTakeForMove = TimeTakeFirstMember;
                _SumTimeTakes += TimeTakeFirstMember;
                return TimeTakeFirstMember;
            }

            _TimeTakeForMove = TimeTakeSecondMember;
            _SumTimeTakes += TimeTakeSecondMember;

            return TimeTakeSecondMember;

        }
    }
}
