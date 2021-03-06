using System;

namespace TourManager.Repository.Entities
{
    public class BookingServiceEntity
    {
        public int ServiceId { get; set; }

        public string ServiceName { get; set; }

        public DateTime? BookingDate { get; set; }

        public TimeSpan? BookingTime { get; set; }

        public int NumberOfGuests { get; set; }

        public string Notes { get; set; }
    }
}