using System;

class adder
{
    public static void Main (string [] args)
    {
        int x = 0, y = 0;
        if (args.Length > 0) {
            int.TryParse (args [0], out x);
        }
        if (args.Length > 1) {
            int.TryParse (args [1], out y);
        }
        Console.WriteLine (x + y);
    }
}