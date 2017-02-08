using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialType.Model
{
    public class Polinomial
    {
        public int Degree { get; set; }
        public int[] Nums { get; set; }

        public Polinomial(int[] numbers)
        {
            int[] validNums = DisposeStartingZeros(numbers);
            Degree = validNums.Length - 1;
            Nums = new int[validNums.Length];
            Array.Copy(validNums, Nums, validNums.Length);
        }

        public override string ToString()
        {
            string result = string.Empty;
            int l = Nums.Length;

            for (int i = 0, j = l - 1; i < l; i++, j--)
            {
                //result +=
                //    $"{(Nums[i] == 0 ? "" : $"{Nums[i]}x{(j == 0 ? "" : $"{j}")}{(i == l - 1 ? "" : " + ")}")}";

                //result +=
                //    $"{(Nums[i] == 0 ? "" : $"{(i == 0 ? "" : " + ")}{Nums[i]}x{(j == 0 ? "" : $"{j}")}")}";

                result +=
                    $"{(Nums[i] == 0 ? "" : $"{(i == 0 ? "" : " + ")}{(Nums[i] == 1 ? "" : $"{Nums[i]}")}x{(j == 0 ? "" : $"{j}")}")}";

            }

            return result;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        private int[] DisposeStartingZeros(int[] numbers)
        {
            int startIndex = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] != 0) break;
                else startIndex++;
            }

            int[] validArray = new int[numbers.Length - startIndex];
            Array.Copy(numbers, startIndex, validArray, 0, validArray.Length);

            return validArray;
        }
    }
}
