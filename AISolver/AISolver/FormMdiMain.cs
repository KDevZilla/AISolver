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
    public partial class FormMdiMain : Form
    {
        public FormMdiMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout f = new FormAbout();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void crossRiverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCrossingRiver f = new FormCrossingRiver();
            f.MdiParent = this;
            f.Show();

        }

        private void knapSackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKnapSack  f = new FormKnapSack();
            f.MdiParent = this;
            f.Show();

        }

        private void bucketCalculationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBucketCalculation f = new FormBucketCalculation();
            f.MdiParent = this;
            f.Show();
        }
    }
}
