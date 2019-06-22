namespace ShortestPathRouting
{
    partial class CreatePath
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
            this.txbSource = new System.Windows.Forms.TextBox();
            this.txbDest = new System.Windows.Forms.TextBox();
            this.cbVector = new System.Windows.Forms.ComboBox();
            this.btnCreatePath = new System.Windows.Forms.Button();
            this.btnDeletePath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbLink = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txbSource
            // 
            this.txbSource.Location = new System.Drawing.Point(113, 28);
            this.txbSource.Name = "txbSource";
            this.txbSource.Size = new System.Drawing.Size(162, 20);
            this.txbSource.TabIndex = 0;
            // 
            // txbDest
            // 
            this.txbDest.Location = new System.Drawing.Point(113, 69);
            this.txbDest.Name = "txbDest";
            this.txbDest.Size = new System.Drawing.Size(162, 20);
            this.txbDest.TabIndex = 1;
            // 
            // cbVector
            // 
            this.cbVector.FormattingEnabled = true;
            this.cbVector.Location = new System.Drawing.Point(113, 166);
            this.cbVector.Name = "cbVector";
            this.cbVector.Size = new System.Drawing.Size(162, 21);
            this.cbVector.TabIndex = 3;
            // 
            // btnCreatePath
            // 
            this.btnCreatePath.Location = new System.Drawing.Point(113, 205);
            this.btnCreatePath.Name = "btnCreatePath";
            this.btnCreatePath.Size = new System.Drawing.Size(86, 23);
            this.btnCreatePath.TabIndex = 4;
            this.btnCreatePath.Text = "Create or Edit";
            this.btnCreatePath.UseVisualStyleBackColor = true;
            this.btnCreatePath.Click += new System.EventHandler(this.btnCreatePath_Click);
            // 
            // btnDeletePath
            // 
            this.btnDeletePath.Location = new System.Drawing.Point(205, 205);
            this.btnDeletePath.Name = "btnDeletePath";
            this.btnDeletePath.Size = new System.Drawing.Size(70, 23);
            this.btnDeletePath.TabIndex = 5;
            this.btnDeletePath.Text = "Delete";
            this.btnDeletePath.UseVisualStyleBackColor = true;
            this.btnDeletePath.Click += new System.EventHandler(this.btnDeletePath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Node Source";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Node Dest";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Vector";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Link";
            // 
            // txbLink
            // 
            this.txbLink.Location = new System.Drawing.Point(113, 117);
            this.txbLink.Name = "txbLink";
            this.txbLink.Size = new System.Drawing.Size(162, 20);
            this.txbLink.TabIndex = 2;
            // 
            // CreatePath
            // 
            this.AcceptButton = this.btnCreatePath;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 256);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbLink);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeletePath);
            this.Controls.Add(this.btnCreatePath);
            this.Controls.Add(this.cbVector);
            this.Controls.Add(this.txbDest);
            this.Controls.Add(this.txbSource);
            this.Name = "CreatePath";
            this.Text = "CreatePath";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CreatePath_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbSource;
        private System.Windows.Forms.TextBox txbDest;
        private System.Windows.Forms.ComboBox cbVector;
        private System.Windows.Forms.Button btnCreatePath;
        private System.Windows.Forms.Button btnDeletePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbLink;
    }
}