using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IS415ProjectOne.Models
{
    /// <summary>
    /// May not actually be used.... 
    /// </summary>
    public class Appointment
    {
        // no key needed if we are not doing database stuff...
        //[Key]
        //[Required(AllowEmptyStrings = false)]
        //public int AppointmentId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public DateTime StartTime { get; set; }
        [Required(AllowEmptyStrings = false)]
        public DateTime EndTime { get; set; }
        /// <summary>
        /// The amount of people that can be allowed in an appointment
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public int TotalSlots { get; set; }

        //THIS MIGHT BE A GOOD WAY TO DO IT, BUT IT DIDN'T SEEM SUPER GOOD YET TO PUT THE GROUPS IN THE 
        //APPOINTMENT CLASS
        //[Required]
        //public List<Group> Groups { get; } = new List<Group>();

        //public void AddGroup(string groupName, int size, string email, string phoneNumber)
        //{
        //    Groups.Add(new Group
        //    {
        //        GroupName = groupName,
        //        Size = size,
        //        Email = email,
        //        PhoneNumber = phoneNumber
        //    });
        //}
    }
}
