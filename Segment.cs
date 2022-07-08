using System;

namespace Bolt
{
    // delimits a part of a byte array that already exists in memory
    //          ArraySegment isn't implemented in all .Net libraries
    public readonly struct Segment
    {
        public Segment(byte[] array)
        {
            if (array == null)
                throw new ArgumentNullException("Array is null");

            Array = array;
            Offset = 0;
            Count = array.Length;
        }

        public Segment(Segment other)
        {
            Array = other.Array;
            Offset = other.Offset;
            Count = other.Count;
        }

        public Segment(byte[] array, int offset, int count)
        {
            if (array.Length - 1 < offset)
                throw new ArgumentOutOfRangeException($"Offset ({offset}) is out of range; Array Length: {array.Length}");
            else if (count > array.Length)
                throw new ArgumentOutOfRangeException($"Count ({count}) Greater Than Array Length ({array.Length})");

            Array = array;
            Offset = offset;
            Count = count;
        }

        public byte this[int index] 
        { 
            get => Array[GetRelativePosition(index)];
            set => Array[GetRelativePosition(index)] = value;
        }

        public int Offset { get; }
        public byte[] Array { get; }
        public int Count { get; }

        public static readonly Segment Empty = new Segment(new byte[0]);

        public int GetRelativePosition(int index)
        {
            int position = Offset + index;
            /*if (position < Offset)
                throw new IndexOutOfRangeException($"Relative Index ({position}) Less Than Segement Offset ({Offset})");
            else if (position > Count)
                throw new IndexOutOfRangeException($"Relative Index ({position}) Greater Than Segement Count ({Count})");
            else*/
                return position;
        }

        public void CopyTo(Segment destination) => CopyTo(destination, destination.Offset);
        public void CopyTo(Segment destination, int destinationIndex) => CopyTo(destination, destinationIndex, Count);
        public void CopyTo(Segment destination, int destinationIndex, int count) => CopyTo(destination.Array, destination.GetRelativePosition(destinationIndex), count);

        public void CopyTo(byte[] destination) => CopyTo(destination, 0);
        public void CopyTo(byte[] destination, int destinationIndex) => CopyTo(destination, destinationIndex, Count);
        public void CopyTo(byte[] destination, int destinationIndex, int count) => System.Array.Copy(Array, Offset, destination, destinationIndex, count);

        public Segment Slice(int index)
        {
            index = GetRelativePosition(index);
            return new Segment(Array, index, Count - index);
        }

        public Segment Slice(int index, int count)
        {
            index = GetRelativePosition(index);
            return new Segment(Array, index, count);
        }

        public byte[] ToArray()
        {
            byte[] array = new byte[Count];
            CopyTo(array);
            return array;
        }

        public Segment Clone()
        {
            return new Segment(this);
        }

        public static implicit operator Segment(byte[] array)
        {
            return new Segment(array);
        }
    }
}
