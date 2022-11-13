using System.Diagnostics.CodeAnalysis;

namespace backend.Application.Models
{
    [ExcludeFromCodeCoverage]
    public class SubscriberStatsModel
    {
        public int SubscribedLast24H { get; set; }

        public int SubscribedLast7D { get; set; }

        public double PercentageSubscribersWithPhoneNumber { get; set; }
    }
}
