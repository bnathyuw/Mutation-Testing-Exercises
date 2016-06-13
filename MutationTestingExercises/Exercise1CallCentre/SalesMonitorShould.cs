using Moq;
using NUnit.Framework;

namespace MutationTestingExercises.Exercise1CallCentre
{
    [TestFixture]
    public class SalesMonitorShould
    {
        private SalesMonitor _salesMonitor;
        private Mock<Alert> _alert;

        [SetUp]
        public void SetUp()
        {
            _salesMonitor = new SalesMonitor();
            _alert = new Mock<Alert>();
            _salesMonitor.AddAlert(_alert.Object);
        }

        [Test]
        public void Raise_an_alert_when_a_high_value_sale_is_made()
        {
            _salesMonitor.ProcessSale(101);

            _alert.Verify(a => a.Raise());
        }

        [Test]
        public void Not_raise_an_alert_when_a_low_value_sale_is_made()
        {
            _salesMonitor.ProcessSale(99);

            _alert.Verify(a => a.Raise(), Times.Never);
        }
    }
}
