﻿namespace CPP
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
            this.LblEndingPoint = new System.Windows.Forms.Label();
            this.LblStartingPoint = new System.Windows.Forms.Label();
            this.BtnRiemannIntegral = new System.Windows.Forms.Button();
            this.Btn_NewtonDerivation = new System.Windows.Forms.Button();
            this.BtnClearPlot = new System.Windows.Forms.Button();
            this.Btn_Analytical_Derivation = new System.Windows.Forms.Button();
            this.BtnParseRecursively = new System.Windows.Forms.Button();
            this.TbPrefixFormula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.PbBinaryGraph = new System.Windows.Forms.PictureBox();
            this.LblRiemannArea = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LInfixFourmula = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbBinaryGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.LblRiemannArea);
            this.panel1.Controls.Add(this.LblEndingPoint);
            this.panel1.Controls.Add(this.LblStartingPoint);
            this.panel1.Controls.Add(this.BtnRiemannIntegral);
            this.panel1.Controls.Add(this.Btn_NewtonDerivation);
            this.panel1.Controls.Add(this.BtnClearPlot);
            this.panel1.Controls.Add(this.Btn_Analytical_Derivation);
            this.panel1.Controls.Add(this.LInfixFourmula);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.BtnParseRecursively);
            this.panel1.Controls.Add(this.TbPrefixFormula);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1182, 251);
            this.panel1.TabIndex = 0;
            // 
            // LblEndingPoint
            // 
            this.LblEndingPoint.AutoSize = true;
            this.LblEndingPoint.Location = new System.Drawing.Point(140, 154);
            this.LblEndingPoint.Name = "LblEndingPoint";
            this.LblEndingPoint.Size = new System.Drawing.Size(63, 38);
            this.LblEndingPoint.TabIndex = 19;
            this.LblEndingPoint.Text = "X 2:";
            // 
            // LblStartingPoint
            // 
            this.LblStartingPoint.AutoSize = true;
            this.LblStartingPoint.Location = new System.Drawing.Point(18, 154);
            this.LblStartingPoint.Name = "LblStartingPoint";
            this.LblStartingPoint.Size = new System.Drawing.Size(55, 38);
            this.LblStartingPoint.TabIndex = 18;
            this.LblStartingPoint.Text = "X1:";
            // 
            // BtnRiemannIntegral
            // 
            this.BtnRiemannIntegral.Location = new System.Drawing.Point(670, 178);
            this.BtnRiemannIntegral.Name = "BtnRiemannIntegral";
            this.BtnRiemannIntegral.Size = new System.Drawing.Size(500, 54);
            this.BtnRiemannIntegral.TabIndex = 16;
            this.BtnRiemannIntegral.Text = "Riemann Integral";
            this.BtnRiemannIntegral.UseVisualStyleBackColor = true;
            this.BtnRiemannIntegral.Click += new System.EventHandler(this.BtnRiemannIntegral_Click);
            // 
            // Btn_NewtonDerivation
            // 
            this.Btn_NewtonDerivation.Location = new System.Drawing.Point(670, 72);
            this.Btn_NewtonDerivation.Name = "Btn_NewtonDerivation";
            this.Btn_NewtonDerivation.Size = new System.Drawing.Size(244, 95);
            this.Btn_NewtonDerivation.TabIndex = 15;
            this.Btn_NewtonDerivation.Text = "Newton Diff Derivation";
            this.Btn_NewtonDerivation.UseVisualStyleBackColor = true;
            this.Btn_NewtonDerivation.Click += new System.EventHandler(this.Btn_NewtonDerivation_Click);
            // 
            // BtnClearPlot
            // 
            this.BtnClearPlot.Location = new System.Drawing.Point(926, 9);
            this.BtnClearPlot.Name = "BtnClearPlot";
            this.BtnClearPlot.Size = new System.Drawing.Size(244, 57);
            this.BtnClearPlot.TabIndex = 14;
            this.BtnClearPlot.Text = "Clear Plot";
            this.BtnClearPlot.UseVisualStyleBackColor = true;
            this.BtnClearPlot.Click += new System.EventHandler(this.BtnClearPlot_Click);
            // 
            // Btn_Analytical_Derivation
            // 
            this.Btn_Analytical_Derivation.Location = new System.Drawing.Point(926, 72);
            this.Btn_Analytical_Derivation.Name = "Btn_Analytical_Derivation";
            this.Btn_Analytical_Derivation.Size = new System.Drawing.Size(244, 95);
            this.Btn_Analytical_Derivation.TabIndex = 13;
            this.Btn_Analytical_Derivation.Text = "Analytical Derivation";
            this.Btn_Analytical_Derivation.UseVisualStyleBackColor = true;
            this.Btn_Analytical_Derivation.Click += new System.EventHandler(this.Btn_Analytical_Derivation_Click);
            // 
            // BtnParseRecursively
            // 
            this.BtnParseRecursively.Location = new System.Drawing.Point(670, 9);
            this.BtnParseRecursively.Name = "BtnParseRecursively";
            this.BtnParseRecursively.Size = new System.Drawing.Size(244, 57);
            this.BtnParseRecursively.TabIndex = 10;
            this.BtnParseRecursively.Text = "Parse Recursively";
            this.BtnParseRecursively.UseVisualStyleBackColor = true;
            this.BtnParseRecursively.Click += new System.EventHandler(this.BtnParseRecursively_Click);
            // 
            // TbPrefixFormula
            // 
            this.TbPrefixFormula.Location = new System.Drawing.Point(283, 12);
            this.TbPrefixFormula.Name = "TbPrefixFormula";
            this.TbPrefixFormula.Size = new System.Drawing.Size(381, 45);
            this.TbPrefixFormula.TabIndex = 8;
            this.TbPrefixFormula.Text = "s(x)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 38);
            this.label1.TabIndex = 7;
            this.label1.Text = "Write your formula:";
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cartesianChart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cartesianChart1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.cartesianChart1.Dock = System.Windows.Forms.DockStyle.Left;
            this.cartesianChart1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cartesianChart1.Location = new System.Drawing.Point(0, 251);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(723, 673);
            this.cartesianChart1.TabIndex = 2;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // PbBinaryGraph
            // 
            this.PbBinaryGraph.Dock = System.Windows.Forms.DockStyle.Right;
            this.PbBinaryGraph.Location = new System.Drawing.Point(729, 251);
            this.PbBinaryGraph.Name = "PbBinaryGraph";
            this.PbBinaryGraph.Size = new System.Drawing.Size(453, 673);
            this.PbBinaryGraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbBinaryGraph.TabIndex = 3;
            this.PbBinaryGraph.TabStop = false;
            // 
            // LblRiemannArea
            // 
            this.LblRiemannArea.AutoSize = true;
            this.LblRiemannArea.Location = new System.Drawing.Point(271, 154);
            this.LblRiemannArea.Name = "LblRiemannArea";
            this.LblRiemannArea.Size = new System.Drawing.Size(88, 38);
            this.LblRiemannArea.TabIndex = 20;
            this.LblRiemannArea.Text = "Area: ";
            this.LblRiemannArea.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 38);
            this.label2.TabIndex = 11;
            this.label2.Text = "InFix Formula (x=10): ";
            // 
            // LInfixFourmula
            // 
            this.LInfixFourmula.AutoSize = true;
            this.LInfixFourmula.Location = new System.Drawing.Point(301, 93);
            this.LInfixFourmula.Name = "LInfixFourmula";
            this.LInfixFourmula.Size = new System.Drawing.Size(0, 38);
            this.LInfixFourmula.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 924);
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
        private System.Windows.Forms.Button BtnParseRecursively;
        private System.Windows.Forms.TextBox TbPrefixFormula;
        private System.Windows.Forms.Label label1;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.PictureBox PbBinaryGraph;
        private System.Windows.Forms.Button Btn_Analytical_Derivation;
        private System.Windows.Forms.Button BtnClearPlot;
        private System.Windows.Forms.Button Btn_NewtonDerivation;
        private System.Windows.Forms.Button BtnRiemannIntegral;
        private System.Windows.Forms.Label LblEndingPoint;
        private System.Windows.Forms.Label LblStartingPoint;
        private System.Windows.Forms.Label LblRiemannArea;
        private System.Windows.Forms.Label LInfixFourmula;
        private System.Windows.Forms.Label label2;
    }
}

