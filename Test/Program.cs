using System;
using Chakilo;
using Chakilo.Linq;

namespace Test {
    class Program {
        [MTAThread]
        static void Main(string[] args) {
            Console.WriteLine("Hello World!\n\n");
            JtSQL.Run(new Work("// find users that user_id > 0 and < 5\n$var users = <SELECT * FROM `user` WHERE user_id > {{0}} AND user_id < {{Math.abs(5)}};>\nfor (;;) {if (condition) {var result = $<SELECT * FROM {{table}}>}}"));
            Console.ReadLine();
        }
    }
}
