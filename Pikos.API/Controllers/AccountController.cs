using Microsoft.AspNetCore.Mvc;
using static Pikos.Models.Constants.PikosConstants;
using static Pikos.Helpers.ApiResponse;
using static Pikos.Models.DTOs.SignInDtos;
using static Pikos.Models.DTOs.SignUpDtos;
using Pikos.BLL.Interfaces;
using System.Threading.Tasks;
using static Pikos.Models.DTOs.AccountDtos;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Pikos.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [Route("signin")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(SignInRequest model)
        {
            var result = await accountService.SignIn(model, GetIpAddress());
            if (result != null)
            {
                SetTokenCookie(result.RefreshToken);
                return Ok(new SuccessResponse
                {
                    Status = ResponseStatus.SUCCESS,
                    Data = result
                });
            }

            return BadRequest(new ErrorResponse { Status = ResponseStatus.FAILED, Message = "Invalid credentials" });
        }

        [Route("signup")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(SignUpRequest model)
        {
            var result = await accountService.SignUp(model);
            if (result)
            {
                return Ok(new SuccessResponse { Status = ResponseStatus.SUCCESS, Data = model });
            }

            return BadRequest();
        }

        [Route("refresh-token")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var result = await accountService.RefreshToken(new TokenModel { Token = refreshToken, IpAddress = GetIpAddress() });
            if (result != null)
            {
                SetTokenCookie(refreshToken);
                return Ok(new SuccessResponse
                {
                    Status = ResponseStatus.SUCCESS,
                    Data = result
                });
            }
            return Unauthorized(new ErrorResponse { Status = ResponseStatus.FAILED, Message = "Invalid token" });
        }

        [HttpPost]
        [Route("revoke-token")]
        public async Task<IActionResult> RevokeToken(TokenModel model)
        {
            // accept token from request body or cookie
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });

            var result = await accountService.RevokeToken(model);
            if (result)
            {
                return Ok(new SuccessResponse { Status = ResponseStatus.SUCCESS });
            }

            return NotFound(new ErrorResponse { Status = ResponseStatus.FAILED, Message = "Failed to revoke the token" });
        }
    }
}
