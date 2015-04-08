using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace Premunch
{
    public class Muncher
    {
        private IUnitTester _unitTester;
        private ISitChecker _sitChecker;

        public Muncher(UnitTester unitTester)
        {
            _unitTester = unitTester;
        }

        public void AttachToIDE()
        {
            //Do stuff. Run methods after every compile.
            //Code copied from http://stackoverflow.com/questions/826398/is-it-possible-to-dynamically-compile-and-execute-c-sharp-code-fragments
            while (true)
            {
                var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v3.5" } });
                var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, "Muncher.exe", true);
                parameters.GenerateExecutable = true;
                CompilerResults results = csc.CompileAssemblyFromSource(parameters, "unitester");
                //Run unitests here
                _unitTester.RunTests();

                results.Errors.Cast<CompilerError>().ToList().ForEach(error => Console.WriteLine(error.ErrorText));
            }
        }

        public String Color()
        {
            if (!_unitTester.Result())
            {
                _unitTester.ReportResult();
                return "Red";
            }

            if(!_sitChecker.Result())
                return "Red";

            return "Green";
        }
    }
}
