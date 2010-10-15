using System;
using System.Collections;
using Experiments.AspNetMvc3NewFeatures.Aspx.Controllers;
using Experiments.AspNetMvc3NewFeatures.Aspx.Models;
using Moq;
using NUnit.Framework;

namespace Experiments.AspNetMvc3NewFeatures.Aspx.Tests 
{
    [TestFixture]
    public class HomeControllerTests 
    {
        [Test]
        public void GetChartReturnsChart()
        {
            var data = GetChartData();
            var mock = new Mock<ChartModel>();
            mock.Setup(c => c.GetChartData())
                .Returns(data);

            var controller = new HomeController(mock.Object);
            var result = controller.GetChart();

            mock.Verify();
            Assert.IsNotNull(result, "Result is null");
            Assert.IsInstanceOf<ChartResult>(result,"Result is not ChartResult");
        }

        private static IList GetChartData()
        {
            return new ArrayList
                       {
                           new { X = DateTime.Now.AddMonths(-2), Y = 200 },
                           new { X = DateTime.Now.AddMonths(-1), Y = 300 },
                           new { X = DateTime.Now, Y = 500 }
                       };
        }
    }
}
