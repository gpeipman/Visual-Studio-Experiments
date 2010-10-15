using System;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Experiments.AspNetMvc3NewFeatures.Aspx
{
    public class ChartResult : ActionResult
    {
        private readonly Chart _chart;
        private readonly string _format;

        public ChartResult(Chart chart, string format)
        {
            if (chart == null)
                throw new ArgumentNullException("chart");

            _chart = chart;
            _format = format;

            if (string.IsNullOrEmpty(_format))
                _format = "png";
        }

        public Chart Chart
        {
            get { return _chart; }
        }

        public string Format
        {
            get { return _format; }
        }

        public override void ExecuteResult(ControllerContext context)
        {
            _chart.Write(_format);
        }
    }
}