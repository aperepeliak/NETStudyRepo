namespace SA_GenericReflection
{
    public class Employee
    {
        public string Name { get; set; }

        public void Speak<T>() => System.Console.WriteLine(typeof(T).Name);
    }
}