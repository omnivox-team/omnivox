using System;

class MapTest
{
    static void Main()
    {
        TestNew();
    }

    static void TestNew()
    {
        ExpectThrow<ArgumentException>(()=>{
             var _ = new Map(10, -10);
        });
        ExpectThrow<ArgumentException>(()=>{
             var _ = new Map(-10, 10);
        });
        ExpectThrow<ArgumentException>(()=>{
             var _ = new Map(-10, -10);
        });
        var m = new Map(10, 10);
        Console.WriteLine("{0}", m);
    }


    static void ExpectThrow<E>(Action fn)
    where E:Exception 
    {
        try {
            fn();
            throw new InvalidOperationException("code must throw exception");   
        }
        catch (E) {
            // ok
        }
    }
}