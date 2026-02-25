using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Services
{
    public interface IJwtService
    {
        string GenerateToken(int userId, string name, string role);
    }
}