using NetVet.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetVet.AppointmentData
{
    public interface IAppointmentData
    {
        Task<PagedList<Appointment>> Pagination(PaginationParams paginationParams);

        Task<IEnumerable<Appointment>> Search(string searchString, DateTime dateTime);

        List<Appointment> GetAppointments();

        Appointment GetAppointment(Guid id);

        Appointment AddAppointment(Appointment appointment);

        void DeleteAppointment(Appointment appointment);

        Appointment EditAppointment(Appointment appointment);
    }
}
