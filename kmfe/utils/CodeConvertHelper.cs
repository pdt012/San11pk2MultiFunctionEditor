using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace kmfe.utils
{
    public static class CodeConvertHelper
    {
        static readonly Dictionary<ushort, char?> pk2uniMap = new();
        static readonly Dictionary<char, ushort> uni2pkMap = new();

        /// <summary>
        /// 码表初始化
        /// </summary>
        /// <param name="configPath"></param>
        public static void Init(string configPath)
        {
            XmlDocument doc = new();
            doc.Load(configPath);
            XmlElement? root = doc.DocumentElement;
            XmlNodeList? scNodeList = root?.SelectNodes("ch");
            if (scNodeList is null)
                return;
            foreach (XmlNode scNode in scNodeList)
            {
                string? k = scNode.Attributes?["key"]?.Value;
                string v = scNode.Attributes?["value"]?.Value ?? "";
                if (k is null)
                    continue;
                ushort jisCode = Convert.ToUInt16(k, 16);
                if (v.Length > 0)
                {
                    pk2uniMap[jisCode] = v[0];
                    uni2pkMap[v[0]] = jisCode;
                }
                else
                {
                    pk2uniMap[jisCode] = null;  // null代表是空字符
                }
            }
        }

        /// <summary>
        /// pk字符串转码unicode字符串
        /// </summary>
        /// <param name="pkBytes">字节数组</param>
        /// <returns>字符串</returns>
        public static string Pk2Str(byte[] pkBytes)
        {
            string result = "";
            int i = 0;
            while (i < pkBytes.Length)
            {
                byte b = pkBytes[i];
                if (b == 0)
                    break;
                if (b < 0x80)
                {
                    result += (char)b;
                }
                else
                {
                    i++;
                    if (i >= pkBytes.Length)  // 意外结尾
                        result += "?";
                    else
                    {
                        byte b_right = pkBytes[i];
                        ushort jisCode = (ushort)((b << 8) | b_right);
                        char? c = pk2uniMap.GetValueOrDefault(jisCode, '?');
                        if (c != null)
                            result += c;
                    }
                }
                i++;
            }
            return result;
        }

        /// <summary>
        /// unicode字符串转码pk字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>转码结果</returns>
        public static byte[] Str2Pk(string str)
        {
            List<byte> result = new();
            foreach (char c in str)
            {
                if (char.IsAscii(c))
                {
                    result.Add((byte)c);
                }
                else
                {
                    if (uni2pkMap.ContainsKey(c))
                    {
                        ushort jisCode = uni2pkMap[c];
                        result.Add((byte)((jisCode >> 8) & 0xff));
                        result.Add((byte)(jisCode & 0xff));
                    }
                    else
                    {
                        result.Add((byte)'?');
                    }
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// unicode字符串转码pk字符串，且考虑缓冲区长度
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="buffer">缓冲字节数组</param>
        public static void Str2Pk(string str, byte[] buffer)
        {
            byte[] result = Str2Pk(str);
            result.CopyTo(buffer, 0);
            if (result.Length < buffer.Length)
                buffer[result.Length] = 0;
            else
                buffer[^1] = 0;
        }
    }
}
