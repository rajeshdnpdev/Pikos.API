using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikos.Models.DTOs
{
    public static class SignInDtos
    {
        public class SignInRequest
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public class SignInResponse
        {
            public string UserId { get; set; }
            public string UserName { get; set; }
            public string Token { get; set; }
            public string RefreshToken { get; set; }
        }
    }
}
