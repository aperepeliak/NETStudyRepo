using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
        }
    }

    public class CodeBuilder
    {
        private readonly string _className;
        private List<Field> _fields = new List<Field>();
        private const string @private = "private";
        private const string @public = "public";

        public CodeBuilder(string className)
        {
            _className = className;
        }

        public CodeBuilder AddField(string name, string type)
        {
            _fields.Add(new Field(name, type));
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Concat(@public, " class ", _className))
                .AppendLine("{");

            foreach (var field in _fields)
            {
                sb.AppendLine($"  {@public} {field.FieldType} {field.FieldName};");
            }

            sb.AppendLine("}");

            return sb.ToString();
        }

        private class Field
        {
            public string FieldName { get; }
            public string FieldType { get; }

            public Field(string name, string type)
            {
                FieldName = name;
                FieldType = type;
            }
        }
    }
}
