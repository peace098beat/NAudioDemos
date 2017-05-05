using System;
using System.Windows.Forms;

namespace Tutorial2
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
            // TODO: 初期化関数は別に準備

            button_PauseWav.Enabled = false;
            this.Text = @"Tutorial 2";
            linkLabel1.Text = "https://www.youtube.com/watch?v=2ij2vqgprU0";
        }

        #region Member
        private NAudio.Wave.BlockAlignReductionStream stream = null; 

        private NAudio.Wave.DirectSoundOut output = null;
        #endregion

        /// <summary>
        /// WAVオープンボタン
        /// </summary>
        private void button_OpenWav_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Audio File (*.wav, *.mp3) |*.wav;*.mp3;|All files (*.*)|*.*";

            if (open.ShowDialog() != DialogResult.OK) return;

            DisposeWave();


            if (open.FileName.EndsWith(".mp3"))
            {
                NAudio.Wave.WaveStream pcm = 
                    NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(open.FileName));
                stream = new NAudio.Wave.BlockAlignReductionStream(pcm);

            }
            else if (open.FileName.EndsWith(".wav"))
            {
                NAudio.Wave.WaveStream pcm = new NAudio.Wave.WaveChannel32(new NAudio.Wave.WaveFileReader(open.FileName));
                stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
            }
            else
            {
                MessageBox.Show("Not a correct audio file type.");
                return;
                //throw new InvalidOperationException("Not a correct audio file type.");
            }

            output = new NAudio.Wave.DirectSoundOut();
            output.Init(new NAudio.Wave.WaveChannel32(stream));
            output.Play();

            button_PauseWav.Enabled = true;
        }

        /// <summary>
        /// 再生/一時停止ボタン
        /// </summary>
        private void button_PauseWav_Click(object sender, EventArgs e)
        {
            if (output != null)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing)
                    output.Pause();
                else if (output.PlaybackState == NAudio.Wave.PlaybackState.Paused)
                    output.Play();
            }
        }

        /// <summary>
        /// Wave関連オブジェクトのDispose処理。
        /// </summary>
        private void DisposeWave()
        {
            if (output != null)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing) output.Stop();
                output.Dispose();
                output = null;
            }
            if (stream != null)
            {
                stream.Dispose();
                stream = null;
            }
        }

        /// <summary>
        /// フォームのクロージング処理
        /// Wave関連オブジェクトのDispose処理を担当
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DisposeWave();
        }
    }
}
