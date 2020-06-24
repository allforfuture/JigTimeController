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
            this.button1 = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnTest = new System.Windows.Forms.Button();
            this.groupBoxOven1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
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
            this.groupBoxOven1.Size = new System.Drawing.Size(160, 170);
            this.groupBoxOven1.TabIndex = 67;
            this.groupBoxOven1.TabStop = false;
            this.groupBoxOven1.Text = "Oven1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(697, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 68;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(178, 41);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(513, 397);
            this.dgv.TabIndex = 66;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(178, 12);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 69;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxOven1);
            this.Controls.Add(this.lblRunningState);
            this.Name = "Main";
            this.Text = "Form1";
            this.groupBoxOven1.ResumeLayout(false);
            this.groupBoxOven1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnTest;
    }
}

