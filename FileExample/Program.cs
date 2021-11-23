using System;
using System.IO;

namespace FileExample
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("",FileAccess.ReadWrite);
        }
    }
}
