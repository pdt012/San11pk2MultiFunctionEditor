namespace kmfe.utils.bytesConverter
{
    public class StreamConverter
    {
        readonly byte[] buffer;
        int index;

        public int Index { get { return index; } }

        public StreamConverter(byte[] buffer)
        {
            this.buffer = buffer;
            this.index = 0;
        }

        public void Seek(int offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    index = offset;
                    break;
                case SeekOrigin.Current:
                    index += offset;
                    break;
                case SeekOrigin.End:
                    index += buffer.Length + offset;
                    break;
            }
        }

        public void Read(out int target)
        {
            BytesConverter.FromBytes(buffer, index, out target);
            index += sizeof(int);
        }
        public void Read(out uint target)
        {
            BytesConverter.FromBytes(buffer, index, out target);
            index += sizeof(uint);
        }
        public void Read(out short target)
        {
            BytesConverter.FromBytes(buffer, index, out target);
            index += sizeof(short);
        }
        public void Read(out ushort target)
        {
            BytesConverter.FromBytes(buffer, index, out target);
            index += sizeof(ushort);
        }
        public void Read(out bool target)
        {
            BytesConverter.FromBytes(buffer, index, out target);
            index += sizeof(bool);
        }
        public void Read(out sbyte target)
        {
            BytesConverter.FromBytes(buffer, index, out target);
            index += sizeof(sbyte);
        }
        public void Read(out byte target)
        {
            BytesConverter.FromBytes(buffer, index, out target);
            index += sizeof(byte);
        }
        public void Read(sbyte[] byteArray)
        {
            BytesConverter.FromBytes(buffer, index, byteArray);
            index += byteArray.Length;
        }
        public void Read(byte[] byteArray)
        {
            BytesConverter.FromBytes(buffer, index, byteArray);
            index += byteArray.Length;
        }
        public void Read(IBytesConvertable target)
        {
            BytesConverter.FromBytes(buffer, index, target);
            index += target.Size;
        }
        public void Read(IBytesConvertable[] array)
        {
            foreach (IBytesConvertable item in array)
            {
                Read(item);
            }
        }

        public void Write(int value)
        {
            BytesConverter.ToBytes(buffer, index, value);
            index += sizeof(int);
        }
        public void Write(uint value)
        {
            BytesConverter.ToBytes(buffer, index, value);
            index += sizeof(uint);
        }
        public void Write(short value)
        {
            BytesConverter.ToBytes(buffer, index, value);
            index += sizeof(short);
        }
        public void Write(ushort value)
        {
            BytesConverter.ToBytes(buffer, index, value);
            index += sizeof(ushort);
        }
        public void Write(bool value)
        {
            BytesConverter.ToBytes(buffer, index, value);
            index += sizeof(bool);
        }
        public void Write(sbyte value)
        {
            BytesConverter.ToBytes(buffer, index, value);
            index += sizeof(sbyte);
        }
        public void Write(byte value)
        {
            BytesConverter.ToBytes(buffer, index, value);
            index += sizeof(byte);
        }
        public void Write(sbyte[] byteArray)
        {
            BytesConverter.ToBytes(buffer, index, byteArray);
            index += byteArray.Length;
        }
        public void Write(byte[] byteArray)
        {
            BytesConverter.ToBytes(buffer, index, byteArray);
            index += byteArray.Length;
        }
        public void Write(IBytesConvertable value)
        {
            BytesConverter.ToBytes(buffer, index, value);
            index += value.Size;
        }
        public void Write(IBytesConvertable[] array)
        {
            foreach (IBytesConvertable item in array)
            {
                Write(item);
            }
        }
    }
}
