using System.Collections.Generic;

namespace Wpf.CartesianChart.Basic_Bars
{
    internal interface IWorkWithLog
    {
        List<string> ReadLog(string logAdress);
    }
}