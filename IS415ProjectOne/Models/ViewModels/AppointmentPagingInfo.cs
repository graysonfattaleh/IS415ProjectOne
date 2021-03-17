using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS415ProjectOne.Models.ViewModels
{
    public class AppointmentPagingInfo
    {
        public int TotalNumItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling(((decimal)TotalNumItems / ItemsPerPage));
    }
}
