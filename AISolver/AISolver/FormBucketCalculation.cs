using AISolver.BreathFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AISolver
{
    public partial class FormBucketCalculation : Form
    {
        public FormBucketCalculation()
        {
            InitializeComponent();
        }

        private void btnViewSolution_Click(object sender, EventArgs e)
        {
            
            List<int> ListBucketsInt = new List<int>();
            String ListBuckets = this.txtBucketSizes.Text;
            String[] arrItemBucketString = ListBuckets.Split(',');
            foreach (String ItemBucketString in arrItemBucketString)
            {
                if (!Util.IsNumeric(ItemBucketString))
                {
                    MessageBox.Show("List of Bucket as Numeric value between 1 and 10 with comma as delimiter");
                    return;
                }
                int ItemBucket = int.Parse(ItemBucketString);
                if (ItemBucket < 1 || ItemBucket > 10)
                {
                    MessageBox.Show("List of Bucket as Numeric value between 1 and 10 with comma as delimiter");
                    return;
                }
                ListBucketsInt.Add(ItemBucket);
            }
            if (!Util.IsNumeric(this.txtWaterInWell.Text))
            {
                MessageBox.Show("Please enter Water In Well as Numeric");
                return;
            }
            if(!Util.IsNumeric (this.txtWaterGoal.Text))
            {
                MessageBox.Show("Please enter How much water you would like to have as Numeric");
                return;

            }
            int NumberInWell = 30;
            int LitreGoal = 2;

            NumberInWell = int.Parse(this.txtWaterInWell.Text);
            LitreGoal = int.Parse(this.txtWaterGoal.Text);

            BucketSystem cB = new BucketSystem(NumberInWell, LitreGoal , ListBucketsInt.ToArray ());


            BreathFirst.TreeBucketSystem Tree = new BreathFirst.TreeBucketSystem(cB);
            BreathFirst.BreathFirstSearch BreathFirst = new BreathFirst.BreathFirstSearch();
            BreathFirst.BreathFirstSolve(Tree);

           // cWriteLog.WriteLog(BreathFirst.Solution);
            this.txtResult.Text  = BreathFirst.Solution;

        }
    }
}
