using System.Threading.Tasks;
using static Pikos.Models.DTOs.AccountDtos;
using static Pikos.Models.DTOs.SignInDtos;
using static Pikos.Models.DTOs.SignUpDtos;

namespace Pikos.BLL.Interfaces
{
    public interface IAccountService
    {
        Task<SignInResponse> SignIn(SignInRequest model, string ipAdress);
        Task<bool> SignUp(SignUpRequest model);
        Task<SignInResponse> RefreshToken(TokenModel model);
        Task<bool> RevokeToken(TokenModel model);
    }
}
