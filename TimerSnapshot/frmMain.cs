using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using AForge.Video;
using AForge.Video.DirectShow;

namespace TimerSnapshot
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		private VideoCaptureDevice src = new VideoCaptureDevice();
		FilterInfoCollection devs = new FilterInfoCollection(FilterCategory.VideoInputDevice);
		private int spanOfShots = 10;
		private int countDown = 10;
		private string lastFileName = "";
		private int picWidth = 640;
		private int picHeight = 480;
		private int threshold = 640 * 480 * 20;
		private string strPath = @"D:\snapshots\";

		private void frmMain_Load(object sender, EventArgs e)
		{
			this.Top = 0;
			this.Left = 0;
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			src = new VideoCaptureDevice(devs[0].MonikerString);
			VSP.VideoSource = src;
			VideoCapabilities[] VCap = src.VideoCapabilities;
			picHeight = VCap[0].FrameSize.Height;
			picWidth = VCap[0].FrameSize.Width;
			VSP.Start();
			lblDebug.Text = "Preview startd, resolution = " + picWidth.ToString() + "X" + picHeight.ToString();
			threshold = picWidth * picHeight * 20;
			btnStart.Enabled = false;
			btnStop.Enabled = true;
			btnSnapshot.Enabled = true;
			btnTimer.Enabled = true;
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			VSP.SignalToStop();
			VSP.WaitForStop();
			btnStart.Enabled = true;
			btnStop.Enabled = false;
			btnSnapshot.Enabled = false;
			btnTimer.Enabled = false;
			timer1.Enabled = false;
			lblDebug.Text = "Preview stopped";
			VSP.Visible = true;
			lblCntDwn.Text = "Disabled";
			countDown = spanOfShots;
		}

		private void sayCheese()
		{
			Bitmap snapshot = new Bitmap(640, 480);
			string strFilename = "P" + DateTime.Now.Year.ToString();
			if (DateTime.Now.Month.ToString().Length == 1) strFilename += "0" + DateTime.Now.Month.ToString(); else strFilename += DateTime.Now.Month.ToString();
			if (DateTime.Now.Day.ToString().Length == 1) strFilename += "0" + DateTime.Now.Day.ToString(); else strFilename += DateTime.Now.Day.ToString();
			if (DateTime.Now.Hour.ToString().Length == 1) strFilename += "0" + DateTime.Now.Hour.ToString(); else strFilename += DateTime.Now.Hour.ToString();
			if (DateTime.Now.Minute.ToString().Length == 1) strFilename += "0" + DateTime.Now.Minute.ToString(); else strFilename += DateTime.Now.Minute.ToString();
			if (DateTime.Now.Second.ToString().Length == 1) strFilename += "0" + DateTime.Now.Second.ToString(); else strFilename += DateTime.Now.Second.ToString();
			strFilename += ".jpg";
			string strAdded = DateTime.Now.Year.ToString() + "-";
			if (DateTime.Now.Month.ToString().Length == 1) strAdded += "0" + DateTime.Now.Month.ToString() + "-"; else strAdded += DateTime.Now.Month.ToString() + "-";
			if (DateTime.Now.Day.ToString().Length == 1) strAdded += "0" + DateTime.Now.Day.ToString() + " "; else strAdded += DateTime.Now.Day.ToString() + " ";
			if (DateTime.Now.Hour.ToString().Length == 1) strAdded += "0" + DateTime.Now.Hour.ToString() + ":"; else strAdded += DateTime.Now.Hour.ToString() + ":";
			if (DateTime.Now.Minute.ToString().Length == 1) strAdded += "0" + DateTime.Now.Minute.ToString() + ":"; else strAdded += DateTime.Now.Minute.ToString() + ":";
			if (DateTime.Now.Second.ToString().Length == 1) strAdded += "0" + DateTime.Now.Second.ToString(); else strAdded += DateTime.Now.Second.ToString();
			if (VSP.IsRunning) {
				snapshot = VSP.GetCurrentVideoFrame();
				Graphics g = Graphics.FromImage(snapshot);
				RectangleF rectf = new RectangleF(10, 10, 300, 20);
				g.SmoothingMode = SmoothingMode.AntiAlias;
				g.InterpolationMode = InterpolationMode.HighQualityBicubic;
				g.PixelOffsetMode = PixelOffsetMode.HighQuality;
				g.DrawString(strAdded, new Font("Courier New", 12), Brushes.Red, rectf);
				g.Flush();
				snapshot.Save(strPath + strFilename, System.Drawing.Imaging.ImageFormat.Jpeg);
				g.Dispose();
			}
			snapshot.Dispose();
			//compare this snapshot to last one, targeting on removing the old one if there is actually no difference
			if (lastFileName == "")
			{
				lastFileName = strFilename;
			}
			else
			{
				bool isAlmostSame = almostSame(strPath + lastFileName, strPath + strFilename);
				if (!isAlmostSame)
				{
					lastFileName = strFilename;
					//shorten the span of snapshots if the sanpshot is different with preview one
					spanOfShots = 5;
				}
				else
				{
					spanOfShots = 10;
					try { 
						File.Delete(strPath + strFilename); // delete this snapshot if this one is almost identical to the preview one
					}
					catch
					{
					}
				}
			}
		}

		private bool almostSame(string F1, string F2)
		{
			bool ret = true;
			int cumu = 0;
			Bitmap BM1 = new Bitmap(F1);
			Bitmap BM2 = new Bitmap(F2);
			Color Clor1 = new Color();
			Color Clor2 = new Color();
			for (int i = 0; i < BM1.Width; i++) {
				for (int j = 0; j < BM1.Height; j++) {
					Clor1 = BM1.GetPixel(i, j);
					Clor2 = BM2.GetPixel(i, j);
					cumu += Math.Abs(Clor1.R - Clor2.R) + Math.Abs(Clor1.B - Clor2.B) + Math.Abs(Clor1.G - Clor2.G);
					if (cumu > threshold) {
						ret = false;
						break;
					}
				}
				if (cumu > threshold) break;
			}
			double avg = cumu / picHeight / picWidth * 1.0d;
			if (avg > 20.0d) ret = false;
			BM1.Dispose();
			BM2.Dispose();
			return ret;
		}

		private void btnSnapshot_Click(object sender, EventArgs e)
		{
			sayCheese();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			countDown--;
			lblCntDwn.Text = countDown.ToString();
			if (countDown == 0) {
				lblDebug.Text = "Snapshot at " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
				sayCheese();
				countDown = spanOfShots;
			}
			Application.DoEvents();
		}

		private void btnTimer_Click(object sender, EventArgs e)
		{
			timer1.Enabled = !timer1.Enabled;
			if(!timer1.Enabled) {
				lblCntDwn.Text = "Disabled";
				countDown = spanOfShots;
				VSP.Visible = true;
				lblDebug.Text = "Periodical snapshots stopped...";
			}
			else
			{
				//hide the preview window to get much more precise timer
				VSP.Visible = false;
				lblDebug.Text = "Periodical snapshots started...";
			}
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			VSP.SignalToStop();
			VSP.WaitForStop();
		}
	}
}
