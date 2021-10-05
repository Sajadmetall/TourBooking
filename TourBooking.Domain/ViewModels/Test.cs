using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBooking.Data.Entities;

namespace TourBooking.Domain.ViewModels
{
    public class Test
    {
        public Guid? BookingId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Nullable<DateTime> CreateDate { get; set; }
        [Required]
        public Nullable<Int16> Status { get; set; }
        public string Price { get; set; }
        public Nullable<Int16> Currency { get; set; }
        public List<PartyLeaderViewModel> PartyLeaders { get; set; }
    }
}
