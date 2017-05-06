## チュートリアル その4



[http://hope-is-dream.hatenablog.com/entry/2017/05/05/NAudioContents:embed:cite]




### NAudioをつかってSin音を生成

[C# Audio Tutorial 2 - MP3/WAV File with NAudio](https://www.youtube.com/watch?v=2ij2vqgprU0)  


```cs

// 再生デバイス
private DirectSoundOut output = null;
private BlockAlignReductionStream stream = null;

// オーディオチェイン
WaveTone tone = new WaveTone(1000, 0.1);
stream = new BlockAlignReductionStream(tone);

output = new DirectSoundOut();
output.Init(stream);
output.Play();

// SinWaveを生成
for (int i = 0; i < samples; i++)
{
    double sine = amplitude * Math.Sin(Math.PI * 2 * frequency * time);
    time += 1.0 / 44100;

    short truncated = (short)Math.Round(sine * (Math.Pow(2, 15) - 1)); //16bit

    buffer[i * 2] = (byte)(truncated & 0x00ff); // 下半分を取り出し 8bit
    buffer[i * 2 + 1] = (byte)((truncated & 0xff00) >> 8); // 上半分を取り出してシフト 8bit
}

```




```cs
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
            this.Text = @"Tutorial 4";
            linkLabel1.Text = "https://www.youtube.com/watch?v=Tumpkl-xJuA";
        }

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

        private void button_StartTone_Click(object sender, EventArgs e)
        {
            WaveTone tone = new WaveTone(1000, 0.1);
            stream = new BlockAlignReductionStream(tone);

            output = new DirectSoundOut();
            output.Init(stream);
            output.Play();

        }

        private void button_StopTone_Click(object sender, EventArgs e)
        {
            output?.Stop();
        }
    }

    /// <summary>
    /// 
    /// WaveStreamは抽象クラス
    /// </summary>
    public class WaveTone : WaveStream
    {
        private double frequency;
        private double amplitude;
        private double time;

        public WaveTone(double f, double a)
        {
            this.time = 0;
            this.frequency = f;
            this.amplitude = a;
        }


        public override long Position { get; set; }

        public override long Length
        {
            get
            {
                return long.MaxValue;
            }
        }

        public override WaveFormat WaveFormat
        {
            get { return new WaveFormat(44100, 32, 1); }
        }

        /// <summary>
        /// </summary>
        public override int Read(byte[] buffer, int offset, int count)
        {
            // byte(8bit)
            // short(16bit)

            int samples = count / 2; // ?
            for (int i = 0; i < samples; i++)
            {
                double sine = amplitude * Math.Sin(Math.PI * 2 * frequency * time);
                time += 1.0 / 44100;

                short truncated = (short)Math.Round(sine * (Math.Pow(2, 15) - 1)); //16bit

                buffer[i * 2] = (byte)(truncated & 0x00ff); // 下半分を取り出し 8bit
                buffer[i * 2 + 1] = (byte)((truncated & 0xff00) >> 8); // 上半分を取り出してシフト 8bit
            }

            return count;
        }
    }
}


```