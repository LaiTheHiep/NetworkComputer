namespace ShortestPathRouting
{
    partial class InforNode
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbNodeName = new System.Windows.Forms.Label();
            this.lbnumQueue = new System.Windows.Forms.Label();
            this.lbnumData = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.linkDownload = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Node";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Queue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Status";
            // 
            // lbNodeName
            // 
            this.lbNodeName.AutoSize = true;
            this.lbNodeName.Location = new System.Drawing.Point(119, 29);
            this.lbNodeName.Name = "lbNodeName";
            this.lbNodeName.Size = new System.Drawing.Size(61, 13);
            this.lbNodeName.TabIndex = 4;
            this.lbNodeName.Text = "NodeName";
            // 
            // lbnumQueue
            // 
            this.lbnumQueue.AutoSize = true;
            this.lbnumQueue.Location = new System.Drawing.Point(119, 61);
            this.lbnumQueue.Name = "lbnumQueue";
            this.lbnumQueue.Size = new System.Drawing.Size(13, 13);
            this.lbnumQueue.TabIndex = 5;
            this.lbnumQueue.Text = "0";
            // 
            // lbnumData
            // 
            this.lbnumData.AutoSize = true;
            this.lbnumData.Location = new System.Drawing.Point(119, 95);
            this.lbnumData.Name = "lbnumData";
            this.lbnumData.Size = new System.Drawing.Size(13, 13);
            this.lbnumData.TabIndex = 6;
            this.lbnumData.Text = "0";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(119, 128);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(64, 13);
            this.lbStatus.TabIndex = 7;
            this.lbStatus.Text = "Receiving...";
            // 
            // linkDownload
            // 
            this.linkDownload.AutoSize = true;
            this.linkDownload.Location = new System.Drawing.Point(46, 169);
            this.linkDownload.Name = "linkDownload";
            this.linkDownload.Size = new System.Drawing.Size(78, 13);
            this.linkDownload.TabIndex = 8;
            this.linkDownload.TabStop = true;
            this.linkDownload.Text = "fileReceive.pdf";
            this.linkDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDownload_LinkClicked);
            // 
            // InforNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 224);
            this.Controls.Add(this.linkDownload);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lbnumData);
            this.Controls.Add(this.lbnumQueue);
            this.Controls.Add(this.lbNodeName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InforNode";
            this.Text = "InforNode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbNodeName;
        private System.Windows.Forms.Label lbnumQueue;
        private System.Windows.Forms.Label lbnumData;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.LinkLabel linkDownload;
    }
}