using System;
using Chakilo;
using Chakilo.Linq;

namespace Test {
    class Program {
        [MTAThread]
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            JtSQL.Run(new Work("/*aa*a**aaa\n//abc123\r\n*/abc//ddd\n"));
            Console.ReadLine();
        }
    }
}
