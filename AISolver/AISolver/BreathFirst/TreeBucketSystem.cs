using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISolver.BreathFirst
{
    public class TreeBucketSystem
    {

        public bool HasDiscovered = false;
        private TreeBucketSystem _Parent;
        public TreeBucketSystem Parent
        {
            get { return _Parent; }
        }
        public bool HasParent
        {
            get { return _Parent != null; }
        }
        public void setParent(TreeBucketSystem pParent)
        {
            this._Parent = pParent;
        }
        public void Add(TreeBucketSystem child)
        {
            child.setParent(this);
            this.Nodes.Add(child);
        }
        private List<TreeBucketSystem> _Nodes = null;
        public List<TreeBucketSystem> Nodes
        {
            get
            {
                if (_Nodes == null)
                {
                    _Nodes = new List<TreeBucketSystem>();
                }
                return _Nodes;

            }


        }
        public void Sort()
        {
            _Nodes = _Nodes.OrderByDescending(o => o.Table.Score).ToList();
        }

        public int Score = 0;

        public bool HasChild
        {
            get
            {
                return Nodes.Count > 0;
            }
        }
        private BucketSystem _Table = null;
        public BucketSystem Table { get { return _Table; } }
        public TreeBucketSystem(BucketSystem Item)
        {
            _Table = Item;
        }
    }
}
