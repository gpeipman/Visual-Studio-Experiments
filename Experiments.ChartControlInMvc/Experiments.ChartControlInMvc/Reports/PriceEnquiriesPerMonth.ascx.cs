using System.IO;
using System.Web.UI;

namespace Experiments.ChartControlInMvc.Reports
{
    public partial class PriceEnquiriesPerMonth : UserControl, IReportControl
    {
        public object DataSource
        {
            set
            {
                Chart1.DataSource = value;
            }
        }

        public override void DataBind()
        {
            base.DataBind();
            Chart1.DataBind();
        }

        public void SaveChartImage(Stream stream)
        {
            Chart1.SaveImage(stream);
        }
    }
}