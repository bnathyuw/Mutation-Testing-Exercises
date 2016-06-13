using System.Collections.Generic;

namespace MutationTestingExercises.Exercise1CallCentre
{
    public interface Alert
    {
        void Raise();
    }

    public class SalesMonitor
    {
        private readonly List<Alert> _alerts = new List<Alert>();

        public void AddAlert(Alert alert)
        {
            _alerts.Add(alert);
        }

        public void ProcessSale(int amount)
        {
            if (amount < 100)
                return;

            foreach (var alert in _alerts)
            {
                alert.Raise();
            }
        }
    }
}