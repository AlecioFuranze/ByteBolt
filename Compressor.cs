using System;
using System.Collections.Generic;

namespace Bolt
{
    public static class Compressor
    {
        // scale a float within min/max range to an ushort between min/max range
        // note: can also use this for byte range from byte.MinValue to byte.MaxValue
        public static ushort ScaleFloatToUShort(float value, float minValue, float maxValue, ushort minTarget, ushort maxTarget)
        {
            // note: C# ushort - ushort => int, hence so many casts
            // max ushort - min ushort only fits into something bigger
            int targetRange = maxTarget - minTarget;
            float valueRange = maxValue - minValue;
            float valueRelative = value - minValue;
            return (ushort)(minTarget + (ushort)(valueRelative / valueRange * targetRange));
        }

        // scale an ushort within min/max range to a float between min/max range
        // note: can also use this for byte range from byte.MinValue to byte.MaxValue
        public static float ScaleUShortToFloat(ushort value, ushort minValue, ushort maxValue, float minTarget, float maxTarget)
        {
            // note: C# ushort - ushort => int, hence so many casts
            float targetRange = maxTarget - minTarget;
            ushort valueRange = (ushort)(maxValue - minValue);
            ushort valueRelative = (ushort)(value - minValue);
            return minTarget + (valueRelative / (float)valueRange * targetRange);
        }
    }
}
