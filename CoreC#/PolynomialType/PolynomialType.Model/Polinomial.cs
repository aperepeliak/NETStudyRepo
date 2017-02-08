using PolynomialType.Model.CustomExceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialType.Model
{
    public class Polinomial : ICloneable, IEnumerable
    {
        public int Degree { get; }
        public int[] Nums { get; }

        public Polinomial(int degree)
        {
            if (degree < 0)
            {
                throw new InvalidInputParamsForPolinomException
                    ("The input degree parameter was less than zero");
            }

            Degree = degree;
            Nums = new int[Degree + 1];
            Nums[0] = 1;
        }
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
                string variable = $"{(i == l - 1 ? "" : (j == 1 ? "x" : "x^"))}";
                string degree = $"{(j < 2 ? "" : $"{j}")}";

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

        public object Clone()
        {
            return new Polinomial(Nums);
        }
        public IEnumerator GetEnumerator()
        {
            return Nums.GetEnumerator();
        }

        public static Polinomial operator +(Polinomial p1, Polinomial p2)
        {
            var biggerPolinom = p1.Degree > p2.Degree ? p1 : p2;
            var smallPolinom = p1.Degree <= p2.Degree ? p1 : p2;

            int[] resultNums = new int[biggerPolinom.Nums.Length];

            int startIndex = 0;
            int elementsToCopy = biggerPolinom.Nums.Length - smallPolinom.Nums.Length;

            Array.Copy(biggerPolinom.Nums, startIndex,
                resultNums, startIndex, elementsToCopy);

            for (int i = elementsToCopy, j = 0; i < biggerPolinom.Nums.Length; i++, j++)
            {
                resultNums[i] = biggerPolinom.Nums[i] + smallPolinom.Nums[j];
            }

            return new Polinomial(resultNums);
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
