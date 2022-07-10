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
    public partial class FormKnapSack : Form
    {
        public FormKnapSack()
        {
            InitializeComponent();
        }

        private void btnViewSolution_Click(object sender, EventArgs e)
        {
            List<int> lstItem = new List<int>();
            String ListItemsPriceString = this.txtItemPrices.Text;
            String[] arrItemPricesString = ListItemsPriceString.Split(',');
            foreach (String ItemPriceString in arrItemPricesString)
            {
                if (!Util.IsNumeric(ItemPriceString))
                {
                    MessageBox.Show("List of item prices as Numeric value between 1 and 1000 with comma as delimiter");
                    return;
                }
                int Itemprice = int.Parse(ItemPriceString);
                if (Itemprice < 1 || Itemprice > 1000)
                {
                    MessageBox.Show("List of item prices as Numeric value between 1 and 1000 with comma as delimiter");
                    return;
                }
                lstItem.Add(Itemprice);
            }
            if (!Util.IsNumeric(this.txtMoney.Text))
            {
                MessageBox.Show("Please enter Money textbox as Numeric");
                return;
            }
            int Money = int.Parse(this.txtMoney.Text);

            GA.GeneticAlgorithm ga = new GA.GeneticAlgorithm(50, 100, Money, lstItem);

            //MonteCarlo.cMonteCarlor cMon = new MonteCarlo.cMonteCarlor(1, 50000, 152, lstItem);
            ga.Run();


            this.textBox1.Text = ga.OutPut();
        }
    }
}
