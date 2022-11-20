using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NoexesCore
{
    public static class DecodeUtil
    {
        public static byte[] StringToByteArray(string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }


        public static T ConverBytesToStructure<T>(byte[] bytesBuffer)
        {
            //var typeSize = Marshal.SizeOf(typeof(T));
            if (bytesBuffer.Length != Marshal.SizeOf(typeof(T)))
            {
                throw new ArgumentException("length not match");
            }

            IntPtr bufferHandler = Marshal.AllocHGlobal(bytesBuffer.Length);
            Marshal.Copy(bytesBuffer, 0, bufferHandler, bytesBuffer.Length);
            T structObject = (T)Marshal.PtrToStructure(bufferHandler, typeof(T));
            Marshal.FreeHGlobal(bufferHandler);

            return structObject;
        }
    }
}
