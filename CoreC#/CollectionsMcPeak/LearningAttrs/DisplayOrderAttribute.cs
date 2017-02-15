using System;

namespace LearningAttrs
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DisplayOrderAttribute : Attribute
    {
        public int Position { get; private set; }
        public string Foo { get; set; }
        public DisplayOrderAttribute(int position)
        {
            Position = position;
        }
    }
}