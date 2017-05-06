using System;
using System.Windows.Forms;
using NAudio.Wave;
using System.Drawing;

namespace Tutorial
{
    public partial class Form1 : Form
    {
        #region form
        public Form1()
        {
            InitializeComponent();
        }


        #endregion

        #region Member
        private DirectSoundOut output = null;
        private BlockAlignReductionStream stream = null;
        #endregion


        private void button_OpenWave_Click(object sender, EventArgs e)
        {


        }


        /// <summary>
        /// フォームのクロージング処理
        /// Wave関連オブジェクトのDispose処理を担当
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // WAV File Open
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "WAV File (*.wav)|*.wav;";
            if (open.ShowDialog() != DialogResult.OK) return;

            waveViewer1.BackColor = Color.White;
            waveViewer1.SamplesPerPixel = 400;
            waveViewer1.StartPosition = 40000;
            waveViewer1.WaveStream = new WaveFileReader(open.FileName);

            chart1.Series.Add("wave");
            chart1.Series["wave"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chart1.Series["wave"].ChartArea = "ChartArea1";

            WaveChannel32 wave = new WaveChannel32(new WaveFileReader(open.FileName));

            byte[] buffer = new byte[16384];
            int read = 0;
            while(wave.Position < wave.Length)
            {
                read = wave.Read(buffer, 0, 16384);

                for (int i = 0; i < read/4; i++)
                {
                    chart1.Series["wave"].Points.Add(BitConverter.ToSingle(buffer, i * 4));
                }
            }



        }
    }

}
