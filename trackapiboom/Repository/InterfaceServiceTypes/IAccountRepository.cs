using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using trackapiboom.DTOs;

namespace trackapiboom.Repository.InterfaceServiceTypes
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignupAsync(SignupDTO signupDTO);

        Task<string> LoginAsync(LoginDTO loginDTO);
    }
}
