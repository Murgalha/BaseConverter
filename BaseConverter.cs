using System;
using System.Collections.Generic;

namespace BaseConverter {

    public static class BaseConverter {

        public static bool IsBinary(string s) {

            int i;

            for (i = 0; i < s.Length; i++) {
                if (s[i] != '1' && s[i] != '0') {
                    return false;
                }
            }

            if(s.Length > 64)
                return false;
            return true;
        }

        public static string Dec2Bin(string s) {

            string result = "";
            ulong n = Convert.ToUInt64(s);
            List<String> remainders = new List<String>();
            ulong q = 0, r;

            while(n >= 2) {
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
            List<ulong> remainders = new List<ulong>();

            while (n >= 16) {
                q = n / 16;
                r = n % 16;
                remainders.Add(r);
                n = q;
            }

            remainders.Add(q);

            remainders.Reverse();

            List<ulong>.Enumerator it = remainders.GetEnumerator();

            do {
               if(it.Current == 10)
                    result += 'A';
                else if(it.Current == 11)
                    result += 'B';
                else if(it.Current == 12)
                    result += 'C';
                else if(it.Current == 13)
                    result += 'D';
                else if(it.Current == 14)
                    result += 'E';
                else if(it.Current == 15)
                    result += 'F';
                else
                    result += it.Current.ToString();
            } while(it.MoveNext());

            return result;
        }
        
        public static string Dec2Oct(string s) {
            
            string result = "";
            ulong n = Convert.ToUInt64(s);
            List<String> remainders = new List<String>();
            ulong q = 0, r;

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
            double k = 0;

            for (int i = (s.Length/4)-1; i >= 0; i--) {
                sum = 0;
                for (int j = 3; j >= 0; j--) {
                    if(s[(4 * i) + j] == '1')
                        sum += (ulong)Math.Pow(2, k);
                    k++;
                }
                if (sum == 10)
                    result += 'A';
                else if (sum == 11)
                    result += 'B';
                else if (sum == 12)
                    result += 'C';
                else if (sum == 13)
                    result += 'D';
                else if (sum == 14)
                    result += 'E';
                else if (sum == 15)
                    result += 'F';
                else
                    result += sum.ToString();
            }
            return result;
        }
        /* bin2oct */
    }
}