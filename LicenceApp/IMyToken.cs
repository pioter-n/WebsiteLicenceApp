using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LicenceApp
{
   public interface IMyToken
    {
        Task<bool> RequestPasswordToken(string User, string Pass);
    }
}
