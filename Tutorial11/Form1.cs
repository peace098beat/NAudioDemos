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
        #endregion


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //// WAV File Open
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "WAV File (*.wav)|*.wav;";
            if (open.ShowDialog() != DialogResult.OK) return;

            customWaveViewer1.WaveStream = new WaveFileReader(open.FileName);
            customWaveViewer1.FitToScreen();

        }
    }

}
