using System;

namespace BullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            string secret = "1807";
            string guess = "7810";

            string result = Solution.GetHint(secret, guess);
            Console.WriteLine(result);

            secret = "1123"; guess = "0111";
            result = Solution.GetHint(secret, guess);
            Console.WriteLine(result);

            secret = "1807";
            guess = "7811";
            result = Solution.GetHint(secret, guess);
            Console.WriteLine(result);

            secret = "1717";
            guess = "7717";
            result = Solution.GetHint(secret, guess);
            Console.WriteLine(result);

            secret = "10458663";
            guess = "19548199";
            result = Solution.GetHint(secret, guess);
            Console.WriteLine(result);
        }
    }

    public static class Solution
    {
        public static string GetHint(string secret, string guess)
        {
            if (secret == null || guess == null || secret.Length != guess.Length)
            {
                return null;
            }
            int bulls = GetBulls(ref secret, ref guess);
            int cows = GetCows(secret, guess);

            return $"{bulls}A{cows}B";
        }

        public static int GetBulls(ref string secret, ref string guess)
        {
            int bulls = 0;
            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    secret = secret.Remove(i, 1);
                    guess = guess.Remove(i, 1);
                    bulls++; i--;
                }
            }
            return bulls;
        }

        public static int GetCows(string secret, string guess)
        {
            int cows = 0;
            for (int i = 0; i < secret.Length; i++)
            {
                for (int j = 0; j < guess.Length; j++)
                {
                    if (secret[i] == guess[j])
                    {
                        secret = secret.Remove(i, 1);
                        guess = guess.Remove(j, 1);
                        cows++; i--;
                        break;
                    }
                }
            }
            return cows;
        }
    }
}
