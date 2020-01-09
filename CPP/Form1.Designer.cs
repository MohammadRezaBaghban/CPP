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
            this.label1 = new System.Windows.Forms.Label();
            this.TbText = new System.Windows.Forms.TextBox();
            this.LBContainingElement = new System.Windows.Forms.ListBox();
            this.BtnParseRecursively = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Write your formula:";
            // 
            // TbText
            // 
            this.TbText.Location = new System.Drawing.Point(331, 42);
            this.TbText.Name = "TbText";
            this.TbText.Size = new System.Drawing.Size(528, 45);
            this.TbText.TabIndex = 1;
            // 
            // LBContainingElement
            // 
            this.LBContainingElement.FormattingEnabled = true;
            this.LBContainingElement.ItemHeight = 38;
            this.LBContainingElement.Location = new System.Drawing.Point(1055, 39);
            this.LBContainingElement.Name = "LBContainingElement";
            this.LBContainingElement.Size = new System.Drawing.Size(316, 308);
            this.LBContainingElement.TabIndex = 3;
            // 
            // BtnParseRecursively
            // 
            this.BtnParseRecursively.Location = new System.Drawing.Point(888, 39);
            this.BtnParseRecursively.Name = "BtnParseRecursively";
            this.BtnParseRecursively.Size = new System.Drawing.Size(137, 50);
            this.BtnParseRecursively.TabIndex = 4;
            this.BtnParseRecursively.Text = "Parse Recursively";
            this.BtnParseRecursively.UseVisualStyleBackColor = true;
            this.BtnParseRecursively.Click += new System.EventHandler(this.BtnParseRecursively_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 954);
            this.Controls.Add(this.BtnParseRecursively);
            this.Controls.Add(this.LBContainingElement);
            this.Controls.Add(this.TbText);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbText;
        private System.Windows.Forms.ListBox LBContainingElement;
        private System.Windows.Forms.Button BtnParseRecursively;
    }
}

