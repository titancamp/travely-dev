using System.Collections.Generic;

namespace TourManager.Service.Model.PropertyManager
{
    public class PropertyResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte Stars { get; set; }

        public string Address { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public string ContactName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }

        public IEnumerable<PropertyAttachmentModel> Attachments { get; set; } = new List<PropertyAttachmentModel>();
    }
}
