namespace ShortestPathRouting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dgvNode = new System.Windows.Forms.DataGridView();
            this.btnRouting = new System.Windows.Forms.Button();
            this.btnStepRun = new System.Windows.Forms.Button();
            this.btnDeleteData = new System.Windows.Forms.Button();
            this.btnStepBack = new System.Windows.Forms.Button();
            this.btnCreateNode = new System.Windows.Forms.Button();
            this.btnSetSource = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbSetSource = new System.Windows.Forms.TextBox();
            this.btnDeleteNode = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.txbDest = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSourceDest = new System.Windows.Forms.Button();
            this.cbAlgorithms = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.txbFile = new System.Windows.Forms.TextBox();
            this.btnFileSend = new System.Windows.Forms.Button();
            this.btnSendData = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnSetupConnect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNode)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNode
            // 
            this.dgvNode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvNode.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvNode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNode.Location = new System.Drawing.Point(12, 188);
            this.dgvNode.Name = "dgvNode";
            this.dgvNode.Size = new System.Drawing.Size(438, 387);
            this.dgvNode.TabIndex = 0;
            // 
            // btnRouting
            // 
            this.btnRouting.Location = new System.Drawing.Point(12, 54);
            this.btnRouting.Name = "btnRouting";
            this.btnRouting.Size = new System.Drawing.Size(75, 23);
            this.btnRouting.TabIndex = 1;
            this.btnRouting.Text = "Routing";
            this.btnRouting.UseVisualStyleBackColor = true;
            this.btnRouting.Click += new System.EventHandler(this.btnRouting_Click);
            // 
            // btnStepRun
            // 
            this.btnStepRun.Location = new System.Drawing.Point(183, 54);
            this.btnStepRun.Name = "btnStepRun";
            this.btnStepRun.Size = new System.Drawing.Size(75, 23);
            this.btnStepRun.TabIndex = 3;
            this.btnStepRun.Text = "Run >>";
            this.btnStepRun.UseVisualStyleBackColor = true;
            this.btnStepRun.Click += new System.EventHandler(this.btnStepRun_Click);
            // 
            // btnDeleteData
            // 
            this.btnDeleteData.Location = new System.Drawing.Point(276, 54);
            this.btnDeleteData.Name = "btnDeleteData";
            this.btnDeleteData.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteData.TabIndex = 4;
            this.btnDeleteData.Text = "Delete Data";
            this.btnDeleteData.UseVisualStyleBackColor = true;
            this.btnDeleteData.Click += new System.EventHandler(this.btnDeleteData_Click);
            // 
            // btnStepBack
            // 
            this.btnStepBack.Location = new System.Drawing.Point(105, 54);
            this.btnStepBack.Name = "btnStepBack";
            this.btnStepBack.Size = new System.Drawing.Size(75, 23);
            this.btnStepBack.TabIndex = 5;
            this.btnStepBack.Text = "<< Back";
            this.btnStepBack.UseVisualStyleBackColor = true;
            this.btnStepBack.Click += new System.EventHandler(this.btnStepBack_Click);
            // 
            // btnCreateNode
            // 
            this.btnCreateNode.Location = new System.Drawing.Point(276, 16);
            this.btnCreateNode.Name = "btnCreateNode";
            this.btnCreateNode.Size = new System.Drawing.Size(75, 23);
            this.btnCreateNode.TabIndex = 7;
            this.btnCreateNode.Text = "Create node";
            this.btnCreateNode.UseVisualStyleBackColor = true;
            this.btnCreateNode.Click += new System.EventHandler(this.btnCreateNode_Click);
            // 
            // btnSetSource
            // 
            this.btnSetSource.Location = new System.Drawing.Point(276, 88);
            this.btnSetSource.Name = "btnSetSource";
            this.btnSetSource.Size = new System.Drawing.Size(75, 23);
            this.btnSetSource.TabIndex = 8;
            this.btnSetSource.Text = "Set Source";
            this.btnSetSource.UseVisualStyleBackColor = true;
            this.btnSetSource.Click += new System.EventHandler(this.btnSetSource_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Source Node";
            // 
            // txbSetSource
            // 
            this.txbSetSource.Location = new System.Drawing.Point(105, 91);
            this.txbSetSource.Name = "txbSetSource";
            this.txbSetSource.Size = new System.Drawing.Size(153, 20);
            this.txbSetSource.TabIndex = 10;
            this.txbSetSource.Text = "0";
            // 
            // btnDeleteNode
            // 
            this.btnDeleteNode.Location = new System.Drawing.Point(371, 54);
            this.btnDeleteNode.Name = "btnDeleteNode";
            this.btnDeleteNode.Size = new System.Drawing.Size(79, 23);
            this.btnDeleteNode.TabIndex = 11;
            this.btnDeleteNode.Text = "DeleteNode";
            this.btnDeleteNode.UseVisualStyleBackColor = true;
            this.btnDeleteNode.Click += new System.EventHandler(this.btnDeleteNode_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(371, 88);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(79, 23);
            this.btnOpenFile.TabIndex = 13;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // txbDest
            // 
            this.txbDest.Location = new System.Drawing.Point(105, 124);
            this.txbDest.Name = "txbDest";
            this.txbDest.Size = new System.Drawing.Size(153, 20);
            this.txbDest.TabIndex = 15;
            this.txbDest.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Destination Node";
            // 
            // btnSourceDest
            // 
            this.btnSourceDest.Location = new System.Drawing.Point(276, 121);
            this.btnSourceDest.Name = "btnSourceDest";
            this.btnSourceDest.Size = new System.Drawing.Size(75, 23);
            this.btnSourceDest.TabIndex = 17;
            this.btnSourceDest.Text = "Path routing";
            this.btnSourceDest.UseVisualStyleBackColor = true;
            this.btnSourceDest.Click += new System.EventHandler(this.btnSourceDest_Click);
            // 
            // cbAlgorithms
            // 
            this.cbAlgorithms.FormattingEnabled = true;
            this.cbAlgorithms.Location = new System.Drawing.Point(105, 16);
            this.cbAlgorithms.Name = "cbAlgorithms";
            this.cbAlgorithms.Size = new System.Drawing.Size(153, 21);
            this.cbAlgorithms.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Algorithms Routing";
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveFile.Location = new System.Drawing.Point(371, 121);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(79, 23);
            this.btnSaveFile.TabIndex = 12;
            this.btnSaveFile.Text = "Save File";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // txbFile
            // 
            this.txbFile.Location = new System.Drawing.Point(15, 156);
            this.txbFile.Name = "txbFile";
            this.txbFile.Size = new System.Drawing.Size(243, 20);
            this.txbFile.TabIndex = 20;
            // 
            // btnFileSend
            // 
            this.btnFileSend.Location = new System.Drawing.Point(276, 154);
            this.btnFileSend.Name = "btnFileSend";
            this.btnFileSend.Size = new System.Drawing.Size(29, 23);
            this.btnFileSend.TabIndex = 21;
            this.btnFileSend.Text = "...";
            this.btnFileSend.UseVisualStyleBackColor = true;
            this.btnFileSend.Click += new System.EventHandler(this.btnFileSend_Click);
            // 
            // btnSendData
            // 
            this.btnSendData.Location = new System.Drawing.Point(371, 154);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(79, 23);
            this.btnSendData.TabIndex = 22;
            this.btnSendData.Text = "Send";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Blue;
            this.btnColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColor.Location = new System.Drawing.Point(311, 155);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(54, 21);
            this.btnColor.TabIndex = 23;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnSetupConnect
            // 
            this.btnSetupConnect.Location = new System.Drawing.Point(371, 15);
            this.btnSetupConnect.Name = "btnSetupConnect";
            this.btnSetupConnect.Size = new System.Drawing.Size(79, 24);
            this.btnSetupConnect.TabIndex = 24;
            this.btnSetupConnect.Text = "Setup";
            this.btnSetupConnect.UseVisualStyleBackColor = true;
            this.btnSetupConnect.Click += new System.EventHandler(this.btnSetupConnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1018, 587);
            this.Controls.Add(this.btnSetupConnect);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnSendData);
            this.Controls.Add(this.btnFileSend);
            this.Controls.Add(this.txbFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbAlgorithms);
            this.Controls.Add(this.btnSourceDest);
            this.Controls.Add(this.txbDest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.btnDeleteNode);
            this.Controls.Add(this.txbSetSource);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSetSource);
            this.Controls.Add(this.btnCreateNode);
            this.Controls.Add(this.btnStepBack);
            this.Controls.Add(this.btnDeleteData);
            this.Controls.Add(this.btnStepRun);
            this.Controls.Add(this.btnRouting);
            this.Controls.Add(this.dgvNode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Shostest Path Routing";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNode;
        private System.Windows.Forms.Button btnRouting;
        private System.Windows.Forms.Button btnStepRun;
        private System.Windows.Forms.Button btnDeleteData;
        private System.Windows.Forms.Button btnStepBack;
        private System.Windows.Forms.Button btnCreateNode;
        private System.Windows.Forms.Button btnSetSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbSetSource;
        private System.Windows.Forms.Button btnDeleteNode;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox txbDest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSourceDest;
        private System.Windows.Forms.ComboBox cbAlgorithms;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbFile;
        private System.Windows.Forms.Button btnFileSend;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnSetupConnect;
    }
}

