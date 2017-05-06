using System;
using System.Windows.Forms;
using NAudio.Wave;
using System.Collections.Generic;

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
        /// フォームのクロージング処理
        /// Wave関連オブジェクトのDispose処理を担当
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        #endregion


        private void button_Refresh_Click(object sender, EventArgs e)
        {

            // SetUp WaveIn Devices
            List<WaveInCapabilities> sources = new List<WaveInCapabilities>();

            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                sources.Add(WaveIn.GetCapabilities(i));
            }

            listView_Sources.Items.Clear();

            foreach (var source in sources)
            {
                ListViewItem item = new ListViewItem(source.ProductName);
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, source.Channels.ToString()));

                listView_Sources.Items.Add(item);
            }

        }

        #region Member
        private NAudio.Wave.WaveIn sourceStream = null;
        private NAudio.Wave.DirectSoundOut waveOut = null;
        private NAudio.Wave.WaveFileWriter waveWriter = null;
        #endregion


        private void button_Start_Click(object sender, EventArgs e)
        {
            if (listView_Sources.SelectedItems.Count == 0) return;

            // オーディオチェーン : WaveIn(rec) -> WaveInProvider -> WaveOut(DirectSoundOut)

            int deviceNumber = listView_Sources.SelectedItems[0].Index;

            // waveIn Select Recording Device
            sourceStream = new NAudio.Wave.WaveIn();
            sourceStream.DeviceNumber = deviceNumber;
            sourceStream.WaveFormat = new NAudio.Wave.WaveFormat(44100, WaveIn.GetCapabilities(deviceNumber).Channels);

            WaveInProvider waveIn = new NAudio.Wave.WaveInProvider(sourceStream); // ?

            // waveOut
            waveOut = new DirectSoundOut();
            waveOut.Init(waveIn);

            sourceStream.StartRecording();
            waveOut.Play();

        }

        private void button_ToWav_Click(object sender, EventArgs e)
        {
            if (listView_Sources.SelectedItems.Count == 0) return;

            // オーディオチェーン : WaveIn(rec) -> Callback() -> waveWriter 

            // 録音先のWavファイル
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Wave File (*.wav)|*.wav;";
            if (save.ShowDialog() != DialogResult.OK) return;

            // 録音デバイス番号
            int deviceNumber = listView_Sources.SelectedItems[0].Index;

            // waveIn Select Recording Device
            sourceStream = new WaveIn();
            sourceStream.DeviceNumber = deviceNumber;
            sourceStream.WaveFormat = new WaveFormat(44100, WaveIn.GetCapabilities(deviceNumber).Channels);

            // 録音のコールバックkな数
            sourceStream.DataAvailable += new EventHandler<WaveInEventArgs>(sourceStream_DataAvailable);

            // wave出力
            waveWriter = new WaveFileWriter(save.FileName, sourceStream.WaveFormat);

            // 録音開始
            sourceStream.StartRecording();

        }
        private void sourceStream_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveWriter == null) return;

            waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
            waveWriter.Flush();
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            waveOut?.Stop();
            waveOut?.Dispose();
            waveOut = null;

            sourceStream?.StopRecording();
            sourceStream?.Dispose();
            sourceStream = null;

            waveWriter?.Dispose();
            waveWriter = null;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            button_Stop_Click(sender, e);
            this.Close();
        }


    }

}
