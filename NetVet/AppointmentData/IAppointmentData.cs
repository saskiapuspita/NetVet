using NetVet.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetVet.AppointmentData
{
    public interface IAppointmentData
    {
        Task<IEnumerable<Appointment>> Search(string PetName);

        List<Appointment> GetAppointments();

        Appointment GetAppointment(Guid id);

        Appointment AddAppointment(Appointment appointment);

        void DeleteAppointment(Appointment appointment);

        Appointment EditAppointment(Appointment appointment);
    }
}
