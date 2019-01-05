using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_EPAM
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramConverter[] arr = { new ProgramConverter(), new ProgramHelper(),
                                       new ProgramConverter(), new ProgramHelper() };
            
            //ProgramHelper s = new ProgramHelper();
            //Console.WriteLine(s.CheckCodeSyntax("sdf", "sdf"));

            foreach (var e in arr)
            {
                if (e is ICodeChecker)
                {
                    //e.CheckCodeSyntax();
;                   Console.WriteLine(e.ConvertToCSharp("") + "(ProgramHelper)\n");
                }
                else
                {
                    Console.WriteLine(e.ConvertToCSharp("") + "(ProgramConverter)");
                    Console.WriteLine(e.ConvertToVB("") + "(ProgramConverter)\n");
                }
            }
            Console.ReadKey();
        }
    }
}
