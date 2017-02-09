using PolynomialType.Model.CustomExceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialType.Model
{
    public class Polynomial : ICloneable, IEnumerable
    {
        public int Degree { get; }
        public int[] Nums { get; }

        public Polynomial() : this(1) { }
        public Polynomial(int degree, int firstCoefficient = 0)
        {
            if (degree < 0)
            {
                throw new InvalidInputParamsForPolynomException
                    ("The input degree parameter was less than zero");
            }

            Degree = degree;
            Nums = new int[Degree + 1];
            Nums[0] = firstCoefficient;
        }

        public Polynomial(int[] numbers)
        {
            int[] validNums = DisposeStartingZeros(numbers);

            if (validNums.Length == 0) { throw new InvalidInputParamsForPolynomException(); }

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
            var toCompare = obj as Polynomial;
            if (toCompare != null) { return Nums.SequenceEqual(toCompare.Nums); }
            return false;
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public object Clone()
        {
            return new Polynomial(Nums);
        }
        public IEnumerator GetEnumerator()
        {
            return Nums.GetEnumerator();
        }

        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            var biggerPolynom = p1.Degree > p2.Degree ? p1 : p2;
            var smallPolynom = p1.Degree <= p2.Degree ? p1 : p2;

            int[] resultNums = new int[biggerPolynom.Nums.Length];

            int startIndex = 0;
            int elementsToCopy = biggerPolynom.Nums.Length - smallPolynom.Nums.Length;

            Array.Copy(biggerPolynom.Nums, startIndex,
                resultNums, startIndex, elementsToCopy);

            for (int i = elementsToCopy, j = 0; i < biggerPolynom.Nums.Length; i++, j++)
            {
                resultNums[i] = biggerPolynom.Nums[i] + smallPolynom.Nums[j];
            }

            return new Polynomial(resultNums);
        }
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            var biggerPolynom = p1.Degree >= p2.Degree ? p1 : p2;
            var smallPolynom = p1.Degree < p2.Degree ? p1 : p2;

            int[] resultNums = new int[biggerPolynom.Nums.Length];

            int startIndex = 0;
            int elementsToCopy = biggerPolynom.Nums.Length - smallPolynom.Nums.Length;

            Array.Copy(biggerPolynom.Nums, startIndex,
                resultNums, startIndex, elementsToCopy);

            for (int i = elementsToCopy, j = 0; i < biggerPolynom.Nums.Length; i++, j++)
            {
                resultNums[i] = biggerPolynom.Nums[i] - smallPolynom.Nums[j];
            }

            return new Polynomial(resultNums);
        }

        public static Polynomial operator *(Polynomial polynom, int number)
        {
            var result = new Polynomial(polynom.Nums);

            for (int i = 0; i < result.Nums.Length; i++)
            {
                result.Nums[i] = polynom.Nums[i] * number;
            }

            return result;
        }
        public static Polynomial operator *(int number, Polynomial polynom)
        {
            return polynom * number;
        }

        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            var result = new Polynomial(p1.Degree + p2.Degree);

            Polynomial[] arr = new Polynomial[p1.Nums.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Polynomial(p1.Degree - i + p2.Degree);
                for (int j = 0; j < p2.Nums.Length; j++)
                {
                    arr[i].Nums[j] = p2.Nums[j] * p1.Nums[i];
                }
                result += arr[i];
            }

            return result;
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
