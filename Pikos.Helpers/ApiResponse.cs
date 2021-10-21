using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pikos.Models.Constants.PikosConstants;

namespace Pikos.Helpers
{
    public static class ApiResponse
    {
        public class SuccessResponse
        {
            public string Status { get; set; }
            public dynamic Data { get; set; }
        }

        public class ErrorResponse
        {
            public string Status { get; set; }
            public string Message { get; set; }
        }
    }
}
