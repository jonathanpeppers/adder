using System;
using System.IO;
using System.Runtime.InteropServices;

class adder
{
    static void Main (string [] args)
    {
        int x = 0, y = 0;
        if (args.Length > 0) {
            int.TryParse (args [0], out x);
        }
        if (args.Length > 1) {
            int.TryParse (args [1], out y);
        }
        Console.WriteLine (Native.add (x, y));
    }

    class Native
    {
        static Native ()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT) {
                string dir = Path.GetDirectoryName (typeof (Native).Assembly.Location);
                if (Environment.Is64BitProcess) {
                    Console.WriteLine ("64 bit");
                    SetDllDirectory (Path.Combine (dir, "x64"));
                } else {
                    Console.WriteLine ("32 bit");
                    SetDllDirectory (Path.Combine (dir, "x86"));
                }
            }
        }

        [DllImport ("kernel32.dll", SetLastError = true)]
        static extern bool SetDllDirectory (string lpPathName);

        [DllImport ("libadder.dll")]
        public static extern int add (int x, int y);
    }
}