using Xunit;
using ByteBolt;

namespace ByteBoltTest;

public class ReaderTest
{
    static byte[] BYTES = new byte[] { 1, 2, 3 };

    [Fact]
    public void Read()
    {
        var w = new Writer();
        WriterTest.AddValueInWriter(ref w);
        var r = new Reader(ref w);

        // 1. byte
        byte _byte = r.ReadByte();
        Assert.Equal(255, _byte);        

        // 2. bool
        bool _bool = r.ReadBool();
        Assert.True(_bool);

        // 3. short
        short _short = r.ReadShort();
        Assert.Equal((short)-111, _short);

        // 4. ushort
        ushort _ushort = r.ReadUShort();
        Assert.Equal((ushort)111, _ushort);

        // 5. long
        long _long = r.ReadLong();
        Assert.Equal((long)-222, _long);

        // 6. ulong
        ulong _ulong = r.ReadULong();
        Assert.Equal((ulong)222, _ulong);

        // 7. float
        float _float = r.ReadFloat();
        Assert.Equal((float)-333.333f, _float);

        // 8. double
        double _double = r.ReadDouble();
        Assert.Equal((double)-444.444d, _double);

        // 9. int
        int _int = r.ReadInt();
        Assert.Equal((int)-555, _int);

        // 10. uint
        uint _uint = r.ReadUInt();
        Assert.Equal((uint)555, _uint);

        // 11. byte[]
        byte[] _bytes = r.ReadBytes();
        Assert.Equal(BYTES, _bytes);

        // 12. string 
        string _string = r.ReadString();
        Assert.Equal("EXAMPLE", _string);
    }    
}