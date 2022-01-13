using NetVet.Models;
using System.Threading.Tasks;

namespace NetVet.AppointmentData
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
