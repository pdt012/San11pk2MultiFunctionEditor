namespace kmfe.utils.bytesConverter
{
    public static class BytesConverter
    {
        public static void FromBytes(byte[] buffer, int startIndex, out int target)
        {
            target = BitConverter.ToInt32(buffer, startIndex);
        }
        public static void FromBytes(byte[] buffer, int startIndex, out uint target)
        {
            target = BitConverter.ToUInt32(buffer, startIndex);
        }
        public static void FromBytes(byte[] buffer, int startIndex, out short target)
        {
            target = BitConverter.ToInt16(buffer, startIndex);
        }
        public static void FromBytes(byte[] buffer, int startIndex, out ushort target)
        {
            target = BitConverter.ToUInt16(buffer, startIndex);
        }
        public static void FromBytes(byte[] buffer, int startIndex, out bool target)
        {
            target = BitConverter.ToBoolean(buffer, startIndex);
        }
        public static void FromBytes(byte[] buffer, int startIndex, out sbyte target)
        {
            target = (sbyte)buffer[startIndex];
        }
        public static void FromBytes(byte[] buffer, int startIndex, out byte target)
        {
            target = buffer[startIndex];
        }
        public static void FromBytes(byte[] buffer, int startIndex, sbyte[] byteArray)
        {
            Array.Copy(buffer, startIndex, byteArray, 0, byteArray.Length);
        }
        public static void FromBytes(byte[] buffer, int startIndex, byte[] byteArray)
        {
            Array.Copy(buffer, startIndex, byteArray, 0, byteArray.Length);
        }
        public static void FromBytes(byte[] buffer, int startIndex, IBytesConvertable target)
        {
            byte[] bufferForTarget = buffer[startIndex..(startIndex + target.Size)];
            target.FromBytes(bufferForTarget);
        }

        public static void ToBytes(byte[] buffer, int startIndex, int value)
        {
            BitConverter.GetBytes(value).CopyTo(buffer, startIndex);
        }
        public static void ToBytes(byte[] buffer, int startIndex, uint value)
        {
            BitConverter.GetBytes(value).CopyTo(buffer, startIndex);
        }
        public static void ToBytes(byte[] buffer, int startIndex, short value)
        {
            BitConverter.GetBytes(value).CopyTo(buffer, startIndex);
        }
        public static void ToBytes(byte[] buffer, int startIndex, ushort value)
        {
            BitConverter.GetBytes(value).CopyTo(buffer, startIndex);
        }
        public static void ToBytes(byte[] buffer, int startIndex, bool value)
        {
            BitConverter.GetBytes(value).CopyTo(buffer, startIndex);
        }
        public static void ToBytes(byte[] buffer, int startIndex, sbyte value)
        {
            buffer[startIndex] = (byte)value;
        }
        public static void ToBytes(byte[] buffer, int startIndex, byte value)
        {
            buffer[startIndex] = value;
        }
        public static void ToBytes(byte[] buffer, int startIndex, sbyte[] byteArray)
        {
            Array.Copy(byteArray, 0, buffer, startIndex, byteArray.Length);
        }
        public static void ToBytes(byte[] buffer, int startIndex, byte[] byteArray)
        {
            Array.Copy(byteArray, 0, buffer, startIndex, byteArray.Length);
        }
        public static void ToBytes(byte[] buffer, int startIndex, IBytesConvertable value)
        {
            byte[] bufferForValue = new byte[value.Size];
            value.ToBytes(ref bufferForValue);
            ToBytes(buffer, startIndex, bufferForValue);
        }
    }

    public interface IBytesConvertable
    {
        int Size { get; }
        void FromBytes(byte[] array);
        void ToBytes(ref byte[] array);
    }
}
