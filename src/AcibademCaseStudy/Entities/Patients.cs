using System;
using System.Collections.Generic;

namespace AcibademCaseStudy.Entities
{
    public partial class Patients
    {
        public Patients()
        {
            Appointments = new HashSet<Appointments>();
        }

        public int PatientsId { get; set; }
        public string FullName { get; set; }
        public string PhoneNo { get; set; }

        public virtual ICollection<Appointments> Appointments { get; set; }
    }
}
