using MatricesDomain.Model.CustomExceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatricesDomain.Model
{
    public class Matrix : IEnumerable, ICloneable
    {
        public int NumRows { get; }
        public int NumColumns { get; }

        private int[,] _body;

        public Matrix(int size) : this(size, size) { }
        public Matrix(int rows = 1, int columns = 1)
        {
            if (rows < 1 || columns < 1) { throw new InvalidSizeParameterException(); }
            NumRows = rows;
            NumColumns = columns;
            _body = new int[NumRows, NumColumns];
        }

        public Matrix(int[,] inputMatrix)
        {
            int rank = inputMatrix.Rank;

            if (rank > 2) { throw new Exception("The input array had invalid number of dimensions"); }

            NumRows = inputMatrix.GetLength(0);
            NumColumns = inputMatrix.GetLength(1);

            _body = new int[NumRows, NumColumns];

            for (int i = 0; i < NumRows; i++)
            {
                for (int j = 0; j < NumColumns; j++)
                {
                    _body[i, j] = inputMatrix[i, j];
                }
            }
        }

        public void SaveToXml() { }
        public void LoadFromXml() { }

        public int this[int row, int column]
        {
            get
            {
                return _body[row, column];
            }
            set
            {
                _body[row, column] = value;
            }
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            CheckMatrixSizesForSum(m1, m2);

            var result = new Matrix(m1.NumRows, m1.NumColumns);

            for (int i = 0; i < m1.NumRows; i++)
            {
                for (int j = 0; j < m1.NumColumns; j++)
                {
                    result[i, j] = m1[i, j] + m2[i, j];
                }
            }

            return result;
        }

        public static Matrix operator +(Matrix matrix, int number)
        {
            var result = new Matrix(matrix.NumRows, matrix.NumColumns);

            for (int i = 0; i < matrix.NumRows; i++)
            {
                for (int j = 0; j < matrix.NumColumns; j++)
                {
                    result[i, j] = matrix[i, j] + number;
                }
            }

            return result;
        }

        public static Matrix operator +(int number, Matrix matrix)
        {
            return matrix + number;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            CheckMatrixSizesForSum(m1, m2);

            var result = new Matrix(m1.NumRows, m1.NumColumns);

            for (int i = 0; i < m1.NumRows; i++)
            {
                for (int j = 0; j < m1.NumColumns; j++)
                {
                    result[i, j] = m1[i, j] - m2[i, j];
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix matrix, int number)
        {
            var result = new Matrix(matrix.NumRows, matrix.NumColumns);

            for (int i = 0; i < matrix.NumRows; i++)
            {
                for (int j = 0; j < matrix.NumColumns; j++)
                {
                    result[i, j] = matrix[i, j] - number;
                }
            }

            return result;
        }

        public static Matrix operator -(int number, Matrix matrix)
        {
            return matrix - number;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            CheckMatrixSizesForMultiplication(m1, m2);

            var result = new Matrix(m1.NumRows, m2.NumColumns);


            for (int i = 0; i < m1.NumRows; i++)
            {
                for (int j = 0; j < m1.NumRows; j++)
                {
                    for (int k = 0; k < m1.NumColumns; k++)
                    {
                        result[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }

            return result;
        }



        //public static Matrix operator *(Matrix matrix, int primitiveType)
        //{

        //}

        //public static Matrix operator *(int primitiveType, Matrix matrix)
        //{

        //}

        public override string ToString()
        {
            string matrixDisplay = string.Empty;

            for (int i = 0; i < NumRows; i++)
            {
                for (int j = 0; j < NumColumns; j++)
                {
                    matrixDisplay += $"{_body[i, j]}\t";
                }
                matrixDisplay += $"\n";
            }
            return matrixDisplay;
        }
        public override bool Equals(object obj)
        {
            var toCompare = obj as Matrix;

            if (toCompare != null)
            {
                if (NumColumns != toCompare.NumColumns ||
                    NumRows != toCompare.NumRows) { return false; }

                for (int i = 0; i < NumRows; i++)
                {
                    for (int j = 0; j < NumColumns; j++)
                    {
                        if (_body[i, j] != toCompare[i, j]) { return false; }
                    }
                }

                return true;
            }

            return false;
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        private static void CheckMatrixSizesForSum(Matrix m1, Matrix m2)
        {
            if (m1.NumRows != m2.NumRows ||
                m1.NumColumns != m2.NumColumns)
            {
                throw new InvalidMatricesSizesException();
            }
        }

        private static void CheckMatrixSizesForMultiplication(Matrix m1, Matrix m2)
        {
            if (m1.NumColumns != m2.NumRows)
                throw new InvalidMultiplicationException();
        }

        // Interfaces implementations
        public IEnumerator GetEnumerator()
        {
            return _body.GetEnumerator();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
