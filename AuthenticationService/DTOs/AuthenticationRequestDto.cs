using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationService.DTOs
{
    public class AuthenticationRequestDto
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
