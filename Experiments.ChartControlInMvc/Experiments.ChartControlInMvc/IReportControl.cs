using System;
using System.IO;

namespace Experiments.ChartControlInMvc
{
    public interface IReportControl : IDisposable
    {
        void DataBind();
        object DataSource { set; }
        void SaveChartImage(Stream stream);
    }
}