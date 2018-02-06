using System;
using Chakilo;
using Chakilo.Linq;

namespace Test {
    class Program {
        [MTAThread]
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            JtSQL.Run(new Work("// find users that user_id > 0\n$<SELECT * FROM `user` WHERE user_id > {{0}};>"));
            Console.ReadLine();
        }
    }
}
