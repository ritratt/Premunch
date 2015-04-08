using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Premunch
{
    public interface IUnitTester
    {
        void CheckTestFolder(List<String> paths );
        void RunTests();
        String ReportResult();
        Boolean Result();
    }
}
