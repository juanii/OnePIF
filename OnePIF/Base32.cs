using System;
using System.Collections.Generic;
using System.Text;

namespace OnePIF
{
    // https://stackoverflow.com/questions/641361/base32-decoding/42231034#42231034
    public class Base32
    {
        private static readonly string BASE32_ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
        private static readonly char BASE32_PADDING = '=';

        private static int guardedIndexOf(string alphabet, char character)
        {
            int charIndex = BASE32_ALPHABET.IndexOf(character);

            if (charIndex == -1)
                throw new Exception(string.Format("Invalid character in Base32 string: {0}", character));

            return charIndex;
        }

        public static long EncodedSize(int byteCount)
        {
            return (byteCount * 8 + 4) / 5;
        }

        public static string Encode(byte[] bytes)
        {
            StringBuilder output = new StringBuilder();

            for (int bitIndex = 0; bitIndex < bytes.Length * 8; bitIndex += 5)
            {
                int dualbyte = bytes[bitIndex / 8] << 8;

                if (bitIndex / 8 + 1 < bytes.Length)
                    dualbyte |= bytes[bitIndex / 8 + 1];

                dualbyte = 0x1f & (dualbyte >> (16 - bitIndex % 8 - 5));

                output.Append(BASE32_ALPHABET[dualbyte]);
            }

            return output.ToString();
        }

        public static int DecodedSize(int stringLength)
        {
            return (stringLength * 5) & ~0x7;
        }

        public static byte[] Decode(string base32)
        {
            List<byte> output = new List<byte>();
            char[] bytes = base32.ToUpper().TrimEnd(BASE32_PADDING).ToCharArray();

            for (int bitIndex = 0; bitIndex < DecodedSize(base32.Length); bitIndex += 8)
            {
                int dualbyte = guardedIndexOf(BASE32_ALPHABET, bytes[bitIndex / 5]) << 10;

                if (bitIndex / 5 + 1 < bytes.Length)
                    dualbyte |= guardedIndexOf(BASE32_ALPHABET, bytes[bitIndex / 5 + 1]) << 5;

                if (bitIndex / 5 + 2 < bytes.Length)
                    dualbyte |= guardedIndexOf(BASE32_ALPHABET, bytes[bitIndex / 5 + 2]);

                dualbyte = 0xff & (dualbyte >> (15 - bitIndex % 5 - 8));

                output.Add((byte)dualbyte);
            }

            return output.ToArray();
        }
    }
}