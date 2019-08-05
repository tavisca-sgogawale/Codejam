using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class TriFibonacci
    {
        public class SequenceProperty
        {
            public static bool IsValidSequenceConstraints(int[] seq)
            {
                int count = 0;
                foreach (int i in seq)
                    if (i < 0 || i > 1000000) count += 1;
                if (count == 1 && seq.Length >= 4 && seq.Length <= 20) return true;
                else return false;
            }

            public static bool IsValidSequence(int[] seq)
            {
                var validSequence = false;
                for(int i =0; i<seq.Length-3;i++)
                {
                    if (seq[i + 3] == seq[i] + seq[i + 1] + seq[i + 2])
                    {
                        validSequence = true;
                    }
                    else
                    {
                        validSequence = false;
                        break;
                    }
                       
                }
                return validSequence;
            }

        }
        
        public int Complete(int[] test)
        {
            var missingPosition = Array.IndexOf(test, -1);

            if (SequenceProperty.IsValidSequenceConstraints(test) == true)
            {
                var result = 0;
                if (missingPosition > 2)
                {
                    result = test[missingPosition - 1] + test[missingPosition - 2] + test[missingPosition - 3];
                    test[missingPosition] = result;
                }
                else
                {
                    for(int i = 0;i<test.Length;i++)
                    {
                        if (i != missingPosition && i <= 2)
                            result +=  test[i];
                    }
                    result = test[3]-result;
                    test[missingPosition] = result;
                }
            }
            if (SequenceProperty.IsValidSequence(test)==true)
                return test[missingPosition];
            else
                return -1;

        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            TriFibonacci triFibonacci = new TriFibonacci();
            do
            {
                string[] values = input.Split(',');
                int[] numbers = Array.ConvertAll<string, int>(values, delegate (string s) { return Int32.Parse(s); });
                int result = triFibonacci.Complete(numbers);
                Console.WriteLine(result);
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}