namespace RPM_SAE_Project1
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
            this.components = new System.ComponentModel.Container();
            this.button_LogData = new System.Windows.Forms.Button();
            this.panel_mSpeedGauge = new System.Windows.Forms.Panel();
            this.panel_mERPMGauge = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_LogData
            // 
            this.button_LogData.Location = new System.Drawing.Point(716, 492);
            this.button_LogData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_LogData.Name = "button_LogData";
            this.button_LogData.Size = new System.Drawing.Size(181, 116);
            this.button_LogData.TabIndex = 0;
            this.button_LogData.Text = "Start Logging Data";
            this.button_LogData.UseVisualStyleBackColor = true;
            this.button_LogData.Click += new System.EventHandler(this.Button_LogData_Click);
            // 
            // panel_mSpeedGauge
            // 
            this.panel_mSpeedGauge.Location = new System.Drawing.Point(490, 30);
            this.panel_mSpeedGauge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_mSpeedGauge.Name = "panel_mSpeedGauge";
            this.panel_mSpeedGauge.Size = new System.Drawing.Size(414, 408);
            this.panel_mSpeedGauge.TabIndex = 1;
            this.panel_mSpeedGauge.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_mSpeedGauge_Paint);
            // 
            // panel_mERPMGauge
            // 
            this.panel_mERPMGauge.Location = new System.Drawing.Point(34, 30);
            this.panel_mERPMGauge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_mERPMGauge.Name = "panel_mERPMGauge";
            this.panel_mERPMGauge.Size = new System.Drawing.Size(414, 408);
            this.panel_mERPMGauge.TabIndex = 2;
            this.panel_mERPMGauge.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_mERPMGauge_Paint);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 453);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Engine RPM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(666, 453);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Speed";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 652);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_mERPMGauge);
            this.Controls.Add(this.panel_mSpeedGauge);
            this.Controls.Add(this.button_LogData);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_LogData;
        private System.Windows.Forms.Panel panel_mSpeedGauge;
        private System.Windows.Forms.Panel panel_mERPMGauge;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

