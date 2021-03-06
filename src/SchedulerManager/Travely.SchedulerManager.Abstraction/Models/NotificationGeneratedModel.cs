using System.Collections.Generic;
using System.Text.Json.Serialization;
using Travely.SchedulerManager.Common.Enums;

namespace Travely.SchedulerManager
{
    public class NotificationGeneratedModel
    {
        public long ScheduleId { get; set; }
        public long RecurseId { get; set; }
        public TravelyModule Module { get; set; }
        public string Message { get; set; }
        [JsonIgnore]
        public IEnumerable<long> UserIds { get; set; }
    }
}
