using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeCrypt
{
    public class BeeEncryptor
    {
        #region Поля и свойства
        public List<char> symbols, symbols2;
        public int?[,] Table;
        public int EndOfWordSymbolIndex;
        public char EndOfWordSymbol
        {
            get => symbols[EndOfWordSymbolIndex];
            set => EndOfWordSymbolIndex = symbols.ToList().IndexOf(value);
        }
        public string EOW => "" + EndOfWordSymbol + EndOfWordSymbol;

        private Dictionary<string, int> KeyValuesDecrypt
        {
            get
            {
                Dictionary<string, int> res = new Dictionary<string, int>();
                for (int i = 0; i < Table.GetLength(0); i++)
                {
                    for (int j = 0; j < Table.GetLength(1); j++)
                    {
                        if (!(Table[i, j] is null))
                        {
                            res.Add("" + symbols[i] + symbols2[j], Table[i, j].Value);
                        }
                    }
                }
                return res;
            }
        }

        private Dictionary<int, string> KeyValuesEncrypt
        {
            get
            {
                Dictionary<int, string> res = new Dictionary<int, string>();
                for (int i = 0; i < Table.GetLength(0); i++)
                {
                    for (int j = 0; j < Table.GetLength(1); j++)
                    {
                        if (!(Table[i, j] is null))
                        {
                            res.Add(Table[i, j].Value, "" + symbols[i] + symbols2[j]);
                        }
                    }
                }
                return res;
            }
        }
        #endregion Поля и свойства

        #region Конструкторы
        public BeeEncryptor(char symbol1, char symbol2, char symbol3, char symbol4, char? end = null)
            : this(new char[] { symbol1, symbol2, symbol3, symbol4 },
                  end is null ? symbol4 : end.Value) { }

        public BeeEncryptor(char symbol1, char symbol2, char symbol3, char symbol4, int[] order,
            char? end = null) : this(new char[] { symbol1, symbol2, symbol3, symbol4 },
                  end is null ? symbol4 : end.Value, order)
        { }

        private BeeEncryptor(IEnumerable<char> _symbols, char endOfWordSymbol, int[] order)
        {
            symbols = _symbols.ToList() ?? throw new ArgumentNullException(nameof(_symbols));
            symbols2 = (new char[] { symbols[0], symbols[1], symbols[3], symbols[2] }).ToList();
            EndOfWordSymbol = endOfWordSymbol;

            Table = new int?[symbols.Count, symbols.Count];
            int cur = 0;
            for (int i = 0; i < symbols.Count; i++)
            {
                for (int j = 0; j < symbols.Count; j++)
                {
                    if ((i == EndOfWordSymbolIndex || j == EndOfWordSymbolIndex - 1)
                        && j < EndOfWordSymbolIndex)
                    {
                        if (i == EndOfWordSymbolIndex && j == EndOfWordSymbolIndex - 1)
                            Table[i, j] = '\n';
                        else Table[i, j] = null;
                    }
                    else
                    {
                        Table[i, j] = order[cur++];
                    }
                }
            }
        }

        private BeeEncryptor(IEnumerable<char> _symbols, char endOfWordSymbol)
        {
            symbols = _symbols.ToList() ?? throw new ArgumentNullException(nameof(_symbols));
            symbols2 = (new char[] { symbols[0], symbols[1], symbols[3], symbols[2] }).ToList();
            EndOfWordSymbol = endOfWordSymbol;

            Table = new int?[symbols.Count, symbols.Count];
            Random random = new Random(DateTime.Now.Millisecond);
            List<int> vs = new List<int>();
            for (int i = 0; i < 10; i++) vs.Add(i);
            for (int i = 0; i < symbols.Count; i++)
            {
                for (int j = 0; j < symbols.Count; j++)
                {
                    if ((i == EndOfWordSymbolIndex || j == EndOfWordSymbolIndex - 1)
                        && j < EndOfWordSymbolIndex)
                    {
                        if (i == EndOfWordSymbolIndex && j == EndOfWordSymbolIndex - 1)
                            Table[i, j] = '\n';
                        else Table[i, j] = null;
                    }
                    else
                    {
                        int cur = random.Next(0, vs.Count);
                        Table[i, j] = vs[cur];
                        vs.RemoveAt(cur);
                    }
                }
            }
        }
        #endregion Конструкторы

        public string Encrypt(string String0)
        {
            char[] str = String0.ToCharArray();
            string elem, Output = "";
            char[] str2;
            int num;
            for (int i = 0; i < str.Length; i++)
            {
                num = Convert.ToInt32(str[i]);
                elem = num.ToString();
                str2 = elem.ToCharArray();
                for (int j = 0; j < str2.Length; j++)
                {
                    int elem2 = str2[j] - '0';
                    Output += KeyValuesEncrypt[elem2];
                }
                Output += EOW;
            }
            return Output;
        }

        public string Decrypt(string instr)
        {
            char[] instring = instr.ToCharArray();
            char finalScore;
            string helper = null, wordout = "", lit;
            int fin, Cnt = 0;
            int[] litr = new int[instr.Length / 2];
            for (int i = 0; i < instr.Length; i += 2)
            {
                lit = instring[i].ToString();
                lit += instring[i + 1].ToString();
                litr[Cnt] = KeyValuesDecrypt[lit];
                if (lit == EOW)
                {
                    for (int ii = 0; ii < Cnt; ii++)
                    {
                        helper += litr[ii];
                    }
                    fin = Convert.ToInt32(helper);
                    finalScore = (char)fin;
                    wordout += finalScore;
                    helper = null;
                    Cnt = 0;
                    continue;
                }
                Cnt++;
            }
            return wordout;
        }
    }
}
