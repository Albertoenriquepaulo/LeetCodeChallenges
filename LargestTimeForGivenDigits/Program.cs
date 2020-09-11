using System;

namespace LargestTimeForGivenDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 0, 2, 7, 6 };//{ 0, 3, 0, 5 };//{ 1, 2, 3, 4 }; //{ 5, 5, 5, 5 };//{ 2, 0, 6, 6 } //0, 2, 7, 6

            string test = Solution.LargestTimeFromDigits(A);

        }
        public class Solution
        {
            public static string LargestTimeFromDigits(int[] A)
            {
                string emptyStr = string.Empty;
                int[,] hourMin = new int[2, 2];

                int[] result;
                int hour, minutes;

                if (A.Length != 4)
                {
                    return emptyStr;
                }

                for (int i = 0; i <= 1; i++)
                {
                    hourMin[0, 0] = i == 1 ? GetCombinationOfTwoNumberCloserTo(24, A, hourMin[0, 0]) : GetCombinationOfTwoNumberCloserTo(24, A);

                    if (hourMin[0, 0] != -1)
                    {
                        result = ExtractNumberFromArray(hourMin[0, 0] / 10, A);
                        result = ExtractNumberFromArray(hourMin[0, 0] % 10, result);
                        hourMin[0, 1] = GetCombinationOfTwoNumberCloserTo(60, result);
                    }

                    if ((hourMin[0, 1] == -1) == false)
                    {
                        break;
                    }
                }

                for (int i = 0; i <= 1; i++)
                {
                    hourMin[1, 1] = i == 1 ? GetCombinationOfTwoNumberCloserTo(24, A, hourMin[1, 1]) : GetCombinationOfTwoNumberCloserTo(24, A);
                    hourMin[1, 1] = GetCombinationOfTwoNumberCloserTo(60, A);
                    if (hourMin[1, 1] != -1)
                    {
                        result = ExtractNumberFromArray(hourMin[1, 1] / 10, A);
                        result = ExtractNumberFromArray(hourMin[1, 1] % 10, result);
                        hourMin[1, 0] = GetCombinationOfTwoNumberCloserTo(24, result);
                    }
                    if ((hourMin[1, 0] == -1) == false)
                    {
                        break;
                    }
                }


                if ((hourMin[0, 0] == -1 || hourMin[0, 1] == -1) && (hourMin[1, 0] == -1 || hourMin[1, 1] == -1))
                {
                    return emptyStr;
                }

                hour = hourMin[0, 0];
                minutes = hourMin[0, 1];
                if (hourMin[0, 0] < hourMin[1, 0] && hourMin[1, 0] < 24)
                {
                    hour = hourMin[1, 0];
                    minutes = hourMin[1, 1];
                }

                if ((hourMin[0, 0] == -1 || hourMin[0, 1] == -1) && (hourMin[1, 0] != -1 && hourMin[1, 1] != -1))
                {
                    hour = hourMin[1, 0];
                    minutes = hourMin[1, 1];
                }

                return $"{GetString(hour)}:{GetString(minutes)}";

            }

            public static int GetCombinationOfTwoNumberCloserTo(int number, int[] A, int? diferentThan = null)
            {
                int tempCombinationNumber = -1;
                int combinationNumber = -1;

                for (int i = 0; i < A.Length; i++)
                {
                    for (int j = 0; j < A.Length; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }
                        tempCombinationNumber = A[i] * 10 + A[j];
                        if (tempCombinationNumber > combinationNumber && tempCombinationNumber < number
                            && (diferentThan == null ? true : tempCombinationNumber != diferentThan))
                        {
                            combinationNumber = tempCombinationNumber;
                        }
                    }
                }
                return combinationNumber;
            }
            public static int[] ExtractNumberFromArray(int number, int[] A)
            {
                bool found = false;
                int[] result = new int[A.Length - 1];

                for (int i = 0, j = 0; i < A.Length; i++)
                {
                    if (A[i] == number && found == false)
                    {
                        found = true;
                    }
                    else
                    {
                        result[j++] = A[i];
                    }
                }

                return found ? result : A;
            }

            public static string GetString(int number)
            {
                return number < 10 ? $"0{number.ToString()}" : $"{number.ToString()}";
            }

            public static int ReverseInt(int num)
            {
                int result = 0;
                while (num > 0)
                {
                    result = result * 10 + num % 10;
                    num /= 10;
                }
                return result;
            }

        }

    }
}
