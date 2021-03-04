using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AcibademCaseStudy.Entities;
using AcibademCaseStudy.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcibademCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private IRepository<Appointments> _repository;
        //Automapper

        public AppointmentController(IRepository<Appointments> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult AddAppointment([FromBody] Appointments appointments)
        {
            try
            {
                _repository.Create(appointments);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ErrorMessage = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAppointments(int hospitalId, int patientId, DateTime date)
        {
            try
            {
                var appointments = _repository.Table
                                              .Include(x => x.Hospital)
                                              .Include(x => x.Patient)
                                              .Where(x => x.HospitalId == hospitalId && x.PatientId == patientId && x.Date_.Value == date);

                return Ok(appointments.Select(x => new
                {
                    AppointmentId = x.AppointmentId,
                    //HospitalId = x.HospitalId,
                    //PatientId = x.PatientId,
                    HospitalName = x.Hospital.HospitalName,
                    HospitalAddress = x.Hospital.Address,
                    PatientName = x.Patient.FullName,
                    PatientPhone = x.Patient.PhoneNo,
                    Date = x.Date_
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ErrorMessage = ex.Message });
            }
        }
    }
}
