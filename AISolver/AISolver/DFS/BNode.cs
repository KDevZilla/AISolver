using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.DFS
{
    public class BNode<T>
    {
        public Dictionary<string, int> ExtendedProperty = new Dictionary<string, int>();
        T _Value;
        public BNode(T t)
        {
            this._Value = t;
        }
        public T Value
        {
            get
            {
                return _Value;
            }
        }
        public string TraveltoRoot()
        {
            StringBuilder strB = new StringBuilder();
            strB.Append(_Value.ToString());
            BNode<T> Par = this.Parent;
            while (Par != null)
            {
                strB.Insert(0, Par.Value.ToString() + Environment.NewLine);
                Par = Par.Parent;
            }
            return strB.ToString();
        }

        public List<BNode<T>> Childs = new List<BNode<T>>();
        public BNode<T> Parent = null;
        public BNode<T> Root()
        {
            if (this.Parent == null)
            {
                return this;
            }

            BNode<T> Par = this.Parent;
            while (Par.Parent != null)
            {
                Par = Par.Parent;
            }
            return Par;
        }
        public BNode<T> AddChild(T t)
        {
            BNode<T> NewChild = new BNode<T>(t);
            return AddChild(NewChild);

        }

        public BNode<T> AddChild(BNode<T> NewChild)
        {

            NewChild.Parent = this;
            Childs.Add(NewChild);
            return NewChild;


        }
    }
}