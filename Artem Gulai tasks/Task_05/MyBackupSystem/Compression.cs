using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_05.MyBackupSystem
{
    /// <summary>
    /// Class for (de)compression string
    /// </summary>
    static class Compression
    {
        /// <summary>
        /// Compress string and convert to array of bytes
        /// </summary>
        /// <param name="strToCompress"></param>
        /// <returns></returns>
        public static byte[] CompressString(string strToCompress)
        {
            byte[] bytesToCompress = Encoding.Unicode.GetBytes(strToCompress);
            using (MemoryStream stream = new MemoryStream())
            {
                using (GZipStream compress = new GZipStream(stream,CompressionLevel.Optimal))
                {
                    compress.Write(bytesToCompress,0,bytesToCompress.Length);
                }
                return stream.ToArray();
            }
        }

        /// <summary>
        /// Decompress array of bytes and convert to string
        /// </summary>
        /// <param name="bytesToDecompress"></param>
        /// <returns></returns>
        public static string DecompressBytes(byte[] bytesToDecompress)
        {
            using (MemoryStream inputStream = new MemoryStream(bytesToDecompress))
            {
                using (GZipStream decompress = new GZipStream(inputStream,CompressionMode.Decompress))
                {
                    inputStream.Position = 0;
                    List<byte> decompressedBytes = new List<byte>(bytesToDecompress.Length);
                    int a;
                    while ((a = decompress.ReadByte()) != -1)
                        decompressedBytes.Add((byte)a);

                    return Encoding.Unicode.GetString(decompressedBytes.ToArray());
                }
            }
        }
    }
}
