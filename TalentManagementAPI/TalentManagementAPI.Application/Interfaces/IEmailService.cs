using System.Threading.Tasks;
using TalentManagementAPI.Application.DTOs.Email;

namespace TalentManagementAPI.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}