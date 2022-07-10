using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.GA
{
    public class GeneticAlgorithm
    {
        private int NoGenration = 0;
        private int NoChromosome = 0;
        private List<Chromosome> lstChrosome = new List<Chromosome>();
        private int TargetPrice = 0;
        private List<int> lstOfItemOnShelf = new List<int>();
        public GeneticAlgorithm(int pNoGeneration, int pNoChromosome, int pTargetPrice, List<int> plstOfItemOnShelf)
        {
            NoGenration = pNoGeneration;
            NoChromosome = pNoChromosome;
            TargetPrice = pTargetPrice;
            lstOfItemOnShelf = plstOfItemOnShelf;
        }
        private Chromosome BuildChromosome()
        {
            Chromosome c = new Chromosome();
            int i;
            int iBook = 0;
            int SumofBook = 0;
            while (SumofBook < TargetPrice)
            {
                int indexOfBook = Util.GetRandom(0, lstOfItemOnShelf.Count - 1);
                iBook = lstOfItemOnShelf[indexOfBook];

                c.lst.Add(iBook);
                SumofBook += iBook;
            }
            return c;
        }
        private void CreatePopulation()
        {
            int i;
            for (i = 0; i < NoChromosome; i++)
            {


                lstChrosome.Add(BuildChromosome());
            }
        }
        private void LogFitNess()
        {
            WriteLog("+++ Log Fit");
            int i = 0;
            for (i = 0; i < lstChrosome.Count; i++)
            {
                Chromosome c = lstChrosome[i];

                WriteLog("FitessValue:" + c.FitnesValue.ToString());
            }
            WriteLog("+++ Log Fit");
        }
        private void CalFitnessValue()
        {
            int i;

            for (i = 0; i < lstChrosome.Count; i++)
            {
                Chromosome c = lstChrosome[i];
                int iSumTemp = c.GetSum();
                c.FitnesValue = Math.Abs(TargetPrice - iSumTemp);

            }

        }
        private List<Chromosome> Crossover(Chromosome c1, Chromosome c2)
        {
            Chromosome cChild = new Chromosome();
            Chromosome cTemp = new Chromosome();
            cChild = c1.Clone();
            cTemp = c2.Clone();
            cChild.OrderlstFromMaxToMin();
            cTemp.OrderlstFromMaxToMin();
            int iIndexSwap1 = 0;
            int iIndexSwap2 = 0;

            iIndexSwap1 = Util.GetRandom(cChild.lst.Count / 2, cChild.lst.Count - 1);
            iIndexSwap2 = Util.GetRandom(cTemp.lst.Count / 2, cTemp.lst.Count - 1);

            int iTemp = 0;
            iTemp = cChild.lst[iIndexSwap1];
            cChild.lst[iIndexSwap1] = cTemp.lst[iIndexSwap2];
            cTemp.lst[iIndexSwap2] = iTemp;
            List<Chromosome> lstResult = new List<Chromosome>();
            lstResult.Add(cChild);
            lstResult.Add(cTemp);
            return lstResult;


        }
        private void RemoveLoser()
        {
            lstChrosome = lstChrosome.OrderBy(o => o.FitnesValue).ToList();
            int i;
            int iLastIndex = lstChrosome.Count - 1;
            int iLeftIndex = iLastIndex / 2;
            for (i = iLastIndex; i > iLeftIndex; i--)
            {
                lstChrosome.RemoveAt(i);
            }

        }
        private void GenerateNewGeneration()
        {
            lstChrosome = lstChrosome.OrderByDescending(o => o.FitnesValue).ToList();

        }
        private void Mating()
        {
            int iCount = 0;
            List<Chromosome> lstNewGeneration = new List<Chromosome>();
            while (iCount < NoChromosome)
            {
                int indexOfDad = Util.GetRandom(0, lstChrosome.Count - 1);
                int indexOfMom = Util.GetRandom(0, lstChrosome.Count - 1);
                if (indexOfDad == indexOfMom)
                {
                    continue;
                }

                List<Chromosome> lstChildren = Crossover(lstChrosome[indexOfDad], lstChrosome[indexOfMom]);
                if (iCount == NoChromosome - 1)
                {
                    lstNewGeneration.Add(lstChildren[0]);

                }
                else
                {
                    lstNewGeneration.Add(lstChildren[0]);
                    lstNewGeneration.Add(lstChildren[1]);
                }
                iCount += 2;
            }
            lstChrosome = null;
            lstChrosome = lstNewGeneration;

        }
        public void Run()
        {
            int i;
            CreatePopulation();
            for (i = 0; i < NoGenration; i++)
            {
                WriteLog(" Generation:" + i.ToString());
                WriteLog("Cal Fitness Value");

                CalFitnessValue();
                LogFitNess();
                WriteLog("Remove Loser");
                RemoveLoser();
                LogFitNess();
                WriteLog("Mating");
                Mating();
                LogFitNess();
                LogTop5();
            }
        }
        private void LogTop5()
        {
            WriteLog("========== Log top 5");
            lstChrosome = lstChrosome.OrderBy(p => p.FitnesValue).ToList();
            int i = 0;
            StringBuilder strB = new StringBuilder();
            for (i = 0; i < 5; i++)
            {

                strB.Append(lstChrosome[i].GetDetail())
                    .Append(Environment.NewLine);
            }
            WriteLog(strB.ToString());
            WriteLog("========== Log top 5");
        }

        private StringBuilder strBLog = new StringBuilder();
        private void WriteLog(string str)
        {
            strBLog.Append(str).Append(Environment.NewLine);
        }
        public string GetLog()
        {
            return strBLog.ToString();
        }
        public string OutPut()
        {
            lstChrosome = lstChrosome.OrderBy(p => p.FitnesValue).ToList();
            int i = 0;
            StringBuilder strB = new StringBuilder();
            for (i = 0; i < 10; i++)
            {
                strB.Append(lstChrosome[i].GetDetail())
                    .Append(Environment.NewLine);
            }
            return strB.ToString();
        }
    }
}

