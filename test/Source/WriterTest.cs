using Xunit;
using ByteBolt;

namespace ByteBoltTest;

public class WriterTest
{
    static byte[] BYTES = new byte[] { 1, 2, 3 };

    [Fact]
    public void Write()
    {
        var w = new Writer();
        AddValueInWriter(ref w);
    }

    [Fact]
    public void Write()
    {
        var w = new Writer();
        AddValueInWriter(ref w);
    }
    
    public static void AddValueInWriter(ref Writer w)
    {
        // 1. byte
        w.Write((byte) 255);       

        // 2. bool
        w.Write((bool) true);

        // 3. short
        w.Write((short) -111);

        // 4. ushort
        w.Write((ushort) 111);

        // 5. long
        w.Write((long) -222);

        // 6. ulong
        w.Write((ulong) 222);

        // 7. float
        w.Write((float) -333.333f);

        // 8. double
        w.Write((double) -444.444d);

        // 9. int
        w.Write((int) -555);

        // 10. uint
        w.Write((uint) 555);

        // 11. byte[]
        w.Write((byte[]) BYTES);

        // 12. string 
        w.Write((string) "EXAMPLE");
    }
}