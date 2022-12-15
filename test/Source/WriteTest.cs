using Xunit;
using ByteBolt;

namespace ByteBoltTest;

public class WriteTest
{
    byte[] bytes_ = new byte[] { 1, 2, 3 };

    [Fact]
    public void Write()
    {
        var w = new Writer();
        AddValueInWriter(ref w);
    }

    [Fact]
    public void Read()
    {
        var w = new Writer();
        AddValueInWriter(ref w);
        var r = new Reader(ref w);

        // 1. byte
        byte _byte = r.Read();
        Assert.Equal(255, _byte);        

        // 2. bool
        bool _bool = r.ReadBool();
        Assert.True(_bool);

        // 3. short
        short _short = r.ReadShort();
        Assert.Equal(short.MinValue, _short);

        // 4. ushort
        ushort _ushort = r.ReadUShort();
        Assert.Equal(ushort.MaxValue, _ushort);

        // 5. long
        long _long = r.ReadLong();
        Assert.Equal(long.MinValue, _long);

        // 6. ulong
        ulong _ulong = r.ReadULong();
        Assert.Equal(ulong.MaxValue, _ulong);

        // 7. float
        float _float = r.ReadFloat();
        Assert.Equal(float.MinValue, _float);

        // 8. double
        double _double = r.ReadDouble();
        Assert.Equal(double.MinValue, _double);

        // 9. int
        int _int = r.ReadInt();
        Assert.Equal(bytes_.Length, _int);

        // 10. byte[]
        byte[] _bytes = r.Read(_int);
        Assert.Equal(bytes_, _bytes);

        // 11. string 
        string _string = r.ReadString();
        Assert.Equal("EXAMPLE", _string);
    }

    private void AddValueInWriter(ref Writer w)
    {
        // 1. byte
        w.Write((byte) 255);       

        // 2. bool
        w.Write((bool) true);

        // 3. short
        w.Write((short) short.MinValue);

        // 4. ushort
        w.Write((ushort) ushort.MaxValue);

        // 5. long
        w.Write((long) long.MinValue);

        // 6. ulong
        w.Write((ulong) ulong.MaxValue);

        // 7. float
        w.Write((float) float.MinValue);

        // 8. double
        w.Write((double) double.MinValue);

         // 9. int
        w.Write((int) bytes_.Length);

        // 10. byte[]
        w.Write((byte[]) bytes_);

        // 11. string 
        w.Write((string) "EXAMPLE");
    }
}