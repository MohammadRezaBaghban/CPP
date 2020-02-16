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
            this.Btn_Polynomial_Intropolate = new System.Windows.Forms.Button();
            this.Btn_NPolynomialPoint = new System.Windows.Forms.Button();
            this.BtnMaclaurinSeries = new System.Windows.Forms.Button();
            this.LblRiemannArea = new System.Windows.Forms.Label();
            this.LblEndingPoint = new System.Windows.Forms.Label();
            this.LblStartingPoint = new System.Windows.Forms.Label();
            this.BtnRiemannIntegral = new System.Windows.Forms.Button();
            this.Btn_NewtonDerivation = new System.Windows.Forms.Button();
            this.BtnClearPlot = new System.Windows.Forms.Button();
            this.Btn_Analytical_Derivation = new System.Windows.Forms.Button();
            this.LbInfixFourmula = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnParseRecursively = new System.Windows.Forms.Button();
            this.TbPrefixFormula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PbBinaryGraphRoot = new System.Windows.Forms.PictureBox();
            this.PbBinaryGraphSecondary = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.LblSelectedPoints = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbBinaryGraphRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBinaryGraphSecondary)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.Controls.Add(this.Btn_Polynomial_Intropolate);
            this.panel1.Controls.Add(this.Btn_NPolynomialPoint);
            this.panel1.Controls.Add(this.BtnMaclaurinSeries);
            this.panel1.Controls.Add(this.LblRiemannArea);
            this.panel1.Controls.Add(this.LblEndingPoint);
            this.panel1.Controls.Add(this.LblStartingPoint);
            this.panel1.Controls.Add(this.BtnRiemannIntegral);
            this.panel1.Controls.Add(this.Btn_NewtonDerivation);
            this.panel1.Controls.Add(this.BtnClearPlot);
            this.panel1.Controls.Add(this.Btn_Analytical_Derivation);
            this.panel1.Controls.Add(this.LbInfixFourmula);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.BtnParseRecursively);
            this.panel1.Controls.Add(this.TbPrefixFormula);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1759, 261);
            this.panel1.TabIndex = 0;
            // 
            // Btn_Polynomial_Intropolate
            // 
            this.Btn_Polynomial_Intropolate.Location = new System.Drawing.Point(1409, 188);
            this.Btn_Polynomial_Intropolate.Name = "Btn_Polynomial_Intropolate";
            this.Btn_Polynomial_Intropolate.Size = new System.Drawing.Size(332, 57);
            this.Btn_Polynomial_Intropolate.TabIndex = 23;
            this.Btn_Polynomial_Intropolate.Text = "Polynomial Intropolate";
            this.Btn_Polynomial_Intropolate.UseVisualStyleBackColor = true;
            this.Btn_Polynomial_Intropolate.Click += new System.EventHandler(this.Btn_Polynomial_Intropolate_Click);
            // 
            // Btn_NPolynomialPoint
            // 
            this.Btn_NPolynomialPoint.Location = new System.Drawing.Point(1054, 188);
            this.Btn_NPolynomialPoint.Name = "Btn_NPolynomialPoint";
            this.Btn_NPolynomialPoint.Size = new System.Drawing.Size(332, 57);
            this.Btn_NPolynomialPoint.TabIndex = 22;
            this.Btn_NPolynomialPoint.Text = "Polynomial Points";
            this.Btn_NPolynomialPoint.UseVisualStyleBackColor = true;
            this.Btn_NPolynomialPoint.Click += new System.EventHandler(this.Btn_NPolynomialPoint_Click);
            // 
            // BtnMaclaurinSeries
            // 
            this.BtnMaclaurinSeries.Location = new System.Drawing.Point(1409, 106);
            this.BtnMaclaurinSeries.Name = "BtnMaclaurinSeries";
            this.BtnMaclaurinSeries.Size = new System.Drawing.Size(332, 57);
            this.BtnMaclaurinSeries.TabIndex = 21;
            this.BtnMaclaurinSeries.Text = "Maclaurin series";
            this.BtnMaclaurinSeries.UseVisualStyleBackColor = true;
            this.BtnMaclaurinSeries.Click += new System.EventHandler(this.BtnMaclaurinSeries_Click);
            // 
            // LblRiemannArea
            // 
            this.LblRiemannArea.AutoSize = true;
            this.LblRiemannArea.Location = new System.Drawing.Point(271, 138);
            this.LblRiemannArea.Name = "LblRiemannArea";
            this.LblRiemannArea.Size = new System.Drawing.Size(88, 38);
            this.LblRiemannArea.TabIndex = 20;
            this.LblRiemannArea.Text = "Area: ";
            this.LblRiemannArea.Visible = false;
            // 
            // LblEndingPoint
            // 
            this.LblEndingPoint.AutoSize = true;
            this.LblEndingPoint.Location = new System.Drawing.Point(146, 138);
            this.LblEndingPoint.Name = "LblEndingPoint";
            this.LblEndingPoint.Size = new System.Drawing.Size(38, 38);
            this.LblEndingPoint.TabIndex = 19;
            this.LblEndingPoint.Text = "Y:";
            // 
            // LblStartingPoint
            // 
            this.LblStartingPoint.AutoSize = true;
            this.LblStartingPoint.Location = new System.Drawing.Point(14, 138);
            this.LblStartingPoint.Name = "LblStartingPoint";
            this.LblStartingPoint.Size = new System.Drawing.Size(40, 38);
            this.LblStartingPoint.TabIndex = 18;
            this.LblStartingPoint.Text = "X:";
            // 
            // BtnRiemannIntegral
            // 
            this.BtnRiemannIntegral.Location = new System.Drawing.Point(1054, 106);
            this.BtnRiemannIntegral.Name = "BtnRiemannIntegral";
            this.BtnRiemannIntegral.Size = new System.Drawing.Size(332, 57);
            this.BtnRiemannIntegral.TabIndex = 16;
            this.BtnRiemannIntegral.Text = "Riemann Integral";
            this.BtnRiemannIntegral.UseVisualStyleBackColor = true;
            this.BtnRiemannIntegral.Click += new System.EventHandler(this.BtnRiemannIntegral_Click);
            // 
            // Btn_NewtonDerivation
            // 
            this.Btn_NewtonDerivation.Location = new System.Drawing.Point(1054, 26);
            this.Btn_NewtonDerivation.Name = "Btn_NewtonDerivation";
            this.Btn_NewtonDerivation.Size = new System.Drawing.Size(332, 57);
            this.Btn_NewtonDerivation.TabIndex = 15;
            this.Btn_NewtonDerivation.Text = "Newton Diff Derivation";
            this.Btn_NewtonDerivation.UseVisualStyleBackColor = true;
            this.Btn_NewtonDerivation.Click += new System.EventHandler(this.Btn_NewtonDerivation_Click);
            // 
            // BtnClearPlot
            // 
            this.BtnClearPlot.Location = new System.Drawing.Point(699, 106);
            this.BtnClearPlot.Name = "BtnClearPlot";
            this.BtnClearPlot.Size = new System.Drawing.Size(332, 57);
            this.BtnClearPlot.TabIndex = 14;
            this.BtnClearPlot.Text = "Clear Plot";
            this.BtnClearPlot.UseVisualStyleBackColor = true;
            this.BtnClearPlot.Click += new System.EventHandler(this.BtnClearPlot_Click);
            // 
            // Btn_Analytical_Derivation
            // 
            this.Btn_Analytical_Derivation.Location = new System.Drawing.Point(1409, 26);
            this.Btn_Analytical_Derivation.Name = "Btn_Analytical_Derivation";
            this.Btn_Analytical_Derivation.Size = new System.Drawing.Size(332, 57);
            this.Btn_Analytical_Derivation.TabIndex = 13;
            this.Btn_Analytical_Derivation.Text = "Analytical Derivation";
            this.Btn_Analytical_Derivation.UseVisualStyleBackColor = true;
            this.Btn_Analytical_Derivation.Click += new System.EventHandler(this.Btn_Analytical_Derivation_Click);
            // 
            // LbInfixFourmula
            // 
            this.LbInfixFourmula.AutoSize = true;
            this.LbInfixFourmula.Location = new System.Drawing.Point(14, 220);
            this.LbInfixFourmula.Name = "LbInfixFourmula";
            this.LbInfixFourmula.Size = new System.Drawing.Size(105, 38);
            this.LbInfixFourmula.TabIndex = 12;
            this.LbInfixFourmula.Text = "--------";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 38);
            this.label2.TabIndex = 11;
            this.label2.Text = "InFix Formula (x=10): ";
            // 
            // BtnParseRecursively
            // 
            this.BtnParseRecursively.Location = new System.Drawing.Point(699, 26);
            this.BtnParseRecursively.Name = "BtnParseRecursively";
            this.BtnParseRecursively.Size = new System.Drawing.Size(332, 57);
            this.BtnParseRecursively.TabIndex = 10;
            this.BtnParseRecursively.Text = "Parse Recursively";
            this.BtnParseRecursively.UseVisualStyleBackColor = true;
            this.BtnParseRecursively.Click += new System.EventHandler(this.BtnParseRecursively_Click);
            // 
            // TbPrefixFormula
            // 
            this.TbPrefixFormula.Location = new System.Drawing.Point(295, 32);
            this.TbPrefixFormula.Name = "TbPrefixFormula";
            this.TbPrefixFormula.Size = new System.Drawing.Size(381, 45);
            this.TbPrefixFormula.TabIndex = 8;
            this.TbPrefixFormula.Text = "*(s(x),c(x))";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 38);
            this.label1.TabIndex = 7;
            this.label1.Text = "Write your formula:";
            // 
            // PbBinaryGraphRoot
            // 
            this.PbBinaryGraphRoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PbBinaryGraphRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PbBinaryGraphRoot.Location = new System.Drawing.Point(0, 0);
            this.PbBinaryGraphRoot.Name = "PbBinaryGraphRoot";
            this.PbBinaryGraphRoot.Size = new System.Drawing.Size(676, 271);
            this.PbBinaryGraphRoot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbBinaryGraphRoot.TabIndex = 3;
            this.PbBinaryGraphRoot.TabStop = false;
            // 
            // PbBinaryGraphSecondary
            // 
            this.PbBinaryGraphSecondary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PbBinaryGraphSecondary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PbBinaryGraphSecondary.Location = new System.Drawing.Point(0, 0);
            this.PbBinaryGraphSecondary.Name = "PbBinaryGraphSecondary";
            this.PbBinaryGraphSecondary.Size = new System.Drawing.Size(676, 415);
            this.PbBinaryGraphSecondary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbBinaryGraphSecondary.TabIndex = 4;
            this.PbBinaryGraphSecondary.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 261);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(676, 690);
            this.panel2.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.PbBinaryGraphRoot);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PbBinaryGraphSecondary);
            this.splitContainer1.Size = new System.Drawing.Size(676, 690);
            this.splitContainer1.SplitterDistance = 271;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel3.Controls.Add(this.cartesianChart1);
            this.panel3.Controls.Add(this.LblSelectedPoints);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(682, 261);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1077, 690);
            this.panel3.TabIndex = 6;
            this.panel3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseClick);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseMove);
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cartesianChart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cartesianChart1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.cartesianChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartesianChart1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cartesianChart1.Location = new System.Drawing.Point(0, 0);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(1077, 690);
            this.cartesianChart1.TabIndex = 5;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // LblSelectedPoints
            // 
            this.LblSelectedPoints.AutoSize = true;
            this.LblSelectedPoints.Location = new System.Drawing.Point(17, 16);
            this.LblSelectedPoints.Name = "LblSelectedPoints";
            this.LblSelectedPoints.Size = new System.Drawing.Size(324, 38);
            this.LblSelectedPoints.TabIndex = 6;
            this.LblSelectedPoints.Text = "Please Select Your Points";
            this.LblSelectedPoints.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1759, 951);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbBinaryGraphRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBinaryGraphSecondary)).EndInit();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnParseRecursively;
        private System.Windows.Forms.TextBox TbPrefixFormula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PbBinaryGraphRoot;
        private System.Windows.Forms.Button Btn_Analytical_Derivation;
        private System.Windows.Forms.Button BtnClearPlot;
        private System.Windows.Forms.Button Btn_NewtonDerivation;
        private System.Windows.Forms.Button BtnRiemannIntegral;
        private System.Windows.Forms.Label LblEndingPoint;
        private System.Windows.Forms.Label LblStartingPoint;
        private System.Windows.Forms.Label LblRiemannArea;
        private System.Windows.Forms.Label LbInfixFourmula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox PbBinaryGraphSecondary;
        private System.Windows.Forms.Button BtnMaclaurinSeries;
        private System.Windows.Forms.Button Btn_Polynomial_Intropolate;
        private System.Windows.Forms.Button Btn_NPolynomialPoint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel3;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Label LblSelectedPoints;
    }
}

