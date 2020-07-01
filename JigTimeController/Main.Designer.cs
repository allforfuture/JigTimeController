namespace JigTimeController
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerCheckJig = new System.Windows.Forms.Timer(this.components);
            this.gbOvenRight = new System.Windows.Forms.GroupBox();
            this.gbOvenLeft = new System.Windows.Forms.GroupBox();
            this.lblRunningState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerCheckJig
            // 
            this.timerCheckJig.Enabled = true;
            this.timerCheckJig.Tick += new System.EventHandler(this.timerCheckJig_Tick);
            // 
            // gbRight
            // 
            this.gbOvenRight.Location = new System.Drawing.Point(555, 64);
            this.gbOvenRight.Name = "gbRight";
            this.gbOvenRight.Size = new System.Drawing.Size(136, 109);
            this.gbOvenRight.TabIndex = 70;
            this.gbOvenRight.TabStop = false;
            // 
            // gbLeft
            // 
            this.gbOvenLeft.Location = new System.Drawing.Point(29, 85);
            this.gbOvenLeft.Name = "gbLeft";
            this.gbOvenLeft.Size = new System.Drawing.Size(419, 254);
            this.gbOvenLeft.TabIndex = 69;
            this.gbOvenLeft.TabStop = false;
            // 
            // lblRunningState
            // 
            this.lblRunningState.AutoSize = true;
            this.lblRunningState.BackColor = System.Drawing.Color.Green;
            this.lblRunningState.Location = new System.Drawing.Point(526, 255);
            this.lblRunningState.Name = "lblRunningState";
            this.lblRunningState.Size = new System.Drawing.Size(41, 12);
            this.lblRunningState.TabIndex = 72;
            this.lblRunningState.Text = "label1";
            this.lblRunningState.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblRunningState_MouseDown);
            this.lblRunningState.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblRunningState_MouseMove);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblRunningState);
            this.Controls.Add(this.gbOvenRight);
            this.Controls.Add(this.gbOvenLeft);
            this.Name = "Main";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerCheckJig;
        private System.Windows.Forms.GroupBox gbOvenRight;
        private System.Windows.Forms.GroupBox gbOvenLeft;
        private System.Windows.Forms.Label lblRunningState;
    }
}

