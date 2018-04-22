using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace PatienceSort
{
    class Program
    {
        static void Main()
        {
            Generation.Generator();
            Sorter.Sort();
        }
    }
}
