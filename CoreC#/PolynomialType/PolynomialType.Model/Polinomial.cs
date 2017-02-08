using PolynomialType.Model.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialType.Model
{
    public class Polinomial
    {
        public int Degree { get; }
        public int[] Nums { get; }

        public Polinomial(int[] numbers)
        {
            int[] validNums = DisposeStartingZeros(numbers);
            if (validNums.Length == 0) { throw new InvalidInputParamsForPolinomException(); }

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
                string plusSign = $"{(i == 0 ? "" : " + ")}";
                string coef = $"{(Nums[i] == 1 ? (i == l - 1 ? $"{Nums[i]}" : "") : $"{Nums[i]}")}";
                string variable = $"{(i == l - 1 ? "" : "x^")}";
                string degree = $"{(j == 0 ? "" : $"{j}")}";

                result += $"{(Nums[i] == 0 ? "" : $"{plusSign}{coef}{variable}{degree}")}";
            }

            return result;
        }
        public override bool Equals(object obj)
        {
            var toCompare = obj as Polinomial;
            if (toCompare != null) { return Nums.SequenceEqual(toCompare.Nums); }
            return false;
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
