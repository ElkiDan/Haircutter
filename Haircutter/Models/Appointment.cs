using System;
using System.Collections.Generic;

namespace Haircutter.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public Nullable<int> customerId { get; set; }
        public Nullable<System.DateTime> appointmentDate { get; set; }
        public string comment { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
