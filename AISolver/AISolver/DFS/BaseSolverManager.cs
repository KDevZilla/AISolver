using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.DFS
{
    public abstract class cBaseSolverManager<T>
    {
        public bool IsInitial = false;
        protected bool IsSolved = false;
        public abstract void GenerateChild(BNode<T> CurrentNode);
        public abstract void Initial();
        public abstract bool IsSolve(BNode<T> CurrentNode);
        public string ResultDetail;
        protected abstract void LogResult(string str);
        private HashSet<string> HashVisited = new HashSet<string>();
        protected bool IsVisisted(String HashCode)
        {

            if (HashVisited.Contains(HashCode))
            {
                return true;
            }

            return false;
        }
        protected void MarkVisited(String HashCode)
        {
            HashVisited.Add(HashCode);
        }
    }
}

