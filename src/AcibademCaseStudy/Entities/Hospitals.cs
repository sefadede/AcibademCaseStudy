using System;
using System.Collections.Generic;

namespace AcibademCaseStudy.Entities
{
    public partial class Hospitals
    {
        public Hospitals()
        {
            Appointments = new HashSet<Appointments>();
        }

        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Appointments> Appointments { get; set; }
    }
}
