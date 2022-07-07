using System;

namespace Bolt
{
    public static class Extension
    {
        public static class Generic<T>
        {
            public delegate void Writing(ref Writer writer, T value);
            public delegate T Reading(ref Reader reader);

            internal static Reading Read;
            internal static Writing Write;

            public static void SetRead(Reading reading) => Read = reading;
            public static void SetWrite(Writing writing) => Write = writing;

            static Generic()
            {
                // reading
                Generic<byte>.SetRead((ref Reader reader) =>
                {
                    return reader.Read();
                });
                Generic<bool>.SetRead((ref Reader reader) =>
                {
                    return reader.ReadBool();
                });
                Generic<char>.SetRead((ref Reader reader) =>
                {
                    return reader.ReadChar();
                });
                Generic<short>.SetRead((ref Reader reader) =>
                {
                    return reader.ReadShort();
                });
                Generic<ushort>.SetRead((ref Reader reader) =>
                {
                    return reader.ReadUShort();
                });
                Generic<int>.SetRead((ref Reader reader) =>
                {
                    return reader.ReadInt();
                });
                Generic<uint>.SetRead((ref Reader reader) =>
                {
                    return reader.ReadUInt();
                });
                Generic<long>.SetRead((ref Reader reader) =>
                {
                    return reader.ReadLong();
                });
                Generic<ulong>.SetRead((ref Reader reader) =>
                {
                    return reader.ReadULong();
                });
                Generic<float>.SetRead((ref Reader reader) =>
                {
                    return reader.ReadFloat();
                });
                Generic<double>.SetRead((ref Reader reader) =>
                {
                    return reader.ReadDouble();
                });
                Generic<string>.SetRead((ref Reader reader) =>
                {
                    return reader.ReadString();
                });


                // writing
                Generic<byte>.SetWrite((ref Writer writer, byte value) =>
                {
                    writer.Write(value);
                });
                Generic<bool>.SetWrite((ref Writer writer, bool value) =>
                {
                    writer.Write(value);
                });
                Generic<char>.SetWrite((ref Writer writer, char value) =>
                {
                    writer.Write(value);
                });
                Generic<short>.SetWrite((ref Writer writer, short value) =>
                {
                    writer.Write(value);
                });
                Generic<ushort>.SetWrite((ref Writer writer, ushort value) =>
                {
                    writer.Write(value);
                });
                Generic<int>.SetWrite((ref Writer writer, int value) =>
                {
                    writer.Write(value);
                });
                Generic<uint>.SetWrite((ref Writer writer, uint value) =>
                {
                    writer.Write(value);
                });
                Generic<long>.SetWrite((ref Writer writer, long value) =>
                {
                    writer.Write(value);
                });
                Generic<ulong>.SetWrite((ref Writer writer, ulong value) =>
                {
                    writer.Write(value);
                });
                Generic<float>.SetWrite((ref Writer writer, float value) =>
                {
                    writer.Write(value);
                });
                Generic<double>.SetWrite((ref Writer writer, double value) =>
                {
                    writer.Write(value);
                });
                Generic<string>.SetWrite((ref Writer writer, string value) =>
                {
                    writer.Write(value);
                });
            }
        }

        public static void Write<T>(this Writer writer, T value)
        {
            Generic<T>.Writing writing = Generic<T>.Write;
            if (writing == null)
            {
                throw new InvalidOperationException($"No writer found for {typeof(T)}; define a custom writer.");
            }
            else
            {
                writing(ref writer, value);
            }
        }

        public static T Read<T>(this Reader reader)
        {
            Generic<T>.Reading reading = Generic<T>.Read;
            if (reading == null)
            {
                throw new InvalidOperationException($"No reader found for {typeof(T)}; define a custom reader");
            }
            return reading(ref reader);
        }
    }
}