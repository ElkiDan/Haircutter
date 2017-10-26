using System;
using System.Collections.Generic;

namespace Haircutter.Models
{
    public partial class Customer
    {
        public Customer()
        {
            this.Appointments = new List<Appointment>();
        }

        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string color { get; set; }
        public bool isSub { get; set; }
        public Nullable<int> appointmentsCount { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
