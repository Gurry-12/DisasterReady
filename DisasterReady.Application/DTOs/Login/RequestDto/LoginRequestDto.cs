using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterReady.Application.DTOs.Login.RequestDto
{
    public class LoginRequestDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        // Optional: You can add properties for two-factor authentication or remember me functionality
        //public bool RememberMe { get; set; } = false;
        //// Optional: Add a property for the device or IP address if needed
        //public string DeviceInfo { get; set; } = string.Empty;
    }
}
