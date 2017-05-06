using System;
using System.Collections.Generic;
using NAudio.Wave;

namespace Tutorial
{
    public class EffectStream : WaveStream
    {
        public WaveStream SourceStream { get; set; }

        public List<IEffect> Effects { get; set; }

        public EffectStream(WaveStream stream)
        {
            this.SourceStream = stream;
            this.Effects = new List<IEffect>();
        }

        public override WaveFormat WaveFormat
        {
            get { return this.SourceStream.WaveFormat; }
        }

        public override long Length
        {
            get { return SourceStream.Length; }
        }

        public override long Position
        {
            get { return this.SourceStream.Position; }
            set { this.SourceStream.Position = value; }
        }

        private int channel = 0;

        public override int Read(byte[] buffer, int offset, int count)
        {
            //*****************************************************************//
            // ここで信号処理をする
            //*****************************************************************//
            Console.WriteLine("DirectSoundOut request {0} bytes", count);

            int read =  this.SourceStream.Read(buffer, offset, count);

            // 以下信号処理
            for (int i = 0; i < read/4; i++)
            {

                // float = single = 32bit
                float sample = BitConverter.ToSingle(buffer, i * 4); // Single=4Byte


                // エフェクト処理
                if (Effects.Count == WaveFormat.Channels)
                {
                    sample = Effects[channel].ApplyEffect(sample);
                    channel = (channel + 1) % WaveFormat.Channels;
                }

                // float -> byte列に変換
                byte[] bytes = BitConverter.GetBytes(sample); // 4Byteなので,bytes[4]

                // コピー
                //bytes.CopyTo(buffer, i * 4); // 遅い
                buffer[i * 4 + 0] = bytes[0];
                buffer[i * 4 + 1] = bytes[1];
                buffer[i * 4 + 2] = bytes[2];
                buffer[i * 4 + 3] = bytes[3];
            }

            return read;
        }
    }
}
