using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Mobile.Services.Contracts
{
    public interface IMailService
    {
        void Send( string subject, string body, string to, string from = null);
    }
}
