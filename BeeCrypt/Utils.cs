using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeCrypt
{
    public static class FileEncryptor
    {
        public static string Encrypt(this FileInfo file, string password)
        {
            using (StreamReader reader = new StreamReader(file.FullName))
            {
                string @string = reader.ReadToEnd();
                @string = @string.Encode(password);
                reader.Close();
                return @string;
            }
        }
        public static string Decrypt(this FileInfo file, string password)
        {
            using (StreamReader reader = new StreamReader(file.FullName))
            {
                string @string = reader.ReadToEnd();
                @string = @string.Decode(password);
                reader.Close();
                return @string;
            }
        }
    }

    public static class StringEncryptor
    {
        /// <summary>
        /// Кодирует строку с помощью <see cref="ComplexBeeEncryption"/>, 
        /// создаваемого по паролю
        /// </summary>
        /// <param name="string"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Encode(this string @string, string password)
        {
            ComplexBeeEncryption encryption = CreateBeeEncryptor(password);
            try
            {
                return encryption.Encrypt(@string);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Пароль не пароль");
            }
        }

        /// <summary>
        /// Декодирует строку с помощью <see cref="ComplexBeeEncryption"/>, 
        /// создаваемого по паролю
        /// </summary>
        /// <param name="string"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Decode(this string @string, string password)
        {
            ComplexBeeEncryption encryption = CreateBeeEncryptor(password);
            try
            {
                return encryption.Decrypt(@string);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Пароль не пароль");
            }
        }

        private static ComplexBeeEncryption CreateBeeEncryptor(string password)
        {
            int passHash = password.GetHashCode();
            password = passHash.ToString();
            if (password.Length < 5)
                throw new ArgumentException("Пароль недостаточно пароль");
            else if (password.Length > 35)
                throw new ArgumentException("Пароль слишком пароль");

            // Создаём интервалы
            // Первая цифра хэша — количество интервалов
            List<int> intervals = new List<int>();
            for (int i = password[0] == '-' ? 2 : 1; i < password.Length; i += 2)
            {
                string buf = "" + password[i - 1] + password[i];
                intervals.Add(int.Parse(buf));
            }

            //int iCount = (password[0] % 10) + 5;
            //List<int> intervals = new List<int>();
            //for (int i = 1; i < password.Length; i++)
            //{
            //    string buf1 = "";
            //    for (int j = 0; j < (password.Length - 1) / iCount; j++)
            //        buf1 += password[i++];
            //    intervals.Add(int.Parse(buf1));
            //}

            // Создаём порядок символов в таблице
            // Добавляем символы из хэша по порядку, затем — оставшиеся цифры
            List<int> values = new List<int>(), order = new List<int>();
            for (int i = 0; i < 10; i++) values.Add(i);
            for (int i = 0; i < password.Length; i++)
            {
                int cur = 0;
                if (password[i] != '-')
                {
                    cur = int.Parse(Convert.ToString(password[i]));
                }
                if (values.Contains(cur))
                {
                    order.Add(cur);
                    values.Remove(cur);
                }
            }
            if (values.Count > 0)
                foreach (int item in values)
                    order.Add(item);

            // Создаём алфавит из хэш-суммы хэша
            string newHash = password.GetHashCode().ToString();
            while (newHash.Length <= 16) newHash += newHash[0] is '-' ?
                    newHash.Substring(1) : newHash;
            int length = (newHash.Length / 4) - 1;
            bool cut = length > 4;
            int start = newHash[0] is '-' ? 1 : 0;
            char symbol1 = (char)int.Parse(!cut ? newHash.Substring(start, length) :
                newHash.Substring(start, length).Substring(0, 4));
            char symbol2 = (char)int.Parse(!cut ? newHash.Substring(1 * length, length) :
                newHash.Substring(1 * length, length).Substring(0, 4));
            char symbol3 = (char)int.Parse(!cut ? newHash.Substring(2 * length, length) :
                newHash.Substring(2 * length, length).Substring(0, 4));
            char symbol4 = (char)int.Parse(!cut ? newHash.Substring(3 * length, length) :
                newHash.Substring(3 * length, length).Substring(0, 4));
            char[] alphabet = { symbol1, symbol2, symbol3, symbol4 };
            for (int i = 0; i < alphabet.Length; i++)
                for (int j = 0; j < alphabet.Length; j++)
                    if (alphabet[i] == alphabet[j] && i != j)
                        alphabet[j] = (char)(alphabet[j] + 10);

            return new ComplexBeeEncryption(intervals.ToArray(), alphabet, order.ToArray());
        }
    }
}
