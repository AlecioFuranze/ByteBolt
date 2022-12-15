using System;
using System.Text;
using System.Runtime.InteropServices;
using ByteBolt.Core;
using Buffer = ByteBolt.Core.Buffer;

namespace ByteBolt
{
    // creates a byte array, but he frist four byes are for header information
    public class Writer : Buffer
    {
        #region Builder

        public Writer()
        {
            this.m_segement = new Segment(new byte[Default]);
            this.m_position = 0;
        }

        public Writer(int length)
        {
            this.m_segement = new Segment(new byte[length]);
            this.m_position = 0;
        }

        public void Write(Segment values)
        {
            if (values.Count <= 0) return;

            values.CopyTo(m_segement, m_position);
            m_position += values.Count;
        }

        #endregion

        #region Info

        public byte[] ToArray()
        {
            byte[] data = new byte[m_position];
            m_segement.CopyTo(data, 0, m_position);
            return data;
        }
        
        public Segment ToSegment()
        {
            return new Segment(m_segement.Array, m_segement.Offset, m_position);
        }

        #endregion

        #region Write

        public void Write(byte value)
        {
            WriteLine(new byte[1] { value });
        }        

        public void Write(bool value)
        {
            Write((byte)(value ? 1 : 0));
        }

        public void Write(char value)
        {
            WriteLine(BitConverter.GetBytes(value));
        }

        public void Write(short value)
        {
            WriteLine(BitConverter.GetBytes(value));
        }

        public void Write(ushort value)
        {
            WriteLine(BitConverter.GetBytes(value));
        }

        public void Write(int value)
        {
            WriteLine(BitConverter.GetBytes(value));
        }

        public void Write(uint value)
        {
            WriteLine(BitConverter.GetBytes(value));
        }

        public void Write(long value)
        {
            WriteLine(BitConverter.GetBytes(value));
        }

        public void Write(ulong value)
        {
            WriteLine(BitConverter.GetBytes(value));
        }

        public void Write(float value)
        {
            WriteLine(BitConverter.GetBytes(value));
        }

        public void Write(double value)
        {
            WriteLine(BitConverter.GetBytes(value));
        }

        public void Write(string value, Encode encode = Encode.UTF8)
        {
            byte[] bytes;

            switch (encode)
            {                
                case Encode.ASCII:
                    bytes = Encoding.ASCII.GetBytes(value);
                    break;
                case Encode.UTF7:
                    bytes = Encoding.UTF7.GetBytes(value);
                    break;
                case Encode.UTF8:
                    bytes = Encoding.UTF8.GetBytes(value);
                    break;
                case Encode.UTF32:
                    bytes = Encoding.UTF32.GetBytes(value);
                    break;
                case Encode.UNICODE:
                    bytes = Encoding.Unicode.GetBytes(value);
                    break;
                default:
                    bytes = new byte[0];
                    break;
            }

            Write(bytes);
        }

        public void Write(byte[] values)
        {
            if (values == null || values.Length <= 0) return;

            Write((int) values.Length);
            WriteLine(values);
        }

        private void WriteLine(byte[] values)
        {
            if (values == null || values.Length <= 0) return;

            Array.Copy(values, 0, m_segement.Array, m_segement.GetRelativePosition(m_position), values.Length);
            m_position += values.Length;
        }

        #endregion
    }
}
