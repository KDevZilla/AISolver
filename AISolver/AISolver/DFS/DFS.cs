using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.DFS
{
    public class cDFS<T, T1> where T : cBaseSolverManager<T1>
    {
        private string _Result = "";
        public string Result
        {
            get
            {
                return _Result;
            }
        }
        public void Run(T SolveManager, T1 NodeInitialValue)
        {
            BNode<T1> B = new BNode<T1>(NodeInitialValue);
            Stack<BNode<T1>> St = new Stack<BNode<T1>>();
            St.Push(B);
            while (St.Count > 0)
            {
                B = St.Pop();


                if (SolveManager.IsSolve(B))
                {
                    //_Result = SolveManager.ResultDetail;
                    return;
                }
                else
                {
                    SolveManager.GenerateChild(B);
                    int i;
                    //for (i = 0; i < B.Childs.Count; i++)
                    for (i = B.Childs.Count - 1; i >= 0; i--)
                    {
                        St.Push(B.Childs[i]);

                    }
                }
            }



        }

    }
}
