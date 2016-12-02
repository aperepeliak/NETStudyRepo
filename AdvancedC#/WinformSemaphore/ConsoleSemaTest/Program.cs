using System;
using System.Threading;

public class Example
{
    // A semaphore that simulates a limited resource pool.
    //
    private static Semaphore _pool;

    // A padding interval to make the output more orderly.
    private static int _padding;

    public static void Main()
    {
        string t1 = "test1";
        string t2 = t1;
        Console.WriteLine(t1, t2);
        t2 = "wow";
        Console.WriteLine(t1, t2);

    }
}