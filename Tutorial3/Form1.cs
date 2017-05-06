using System;
using System.Windows.Forms;
using NAudio.Wave;
namespace Tutorial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームの初期設定。
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // ボタンの初期状態
            this.Text = @"Tutorial 3";
            linkLabel1.Text = "https://www.youtuabe.com/watch?v=l9sT26LEiD4";
        }

        #region Member
        #endregion


        /// <summary>
        /// フォームのクロージング処理
        /// Wave関連オブジェクトのDispose処理を担当
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        /// <summary>
        /// MP3ファイルをWAVファイルへコンバート
        /// </summary>
        private void button_Convert_Click(object sender, EventArgs e)
        {

            // 1. Open MP3 File
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Mp3 File (*.mp3)|*.mp3;";

            if (open.ShowDialog() != DialogResult.OK) return;


            // 2. Select Save WAV File
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "WAV File (*.wav)|*.wav;";

            if (save.ShowDialog() != DialogResult.OK) return;


            // 3. Convert mp3 -> wav
            using (Mp3FileReader mp3 = new Mp3FileReader(open.FileName))
            {
                using(WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(mp3))
                {
                    WaveFileWriter.CreateWaveFile(save.FileName, pcm);
                }
            }



        }
    }
}
