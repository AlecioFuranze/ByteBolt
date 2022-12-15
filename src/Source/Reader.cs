using System;
using System.Text;
using ByteBolt.Core;
using Buffer = ByteBolt.Core.Buffer;

namespace ByteBolt
{
    public class Reader : Buffer
    {
        #region Bulder

        public Reader(byte[] bytes)
        {
            this.m_segement = new Segment(bytes);
            this.m_position = 0;
        }

        public Reader(Segment segment)
        {
            this.m_segement = segment;
            this.m_position = 0;
        }

        public Reader(ref Writer other)
        {
            this.m_segement = other.ToSegment();
            this.m_position = 0;
        }

        #endregion

        #region Info

        public byte Peek()
        {
            return m_segement[m_position];
        }

        public Segment Peek(int lenght)
        {
            int offset = m_segement.GetRelativePosition(m_position);
            return new Segment(m_segement.Array, offset, lenght);
        }

        public Segment ReadSegment(int lenght)
        {
            int offset = m_segement.GetRelativePosition(m_position);
            m_position += lenght;
            return new Segment(m_segement.Array, offset, lenght);
        }

        #endregion

        public byte ReadByte()
        {
            byte b = Peek();
            m_position++;
            return b;
        }

        public byte[] ReadBytes()
        {
            int lenght = ReadInt();
            byte[] bytes = new byte[lenght];
            Array.Copy(m_segement.Array, m_segement.GetRelativePosition(m_position), bytes, 0, lenght);
            m_position += lenght;
            return bytes;
        }        

        public bool ReadBool()
        {
            return ReadByte() > 0;
        }

        public char ReadChar()
        {
            int index = m_position;
            m_position += sizeof(char);
            return BitConverter.ToChar(m_segement.Array, m_segement.GetRelativePosition(index));
        }

        public short ReadShort()
        {
            int index = m_position;
            m_position += sizeof(short);
            return BitConverter.ToInt16(m_segement.Array, m_segement.GetRelativePosition(index));
        }

        public ushort ReadUShort()
        {
            int index = m_position;
            m_position += sizeof(ushort);
            return BitConverter.ToUInt16(m_segement.Array, m_segement.GetRelativePosition(index));
        }

        public int ReadInt()
        {
            int index = m_position;
            m_position += sizeof(int);
            return BitConverter.ToInt32(m_segement.Array, m_segement.GetRelativePosition(index));
        }
        public uint ReadUInt()
        {
            int index = m_position;
            m_position += sizeof(uint);
            return BitConverter.ToUInt32(m_segement.Array, m_segement.GetRelativePosition(index));
        }

        public long ReadLong()
        {
            int index = m_position;
            m_position += sizeof(long);
            return BitConverter.ToInt64(m_segement.Array, m_segement.GetRelativePosition(index));
        }

        public ulong ReadULong()
        {
            int index = m_position;
            m_position += sizeof(ulong);
            return BitConverter.ToUInt64(m_segement.Array, m_segement.GetRelativePosition(index));
        }

        public float ReadFloat()
        {
            int index = m_position;
            m_position += sizeof(float);
            return BitConverter.ToSingle(m_segement.Array, m_segement.GetRelativePosition(index));
        }

        public double ReadDouble()
        {
            int index = m_position;
            m_position += sizeof(double);
            return BitConverter.ToDouble(m_segement.Array, m_segement.GetRelativePosition(index));
        }
        
        public string ReadString(Encode encode = Encode.UTF8)
        {
            byte[] value = ReadBytes();
            
            switch (encode)
            {                
                case Encode.ASCII:
                    return Encoding.ASCII.GetString(value);
                case Encode.UTF7:
                    return Encoding.UTF7.GetString(value);
                case Encode.UTF8:
                    return Encoding.UTF8.GetString(value);
                case Encode.UTF32:
                    return Encoding.UTF32.GetString(value);
                case Encode.UNICODE:
                    return Encoding.Unicode.GetString(value);
                default:
                    return string.Empty;
            }
        }
    }
}
