using MatricesDomain.Model.CustomExceptions;
using System;
using System.Xml.Linq;
using System.Linq;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MatricesDomain.Model
{
    [Serializable]
    public class Matrix : ICloneable
    {
        private int[,] _body;

        public int NumRows { get; }
        public int NumColumns { get; }

        public Matrix() : this(1) { }
        public Matrix(int size) : this(size, size) { }
        public Matrix(int rows, int columns)
        {
            if (rows < 1 || columns < 1) { throw new InvalidSizeParameterException(); }
            NumRows = rows;
            NumColumns = columns;
            _body = new int[NumRows, NumColumns];
        }

        public Matrix(int[,] inputMatrix)
        {
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

        public void SaveToXml(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException
                    ("The input parameter for SaveToXml() was null.");
            }

            var document = new XDocument();
            var matrix = new XElement("Matrix",
                    new XAttribute("NumRows", NumRows),
                    new XAttribute("NumColumns", NumColumns));

            for (int i = 0; i < NumRows; i++)
            {
                var row = new XElement("Row");

                for (int j = 0; j < NumColumns; j++)
                {
                    row.Add(new XElement("Value", _body[i, j]));
                }

                matrix.Add(row);
            }

            document.Add(matrix);
            document.Save(fileName);
        }
        public static Matrix LoadFromXml(string fileName)
        {
            try
            {
                var document = XDocument.Load(fileName);

                var query = (from row in document.Element("Matrix").Elements("Row")
                             from v in row.Elements("Value")
                             select int.Parse(v.Value))
                            .ToArray();

                int rows = int.Parse(document.Element("Matrix").Attribute("NumRows").Value);
                int columns = int.Parse(document.Element("Matrix").Attribute("NumColumns").Value);

                int[,] result = new int[rows, columns];

                int k = 0;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        result[i, j] = query[k];
                        k++;
                    }
                }

                return new Matrix(result);
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException
                    ($"The given fileName (\"{fileName}\") in LoadFromXml() was not found.", ex);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException
                    ("Invalid XNodes names or structure when executing LoadFromXml()." +
                    "Check your xml-source.", ex);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException
                    ("The input parameter for LoadFromXml() was null.", ex);
            }
        }

        public void Serialize(string fileName)
        {
            var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, this);
            }
        }
        public static Matrix Deserialize(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException
                    ($"The given fileName (\"{fileName}\") in Deserialize() was not found.");
            }

            var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (Matrix)formatter.Deserialize(fileStream);
            }
        }

        public int this[int row, int column]
        {
            get
            {
                try
                {
                    return _body[row, column];
                }
                catch (IndexOutOfRangeException ex)
                {
                    throw new IndexOutOfRangeException
                        ($"Matrix indexer attempted to access an element [{row},{column}] " +
                        $"that was outside the matrix bounds ([{NumRows},{NumColumns}])", ex);
                }
            }
            set
            {
                try
                {
                    _body[row, column] = value;
                }
                catch (IndexOutOfRangeException ex)
                {
                    throw new IndexOutOfRangeException
                        ($"Matrix indexer attempted to access an element [{row},{column}] " +
                        $"that was outside the matrix bounds ([{NumRows},{NumColumns}])", ex);
                }
            }
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.NumRows != m2.NumRows ||
                m1.NumColumns != m2.NumColumns)
            { throw new InvalidMatricesSizesException(); }

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
            if (m1.NumRows != m2.NumRows ||
                m1.NumColumns != m2.NumColumns)
            { throw new InvalidMatricesSizesException(); }

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
            if (m1.NumColumns != m2.NumRows)
            { throw new InvalidMultiplicationException(); }

            var result = new Matrix(m1.NumRows, m2.NumColumns);

            for (int i = 0; i < m1.NumRows; i++)
            {
                for (int j = 0; j < m2.NumColumns; j++)
                {
                    for (int k = 0; k < m1.NumColumns; k++)
                    {
                        result[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }

            return result;
        }
        public static Matrix operator *(Matrix matrix, int number)
        {
            var result = new Matrix(matrix.NumRows, matrix.NumColumns);

            for (int i = 0; i < result.NumRows; i++)
            {
                for (int j = 0; j < result.NumColumns; j++)
                {
                    result[i, j] = matrix[i, j] * number;
                }
            }

            return result;
        }
        public static Matrix operator *(int number, Matrix matrix)
        {
            return matrix * number;
        }

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

        public object Clone()
        {
            return new Matrix(_body);
        }
    }
}
