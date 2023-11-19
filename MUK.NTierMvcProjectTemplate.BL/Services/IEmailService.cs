using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUK.NTierMvcProjectTemplate.BL.Services
{
	public interface IEmailService
	{
		void SendMail(string reciverMailAddress, string subject, string mailBody);
	}
}
