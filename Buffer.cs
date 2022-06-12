using System.Runtime.InteropServices;

namespace Bolt
{
    public abstract class Buffer
    {
        public const int MaxLength = 1200;

        [StructLayout(LayoutKind.Explicit)]
        internal struct UIntFloat
        {
            [FieldOffset(0)]
            public float floatValue;

            [FieldOffset(0)]
            public uint intValue;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct ULongDouble
        {
            [FieldOffset(0)]
            public double doubleValue;

            [FieldOffset(0)]
            public ulong longValue;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct ULongLongDecimal
        {
            [FieldOffset(0)]
            public ulong longValue1;

            [FieldOffset(8)]
            public ulong longValue2;

            [FieldOffset(0)]
            public decimal decimalValue;
        }

        protected int m_position;
        protected Segment m_segement;

        public int Current => m_position;
        public int Length => m_segement.Count;

        internal byte this[int index]
        {
            get => m_segement[index];
            set => m_segement[index] = value;
        }

        internal Buffer() { }

        public void Reset()
        {
            m_position = 0;
        }

        public abstract byte[] ToArray();
        public abstract Segment ToSegment();
    }
}
