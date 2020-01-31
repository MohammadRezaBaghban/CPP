namespace CPP
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.LInfixFourmula = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnParseRecursively = new System.Windows.Forms.Button();
            this.TbPrefixFormula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.PbBinaryGraph = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbBinaryGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.LInfixFourmula);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.BtnParseRecursively);
            this.panel1.Controls.Add(this.TbPrefixFormula);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1318, 137);
            this.panel1.TabIndex = 0;
            // 
            // LInfixFourmula
            // 
            this.LInfixFourmula.AutoSize = true;
            this.LInfixFourmula.Location = new System.Drawing.Point(302, 77);
            this.LInfixFourmula.Name = "LInfixFourmula";
            this.LInfixFourmula.Size = new System.Drawing.Size(0, 38);
            this.LInfixFourmula.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 38);
            this.label2.TabIndex = 11;
            this.label2.Text = "InFix Formula: ";
            // 
            // BtnParseRecursively
            // 
            this.BtnParseRecursively.Location = new System.Drawing.Point(854, 12);
            this.BtnParseRecursively.Name = "BtnParseRecursively";
            this.BtnParseRecursively.Size = new System.Drawing.Size(137, 57);
            this.BtnParseRecursively.TabIndex = 10;
            this.BtnParseRecursively.Text = "Parse Recursively";
            this.BtnParseRecursively.UseVisualStyleBackColor = true;
            this.BtnParseRecursively.Click += new System.EventHandler(this.BtnParseRecursively_Click);
            // 
            // TbPrefixFormula
            // 
            this.TbPrefixFormula.Location = new System.Drawing.Point(299, 20);
            this.TbPrefixFormula.Name = "TbPrefixFormula";
            this.TbPrefixFormula.Size = new System.Drawing.Size(528, 45);
            this.TbPrefixFormula.TabIndex = 8;
            this.TbPrefixFormula.Text = "s(x)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 38);
            this.label1.TabIndex = 7;
            this.label1.Text = "Write your formula =";
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cartesianChart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cartesianChart1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.cartesianChart1.Dock = System.Windows.Forms.DockStyle.Left;
            this.cartesianChart1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cartesianChart1.Location = new System.Drawing.Point(0, 137);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(767, 564);
            this.cartesianChart1.TabIndex = 2;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // PbBinaryGraph
            // 
            this.PbBinaryGraph.Dock = System.Windows.Forms.DockStyle.Right;
            this.PbBinaryGraph.Location = new System.Drawing.Point(773, 137);
            this.PbBinaryGraph.Name = "PbBinaryGraph";
            this.PbBinaryGraph.Size = new System.Drawing.Size(545, 564);
            this.PbBinaryGraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbBinaryGraph.TabIndex = 3;
            this.PbBinaryGraph.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 701);
            this.Controls.Add(this.PbBinaryGraph);
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbBinaryGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LInfixFourmula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnParseRecursively;
        private System.Windows.Forms.TextBox TbPrefixFormula;
        private System.Windows.Forms.Label label1;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.PictureBox PbBinaryGraph;
    }
}

