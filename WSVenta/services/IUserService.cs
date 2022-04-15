using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVenta.Models.Response;
using WSVenta.Models.ViewModels;

namespace WSVenta.services
{
   public interface IUserService
    {
        UserResponse Auth(AuthRequest model);

    }


}
