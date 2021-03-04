using System;
using System.Collections.Generic;

namespace AcibademCaseStudy.Entities
{
    public partial class Appointments
    {
        public int AppointmentId { get; set; }
        public int? PatientId { get; set; }
        public int? HospitalId { get; set; }
        public DateTime? Date_ { get; set; }

        public virtual Hospitals Hospital { get; set; }
        public virtual Patients Patient { get; set; }
    }
}
