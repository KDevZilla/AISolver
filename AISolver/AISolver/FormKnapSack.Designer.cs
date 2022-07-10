namespace AISolver
{
    partial class FormKnapSack
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtItemPrices = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnViewSolution = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtItemPrices
            // 
            this.txtItemPrices.Location = new System.Drawing.Point(177, 57);
            this.txtItemPrices.Name = "txtItemPrices";
            this.txtItemPrices.Size = new System.Drawing.Size(453, 26);
            this.txtItemPrices.TabIndex = 11;
            this.txtItemPrices.Text = "30,50,75,150,200,300";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "List of item prices:";
            // 
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(177, 14);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(453, 26);
            this.txtMoney.TabIndex = 9;
            this.txtMoney.Text = "2000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "You have money:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 112);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(998, 359);
            this.textBox1.TabIndex = 7;
            // 
            // btnViewSolution
            // 
            this.btnViewSolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSolution.Location = new System.Drawing.Point(885, 57);
            this.btnViewSolution.Name = "btnViewSolution";
            this.btnViewSolution.Size = new System.Drawing.Size(128, 37);
            this.btnViewSolution.TabIndex = 20;
            this.btnViewSolution.Text = "View solution";
            this.btnViewSolution.UseVisualStyleBackColor = true;
            this.btnViewSolution.Click += new System.EventHandler(this.btnViewSolution_Click);
            // 
            // FormKnapSack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 482);
            this.Controls.Add(this.btnViewSolution);
            this.Controls.Add(this.txtItemPrices);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMoney);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormKnapSack";
            this.Text = "FormKnapSack";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtItemPrices;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnViewSolution;
    }
}