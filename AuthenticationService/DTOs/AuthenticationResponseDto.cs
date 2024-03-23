using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationService.DTOs
{
    public class AuthenticationResponseDto
    {
        public string? UserName { get; set; }
        public string? Message { get; set; }
        public string? Token { get; set; }
        public int tokenLifelemit { get; set; }
    }
}
