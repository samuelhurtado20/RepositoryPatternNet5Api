using System;

namespace RepositoryPatternNet5Api.Models
{
	public class Supplier
	{
		public Guid Id { get; set; }

		public string Ruc { get; set; }

		public string Name { get; set; }

		public string Address { get; set; }

		public bool Enabled { get; set; }

		public string CreatedBy { get; set; }

		public DateTime CreatedAt { get; set; }
	}
}
