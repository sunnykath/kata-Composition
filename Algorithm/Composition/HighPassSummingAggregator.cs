using System.Collections.Generic;

namespace Algorithm.Composition
{
    public class HighPassSummingAggregator
    {
        
        public HighPassSummingAggregator(
            IEnumerable<Measurement> measurements)
        {
            _measurements = measurements;
            _filter = new HighPassFilter();
            _aggregator = new SummingStrategy();
        }

        public Measurement Aggregate()
        {
            var measurements = _measurements;
            measurements = _filter.Filter(measurements);            
            return _aggregator.Aggregate(measurements);
        }

        private readonly IEnumerable<Measurement> _measurements;
        private readonly IMeasurementFilter _filter;
        private readonly IAggregationStrategy _aggregator;
    }
}