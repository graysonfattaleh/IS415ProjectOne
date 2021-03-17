using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS415ProjectOne.Models.ViewModels
{
    public class AppointmentListViewModel
    {
        public IEnumerable<Group> Groups { get; set; }
        //public PagingInfo PagingInfo { get; set; }
        /// <summary>
        /// This variable stores the currently selected category for the view to use.
        /// </summary>
        public AppointmentPagingInfo PagingInfo { get; set; } 

        /// <summary>
        /// This is the list of all the available schedulable appointments. 
        /// Logic will have to be written to put the right ones in the start times etc...
        /// </summary>
        public List<Appointment> SchedulableAppointments { get; set; }

    }
}
