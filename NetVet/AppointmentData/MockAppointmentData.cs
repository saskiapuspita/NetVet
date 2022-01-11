using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetVet.Models;

namespace NetVet.AppointmentData
{
    public class MockAppointmentData : IAppointmentData
    {
        private List<Appointment> appointments = new List<Appointment>()
        {
            new Appointment()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                PetName = "Buddy",
                OwnersName = "Saskia Amalia P",
                ContactDetail = "081332042866"
            },
            new Appointment()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                PetName = "Angela",
                OwnersName = "Puspita Dewi",
                ContactDetail = "081332042271"
            }
        };

        public Appointment AddAppointment(Appointment appointment)
        {
            appointment.Id = Guid.NewGuid();
            appointments.Add(appointment);
            return appointment;
        }

        public void DeleteAppointment(Appointment appointment)
        {
            appointments.Remove(appointment);
        }

        public Appointment EditAppointment(Appointment appointment)
        {
            var existingAppointment = GetAppointment(appointment.Id);
            existingAppointment.Date = appointment.Date;
            existingAppointment.PetName = appointment.PetName;
            existingAppointment.OwnersName = appointment.OwnersName;
            existingAppointment.ContactDetail = appointment.ContactDetail;
            return existingAppointment;
        }

        public Appointment GetAppointment(Guid id)
        {
            return appointments.SingleOrDefault(x => x.Id == id);
        }

        public List<Appointment> GetAppointments()
        {
            return appointments;
        }

        public Task<IEnumerable<Appointment>> Search(string PetName)
        {
            throw new NotImplementedException();
        }
    }
}
