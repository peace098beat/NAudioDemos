using System;

using NAudio.Wave;

namespace Tutorial
{
    public class EffectStream : WaveStream
    {
        public WaveStream SourceStream { get; set; }

        public EffectStream(WaveStream stream)
        {
            this.SourceStream = stream;
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

        public override int Read(byte[] buffer, int offset, int count)
        {
            Console.WriteLine("DirectSoundOut request {0} bytes", count);
            return this.SourceStream.Read(buffer, offset, count);
        }
    }
}
