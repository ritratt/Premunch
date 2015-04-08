using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premunch
{
    public interface ISitChecker
    {
        Boolean IsSitEnvironmentSetup();
        Boolean RunBasicSIT(String path);
        Boolean Result();
    }
}
