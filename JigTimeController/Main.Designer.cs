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
            this.Oven2 = new System.Windows.Forms.GroupBox();
            this.Oven1 = new System.Windows.Forms.GroupBox();
            this.panelRunningState = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // timerCheckJig
            // 
            this.timerCheckJig.Enabled = true;
            this.timerCheckJig.Tick += new System.EventHandler(this.timerCheckJig_Tick);
            // 
            // Oven2
            // 
            this.Oven2.Location = new System.Drawing.Point(555, 64);
            this.Oven2.Name = "Oven2";
            this.Oven2.Size = new System.Drawing.Size(136, 109);
            this.Oven2.TabIndex = 70;
            this.Oven2.TabStop = false;
            this.Oven2.Text = "Oven2";
            // 
            // Oven1
            // 
            this.Oven1.Location = new System.Drawing.Point(29, 85);
            this.Oven1.Name = "Oven1";
            this.Oven1.Size = new System.Drawing.Size(419, 254);
            this.Oven1.TabIndex = 69;
            this.Oven1.TabStop = false;
            this.Oven1.Text = "Oven1";
            // 
            // panelRunningState
            // 
            this.panelRunningState.Location = new System.Drawing.Point(697, 12);
            this.panelRunningState.Name = "panelRunningState";
            this.panelRunningState.Size = new System.Drawing.Size(100, 100);
            this.panelRunningState.TabIndex = 71;
            this.panelRunningState.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelRunningState_MouseDown);
            this.panelRunningState.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelRunningState_MouseMove);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelRunningState);
            this.Controls.Add(this.Oven2);
            this.Controls.Add(this.Oven1);
            this.Name = "Main";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerCheckJig;
        private System.Windows.Forms.GroupBox Oven2;
        private System.Windows.Forms.GroupBox Oven1;
        private System.Windows.Forms.Panel panelRunningState;
    }
}

