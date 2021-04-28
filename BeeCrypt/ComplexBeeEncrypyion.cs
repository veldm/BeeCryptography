using System;
using System.Collections.Generic;

namespace BeeCrypt
{
	public class ComplexBeeEncryption
	{
		private int[] Intervals;
		private char[] Alphabet;
		private int[] TableOrder;
		private BeeCrypt.BeeEncryptor[] Encryptors = new BeeEncryptor[16];

        public ComplexBeeEncryption(int[] intervals, char[] alphabet, int[] tableOrder)
        {
            Intervals = intervals ?? throw new ArgumentNullException(nameof(intervals));
            Alphabet = alphabet ?? throw new ArgumentNullException(nameof(alphabet));
            TableOrder = tableOrder ?? throw new ArgumentNullException(nameof(tableOrder));

            List<BeeEncryptor> buf = new List<BeeEncryptor>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        for (int l = 0; l < 4; l++)
                        {
                            if (i != j && i != k && i != l &&
                                j != i && j != k && j != l &&
                                k != j && k != i && k != l &&
                                l != j && l != k && l != i)
                            {
                                buf.Add(new BeeEncryptor
                                    (Alphabet[i], Alphabet[j], Alphabet[k], Alphabet[l], TableOrder));
                            }
                        }
                    }
                }
            }
            Encryptors = buf.ToArray();
        }



        public string Encrypt(string input)
        {
            string result = "";
            int cur = 0, i = 0, index = 0;
            while (index < input.Length)
            {
                string buf = index + Intervals[i] <= input.Length ?
                    input.Substring(index, Intervals[i])
                    : input.Substring(index);
                index += Intervals[i++];
                result += Encryptors[cur++].Encrypt(buf);
                if (i == Intervals.Length) i = 0;
            }
            return result;
        }

        public string Decrypt(string input)
        {
            string result = "", buf = "";
            int length, cur = 0, count = 0, i = 0;
            for (int index = 0; index < input.Length;)
            {
                length = 1;
                string a;
                while ((a = "" + input[index + length - 1] + input[index + length]) !=
                    Encryptors[cur].EOW) length++;
                buf += input.Substring(index, length + 1);
                #if (DEBUG)
                string currentRemainder = input.Substring(index);
                #endif
                index += length + 1;
                count++;
                if (count == Intervals[i] || index == input.Length)
                {
                    result += Encryptors[cur].Decrypt(buf);
                    buf = "";
                    i++;
                    cur++;
                    count = 0;
                    if (cur == Encryptors.Length) cur = 0;
                    if (i == Intervals.Length) i = 0;
                }
            }
            return result;
        }
    }
}
