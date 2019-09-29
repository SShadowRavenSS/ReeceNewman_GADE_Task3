namespace Units
{
    partial class frmBattleSim
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.lblRound = new System.Windows.Forms.Label();
            this.lblMap = new System.Windows.Forms.Label();
            this.rtxUnitInfo = new System.Windows.Forms.RichTextBox();
            this.tmrOnly = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblTimerText = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 415);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(133, 414);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Location = new System.Drawing.Point(13, 13);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(39, 13);
            this.lblRound.TabIndex = 2;
            this.lblRound.Text = "Round";
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMap.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMap.Location = new System.Drawing.Point(13, 44);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(70, 20);
            this.lblMap.TabIndex = 3;
            this.lblMap.Text = "label1";
            // 
            // rtxUnitInfo
            // 
            this.rtxUnitInfo.Location = new System.Drawing.Point(344, 12);
            this.rtxUnitInfo.Name = "rtxUnitInfo";
            this.rtxUnitInfo.Size = new System.Drawing.Size(444, 425);
            this.rtxUnitInfo.TabIndex = 4;
            this.rtxUnitInfo.Text = "";
            // 
            // tmrOnly
            // 
            this.tmrOnly.Interval = 1000;
            this.tmrOnly.Tick += new System.EventHandler(this.playGame);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(256, 13);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(13, 13);
            this.lblTimer.TabIndex = 5;
            this.lblTimer.Text = "0";
            // 
            // lblTimerText
            // 
            this.lblTimerText.AutoSize = true;
            this.lblTimerText.Location = new System.Drawing.Point(203, 13);
            this.lblTimerText.Name = "lblTimerText";
            this.lblTimerText.Size = new System.Drawing.Size(42, 13);
            this.lblTimerText.TabIndex = 6;
            this.lblTimerText.Text = "Timer : ";
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(242, 414);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 7;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(242, 371);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmBattleSim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.lblTimerText);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.rtxUnitInfo);
            this.Controls.Add(this.lblMap);
            this.Controls.Add(this.lblRound);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Name = "frmBattleSim";
            this.Text = "Battle Simulation";
            this.Load += new System.EventHandler(this.frmBattleSim_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.RichTextBox rtxUnitInfo;
        private System.Windows.Forms.Timer tmrOnly;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblTimerText;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnSave;
    }
}

