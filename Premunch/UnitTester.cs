using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Premunch
{
    public class UnitTester : IUnitTester
    {
        private List<String> _paths;
        private String _command;
        
        private List<String> _errors;
        private String _error;

        public Boolean _result { get; private set; }

        public UnitTester(String dll)
        {
            _paths = new List<String>();
            _errors = new List<String>();
            _error = String.Empty;
            _command = "NUnit " + dll + " -results";
        }

        public void CheckTestFolder(List<String> paths )
        {
            foreach (var path in paths)
            {
                if(ContainsDLL(path))
                    _paths.Add(path);
            }
        }

        public void RunTests()
        {
            foreach (var path in _paths)
            {
                if (!ExecuteTestCommand(path))
                {
                    //Test failed so set result to false and add error  
                    _result = false;
                }
            }
            //All tests passed
            _result = true;
        }

        public String ReportResult()
        {
            if (_result)
                //Write results to a file
                return "Success";
            else
            {
                //Write results to a file
                return "Failed";
            }
        }

        public Boolean Result()
        {
            return _result;
        }

        #region Utils

        private Boolean ContainsDLL(String path)
        {
            //Check if path contains a valid DLL.
            return true;
        }

        private Boolean ExecuteTestCommand(String path)
        {
            //Run NUnit test command and get results into a string.
            System.Diagnostics.Process.Start("CMD.exe", _command);
            //Check if passed
            return true;

            //if failed set error message and return false;
            _errors.Add("Outputfromruncommand");
            return false;
        }

        #endregion
}
}
