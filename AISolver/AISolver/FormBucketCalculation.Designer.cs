namespace AISolver
{
    partial class FormBucketCalculation
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
            this.txtBucketSizes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWaterInWell = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWaterGoal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnViewSolution = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBucketSizes
            // 
            this.txtBucketSizes.Location = new System.Drawing.Point(241, 61);
            this.txtBucketSizes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBucketSizes.Name = "txtBucketSizes";
            this.txtBucketSizes.Size = new System.Drawing.Size(300, 26);
            this.txtBucketSizes.TabIndex = 10;
            this.txtBucketSizes.Text = "5, 6";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "List of bucket size you have:";
            // 
            // txtWaterInWell
            // 
            this.txtWaterInWell.Location = new System.Drawing.Point(117, 25);
            this.txtWaterInWell.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWaterInWell.Name = "txtWaterInWell";
            this.txtWaterInWell.Size = new System.Drawing.Size(424, 26);
            this.txtWaterInWell.TabIndex = 8;
            this.txtWaterInWell.Text = "30";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Water in well:";
            // 
            // txtWaterGoal
            // 
            this.txtWaterGoal.Location = new System.Drawing.Point(304, 94);
            this.txtWaterGoal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWaterGoal.Name = "txtWaterGoal";
            this.txtWaterGoal.Size = new System.Drawing.Size(237, 26);
            this.txtWaterGoal.TabIndex = 12;
            this.txtWaterGoal.Text = "3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 97);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "How much water you would like to have:";
            // 
            // btnViewSolution
            // 
            this.btnViewSolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSolution.Location = new System.Drawing.Point(11, 142);
            this.btnViewSolution.Name = "btnViewSolution";
            this.btnViewSolution.Size = new System.Drawing.Size(128, 37);
            this.btnViewSolution.TabIndex = 19;
            this.btnViewSolution.Text = "View solution";
            this.btnViewSolution.UseVisualStyleBackColor = true;
            this.btnViewSolution.Click += new System.EventHandler(this.btnViewSolution_Click);
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtResult.Location = new System.Drawing.Point(11, 186);
            this.txtResult.Margin = new System.Windows.Forms.Padding(9, 12, 9, 12);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(723, 333);
            this.txtResult.TabIndex = 18;
            // 
            // FormBucketCalculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 526);
            this.Controls.Add(this.btnViewSolution);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtWaterGoal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBucketSizes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWaterInWell);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormBucketCalculation";
            this.Text = "FormBucketCalculation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBucketSizes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWaterInWell;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWaterGoal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnViewSolution;
        private System.Windows.Forms.TextBox txtResult;
    }
}