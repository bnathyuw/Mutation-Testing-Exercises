using System.Collections.Generic;

namespace MutationTestingExercises.Exercise1CallCentre
{
    public interface Alert
    {
        void Raise();
    }

    public class SalesMonitor
    {
        private const int HighValueThreshold = 100;
        private readonly List<Alert> _alerts = new List<Alert>();

        public void AddAlert(Alert alert)
        {
            _alerts.Add(alert);
        }

        public void ProcessSale(int amount)
        {
            if (amount < HighValueThreshold)
                return;

            foreach (var alert in _alerts)
            {
                alert.Raise();
            }
        }
    }
}