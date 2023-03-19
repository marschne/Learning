using System;
namespace MSC.Models
{
	public class User
	{
		public string? Anrede { get; set; }
		public string? Vorname { get; set; }
        public string? Nachname { get; set; }

		public string? Username { get; set; }
		public string? Password { get; set; }

		public User()
		{
		}
	}
}

