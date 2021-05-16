using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskService.Entities.Models.AuthModels
{
    public class LoginResponse
    {
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
