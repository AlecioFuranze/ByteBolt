using System;
using System.Text;

namespace ByteBolt
{
    public class Reader : Buffer
    {
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

        public Reader(Reader other)
        {
            this.m_segement = other.m_segement;
            this.m_position = other.m_position;
        }

        public Reader(ref Writer other)
        {
            this.m_segement = other.ToSegment();
            this.m_position = 0;
        }

        public byte Peek()
        {
            return m_segement[m_position];
        }

        public byte Read()
        {
            byte b = Peek();
            m_position++;
            return b;
        }

        public byte[] Read(int lenght)
        {
            byte[] bytes = new byte[lenght];
            Array.Copy(m_segement.Array, m_segement.GetRelativePosition(m_position), bytes, 0, lenght);
            m_position += lenght;
            return bytes;
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

        /*public sbyte ReadSByte()
        {
            return Convert.ToSByte(Read());
        }*/

        public bool ReadBool()
        {
            return Read() > 0;
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
            m_position += sizeof(char);
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

        /*public decimal ReadDecimal()
        {
            return;
        }*/
        
        public string ReadString()
        {
            int length = ReadUShort();
            return Encoding.UTF8.GetString(Read(length));
        }
    }
}
