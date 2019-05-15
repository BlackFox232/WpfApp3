using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiagramsParse
{
    internal interface IWorkWithLog
    {
        List<string> ReadLog(string logAdress);
    }
}