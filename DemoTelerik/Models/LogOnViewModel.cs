using DemoTelerik.Resources;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Xml.Linq;

namespace DemoTelerik.Models
{
	public class LogOnViewModel
	{
		[Required]
		[Display(ResourceType = typeof(Resource_HIJKLM), Name = "LogOnModel_UserName")]
		public string UserName { get; set; }

		[DataType(DataType.Password)]
		[Display(ResourceType = typeof(Resource_HIJKLM), Name = "LogOnModel_Password")]
		public string Password { get; set; }

		[Display(ResourceType = typeof(Resource_HIJKLM), Name = "LogOnModel_RememberMe")]
		public bool RememberMe { get; set; }

		public String ReturnUrl { get; set; }
		public int tz { get; set; }

		public int? Opcion { get; set; }

		public int IdInstalacion { get; set; }
	}
}
