using System;
using System.Collections.Generic;

namespace BaseConverter {

    public static class BaseConverter {

        public static bool IsBinary(string s) {
            for (int i = 0; i < s.Length; i++) {
                if (s[i] != '1' && s[i] != '0') {
                    return false;
                }
            }

            if(s.Length > 64)
                return false;
            return true;
        }

        public static bool IsHex(string s) {
            for (int i = 0; i < s.Length; i++) {
                if((s[i] >= '0' && s[i] <= '9') || (s[i] >= 'a' && s[i] <= 'z') || (s[i] >= 'A' && s[i] <= 'Z'))
                    continue;
                else
                    return false;
            }
            return true;
        }

        public static string Dec2Bin(string s) {

            string result = "";
            ulong n = Convert.ToUInt64(s);
            List<String> remainders = new List<String>();
            ulong q = n%2, r;

            while (n >= 2) {
                q = n / 2;
                r = n % 2;
                remainders.Add(r.ToString());
                n = q;
            }
            result = q.ToString();

            remainders.Reverse();
            List<String>.Enumerator it = remainders.GetEnumerator();

            do {
                result += it.Current;
            } while(it.MoveNext());

            return result;
        }

        public static string Dec2Hex(string s) {
            string result = "";
            s = s.ToUpper();
            ulong n = Convert.ToUInt64(s);
            ulong q = n%16, r;
            List<String> remainders = new List<String>();

            while (n >= 16) {
                q = n / 16;
                r = n % 16;
                remainders.Add(r.ToString());
                n = q;
            }

            remainders.Add(q.ToString());

            remainders.Reverse();

            List<String>.Enumerator it = remainders.GetEnumerator();

            do {
               if(it.Current == "10")
                    result += 'A';
                else if(it.Current == "11")
                    result += 'B';
                else if(it.Current == "12")
                    result += 'C';
                else if(it.Current == "13")
                    result += 'D';
                else if(it.Current == "14")
                    result += 'E';
                else if(it.Current == "15")
                    result += 'F';
                else
                    result += it.Current;
            } while(it.MoveNext());

            return result;
        }
        
        public static string Dec2Oct(string s) {
            string result = "";
            ulong n = Convert.ToUInt64(s);
            List<String> remainders = new List<String>();
            ulong q = n%8, r;

            while(n >= 8) {
                q = n / 8;
                r = n % 8;
                remainders.Add(r.ToString());
                n = q;
            }

            result = q.ToString();

            remainders.Reverse();
            List<String>.Enumerator it = remainders.GetEnumerator();

            do {
                result += it.Current;
            } while(it.MoveNext());

            return result;
        }

        public static string Bin2Dec(string s) {
            string result;
            int i;
            int k = 0;
            ulong sum = 0;

            for(i = s.Length-1; i >= 0; i--) {
                if(s[i] == '1')
                    sum += (ulong)(Math.Pow(2,k));
                k++;
            }

            result = sum.ToString();

            return result;
        }

        public static string Bin2Hex(string s) {
            string result = "";
            ulong sum;
            double k;

            for(int i = s.Length - 1; i >= 0; i -= 4) {
                sum = 0;
                k = 0;
                for(int j = 0; j < 4; j++) {
                    if(i-j >= 0 && s[i-j] == '1')
                        sum += (ulong)Math.Pow(2, k);
                    k++;
                }
                if(sum == 10)
                    result += 'A';
                else if(sum == 11)
                    result += 'B';
                else if(sum == 12)
                    result += 'C';
                else if(sum == 13)
                    result += 'D';
                else if(sum == 14)
                    result += 'E';
                else if(sum == 15)
                    result += 'F';
                else
                    result += sum.ToString();
            }

            char[] aux = result.ToCharArray();
            Array.Reverse(aux);
            return new string(aux);
        }

        public static string Bin2Oct(string s) {
            string result = "";
            ulong sum;
            double k;

            for(int i = s.Length - 1; i >= 0; i -= 3) {
                sum = 0;
                k = 0;
                for(int j = 0; j < 3; j++) {
                    if(i - j >= 0 && s[i - j] == '1')
                        sum += (ulong)Math.Pow(2, k);
                    k++;
                }
                result += sum.ToString();
            }

            char[] aux = result.ToCharArray();
            Array.Reverse(aux);
            return new string(aux);
        }

        public static string Hex2Dec(string s) {
            string result;
            ulong sum = 0;
            int k = 0;
            s = s.ToUpper();

            for (int i = s.Length-1; i >= 0; i--) {
                if (s[i] == 'A')
                    sum += (ulong)(10 * Math.Pow(16, k));
                else if (s[i] == 'B')
                    sum += (ulong)(11 * Math.Pow(16, k));
                else if (s[i] == 'C')
                    sum += (ulong)(12 * Math.Pow(16, k));
                else if (s[i] == 'D')
                    sum += (ulong)(13 * Math.Pow(16, k));
                else if (s[i] == 'E')
                    sum += (ulong)(14 * Math.Pow(16, k));
                else if (s[i] == 'F')
                    sum += (ulong)(15 * Math.Pow(16, k));
                else
                    sum += (ulong)(Char.GetNumericValue(s[i])*Math.Pow(10,k));
                k++;
            }
            result = sum.ToString();

            return result;
        }

        public static string Hex2Bin(string s) {
            string result;
            string aux;

            aux = Hex2Dec(s);
            result = Dec2Bin(aux);
            return result;
        }

        public static string Hex2Oct(string s) {
            string result;
            string aux;

            aux = Hex2Dec(s);
            result = Dec2Oct(aux);

            return result;
        }
    }
}