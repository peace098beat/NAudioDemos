using System;
using System.Windows.Forms;
using NAudio.Wave;

namespace Tutorial
{
    public partial class Form1 : Form
    {
        #region form
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
            this.Text = @"Tutorial 6 - Audio Loopback using";
            linkLabel1.Text = "https://www.youtube.com/watch?v=BjnTgIdTXwI";
        }

        #endregion

        #region Member
        private DirectSoundOut output = null;
        private BlockAlignReductionStream stream = null;
        #endregion


        /// <summary>
        /// フォームのクロージング処理
        /// Wave関連オブジェクトのDispose処理を担当
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            output?.Dispose();
            output = null;

            stream?.Dispose();
            stream = null;
        }

        private void button_OpenWave_Click(object sender, EventArgs e)
        {
            // WAV File Open
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "WAV File (*.wav)|*.wav;";
            if (open.ShowDialog() != DialogResult.OK) return;

            // Audio Chain
            WaveChannel32 wave = new WaveChannel32(new WaveFileReader(open.FileName));
            EffectStream effect = new EffectStream(wave); // エフェクトをかけるためのパイプライン
            stream = new BlockAlignReductionStream(effect);

            output = new DirectSoundOut(200);
            output.Init(stream);
            output.Play();

        }
    }

}
