using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescribingSystem.Service
{
   public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
    
}
