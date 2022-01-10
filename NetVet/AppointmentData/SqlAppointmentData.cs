using System;
using System.Collections.Generic;
using System.Linq;
using NetVet.Models;

namespace NetVet.AppointmentData
{
    public class SqlAppointmentData : IAppointmentData
    {
        private AppointmentDbContext _appointmentContext;

        public SqlAppointmentData(AppointmentDbContext appointmentDbContext)
        {
            _appointmentContext = appointmentDbContext;
        }

        public Appointment AddAppointment(Appointment appointment)
        {
            appointment.Id = Guid.NewGuid();
            _appointmentContext.Appointments.Add(appointment);
            _appointmentContext.SaveChanges();
            return appointment;
        }

        public void DeleteAppointment(Appointment appointment)
        {
            _appointmentContext.Appointments.Remove(appointment);
            _appointmentContext.SaveChanges();
        }

        public Appointment EditAppointment(Appointment appointment)
        {
            var existingAppointment = _appointmentContext.Appointments.Find(appointment.Id);

            if (existingAppointment != null)
            {
                existingAppointment.Date = appointment.Date;
                existingAppointment.PetName = appointment.PetName;
                existingAppointment.OwnersName = appointment.OwnersName;
                existingAppointment.ContactDetail = appointment.ContactDetail;
                _appointmentContext.Appointments.Update(existingAppointment);
                _appointmentContext.SaveChanges();
            }
            return appointment;
        }

        public Appointment GetAppointment(Guid id)
        {
            var appointment = _appointmentContext.Appointments.Find(id);
            return appointment;
        }

        public List<Appointment> GetAppointments()
        {
            return _appointmentContext.Appointments.ToList();
        }
    }
}
