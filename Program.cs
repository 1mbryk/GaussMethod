using System;
class Program
{
    public static void Main()
    {
        GaussMethod method = new();
        Console.Clear();
        try
        {

            method.Start();
        }
        catch (Exception e)
        {
            Console.Write(e);
        }
    }


}