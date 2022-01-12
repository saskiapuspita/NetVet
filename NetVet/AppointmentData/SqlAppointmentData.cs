using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            appointment.CreatedAt = DateTime.Today;
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
                existingAppointment.Date = Convert.ToDateTime(appointment.Date.ToString("MM/dd/yyyy"));
                existingAppointment.PetName = appointment.PetName;
                existingAppointment.OwnersName = appointment.OwnersName;
                existingAppointment.ContactDetail = appointment.ContactDetail;
                existingAppointment.Email = appointment.Email;

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

        public Task<PagedList<Appointment>> Pagination(PaginationParams paginationParams)
        {
            return Task.FromResult(PagedList<Appointment>.GetPagedList(FindAll().OrderBy(s => s.Id), paginationParams.pageNumber, paginationParams.pageSize));
        }

        public async Task<IEnumerable<Appointment>> Search(string PetName)
        {
            IQueryable<Appointment> query = _appointmentContext.Appointments;

            if (!string.IsNullOrEmpty(PetName))
            {
                query = query.Where(ap => ap.PetName.Contains(PetName));
            }

            return await query.ToListAsync();
        }

        public IQueryable<Appointment> FindAll()
        {
            return _appointmentContext.Set<Appointment>().AsNoTracking();
        }
    }
}
