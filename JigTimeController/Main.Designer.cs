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
            this.Jig_1_1 = new System.Windows.Forms.Label();
            this.Jig_1_2 = new System.Windows.Forms.Label();
            this.txtJig_1_1 = new System.Windows.Forms.TextBox();
            this.txtJig_1_2 = new System.Windows.Forms.TextBox();
            this.timerCheckJig = new System.Windows.Forms.Timer(this.components);
            this.lblRunningState = new System.Windows.Forms.Label();
            this.groupBoxOven1 = new System.Windows.Forms.GroupBox();
            this.groupBoxOven1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Jig_1_1
            // 
            this.Jig_1_1.AutoSize = true;
            this.Jig_1_1.Location = new System.Drawing.Point(25, 29);
            this.Jig_1_1.Name = "Jig_1_1";
            this.Jig_1_1.Size = new System.Drawing.Size(35, 12);
            this.Jig_1_1.TabIndex = 0;
            this.Jig_1_1.Text = "(1,1)";
            // 
            // Jig_1_2
            // 
            this.Jig_1_2.AutoSize = true;
            this.Jig_1_2.Location = new System.Drawing.Point(18, 100);
            this.Jig_1_2.Name = "Jig_1_2";
            this.Jig_1_2.Size = new System.Drawing.Size(35, 12);
            this.Jig_1_2.TabIndex = 1;
            this.Jig_1_2.Text = "(1,2)";
            // 
            // txtJig_1_1
            // 
            this.txtJig_1_1.Location = new System.Drawing.Point(20, 52);
            this.txtJig_1_1.Name = "txtJig_1_1";
            this.txtJig_1_1.Size = new System.Drawing.Size(40, 21);
            this.txtJig_1_1.TabIndex = 64;
            this.txtJig_1_1.Text = "159";
            this.txtJig_1_1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Jig_KeyDown);
            // 
            // txtJig_1_2
            // 
            this.txtJig_1_2.Location = new System.Drawing.Point(20, 115);
            this.txtJig_1_2.Name = "txtJig_1_2";
            this.txtJig_1_2.Size = new System.Drawing.Size(40, 21);
            this.txtJig_1_2.TabIndex = 65;
            this.txtJig_1_2.Text = "149";
            this.txtJig_1_2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Jig_KeyDown);
            // 
            // timerCheckJig
            // 
            this.timerCheckJig.Enabled = true;
            this.timerCheckJig.Tick += new System.EventHandler(this.timerCheckJig_Tick);
            // 
            // lblRunningState
            // 
            this.lblRunningState.AutoSize = true;
            this.lblRunningState.Font = new System.Drawing.Font("宋体", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRunningState.ForeColor = System.Drawing.Color.Green;
            this.lblRunningState.Location = new System.Drawing.Point(697, 9);
            this.lblRunningState.Name = "lblRunningState";
            this.lblRunningState.Size = new System.Drawing.Size(91, 97);
            this.lblRunningState.TabIndex = 66;
            this.lblRunningState.Text = "R";
            // 
            // groupBoxOven1
            // 
            this.groupBoxOven1.Controls.Add(this.txtJig_1_2);
            this.groupBoxOven1.Controls.Add(this.Jig_1_1);
            this.groupBoxOven1.Controls.Add(this.Jig_1_2);
            this.groupBoxOven1.Controls.Add(this.txtJig_1_1);
            this.groupBoxOven1.Location = new System.Drawing.Point(12, 12);
            this.groupBoxOven1.Name = "groupBoxOven1";
            this.groupBoxOven1.Size = new System.Drawing.Size(679, 426);
            this.groupBoxOven1.TabIndex = 67;
            this.groupBoxOven1.TabStop = false;
            this.groupBoxOven1.Text = "Oven1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxOven1);
            this.Controls.Add(this.lblRunningState);
            this.Name = "Main";
            this.Text = "Form1";
            this.groupBoxOven1.ResumeLayout(false);
            this.groupBoxOven1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Jig_1_1;
        private System.Windows.Forms.Label Jig_1_2;
        private System.Windows.Forms.TextBox txtJig_1_1;
        private System.Windows.Forms.TextBox txtJig_1_2;
        private System.Windows.Forms.Timer timerCheckJig;
        private System.Windows.Forms.Label lblRunningState;
        private System.Windows.Forms.GroupBox groupBoxOven1;
    }
}

