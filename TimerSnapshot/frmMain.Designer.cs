namespace TimerSnapshot
{
	partial class frmMain
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
			this.VSP = new AForge.Controls.VideoSourcePlayer();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnSnapshot = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.btnTimer = new System.Windows.Forms.Button();
			this.lblCntDwn = new System.Windows.Forms.Label();
			this.lblDebug = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// VSP
			// 
			this.VSP.Location = new System.Drawing.Point(0, 0);
			this.VSP.Name = "VSP";
			this.VSP.Size = new System.Drawing.Size(395, 241);
			this.VSP.TabIndex = 0;
			this.VSP.Text = "videoSourcePlayer1";
			this.VSP.VideoSource = null;
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(8, 259);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(69, 29);
			this.btnStart.TabIndex = 1;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnStop
			// 
			this.btnStop.Enabled = false;
			this.btnStop.Location = new System.Drawing.Point(92, 259);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(69, 29);
			this.btnStop.TabIndex = 2;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// btnSnapshot
			// 
			this.btnSnapshot.Enabled = false;
			this.btnSnapshot.Location = new System.Drawing.Point(176, 259);
			this.btnSnapshot.Name = "btnSnapshot";
			this.btnSnapshot.Size = new System.Drawing.Size(69, 29);
			this.btnSnapshot.TabIndex = 3;
			this.btnSnapshot.Text = "Snapshot";
			this.btnSnapshot.UseVisualStyleBackColor = true;
			this.btnSnapshot.Click += new System.EventHandler(this.btnSnapshot_Click);
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// btnTimer
			// 
			this.btnTimer.Enabled = false;
			this.btnTimer.Location = new System.Drawing.Point(260, 259);
			this.btnTimer.Name = "btnTimer";
			this.btnTimer.Size = new System.Drawing.Size(69, 29);
			this.btnTimer.TabIndex = 4;
			this.btnTimer.Text = "Timer";
			this.btnTimer.UseVisualStyleBackColor = true;
			this.btnTimer.Click += new System.EventHandler(this.btnTimer_Click);
			// 
			// lblCntDwn
			// 
			this.lblCntDwn.AutoSize = true;
			this.lblCntDwn.Location = new System.Drawing.Point(338, 273);
			this.lblCntDwn.Name = "lblCntDwn";
			this.lblCntDwn.Size = new System.Drawing.Size(48, 13);
			this.lblCntDwn.TabIndex = 5;
			this.lblCntDwn.Text = "Disabled";
			// 
			// lblDebug
			// 
			this.lblDebug.AutoSize = true;
			this.lblDebug.Location = new System.Drawing.Point(12, 300);
			this.lblDebug.Name = "lblDebug";
			this.lblDebug.Size = new System.Drawing.Size(25, 13);
			this.lblDebug.TabIndex = 6;
			this.lblDebug.Text = "Info";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(410, 325);
			this.Controls.Add(this.lblDebug);
			this.Controls.Add(this.lblCntDwn);
			this.Controls.Add(this.btnTimer);
			this.Controls.Add(this.btnSnapshot);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.VSP);
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.Text = "TimerSnapshot";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private AForge.Controls.VideoSourcePlayer VSP;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnSnapshot;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button btnTimer;
		private System.Windows.Forms.Label lblCntDwn;
		private System.Windows.Forms.Label lblDebug;
	}
}

