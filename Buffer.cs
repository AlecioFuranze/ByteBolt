namespace Bolt
{
    public abstract class Buffer
    {
        public const int MaxLength = 1200;

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

        // use this only if you know what you're doing
        public void Seek(int position)
        {
            m_position = position;
        }
    }
}