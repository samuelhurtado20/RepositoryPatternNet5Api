using RepositoryPatternNet5Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryPatternNet5Api.Interfaces
{
	public interface ISupplierRepository
	{
		Task<IEnumerable<Supplier>> GetSupplier();
		Task<Supplier> GetSupplierById(Guid id);
		Task<Supplier> PutSupplier(Guid id, Supplier supplier);
		Task<Supplier> PostSupplier(Supplier supplier);
		Task DeleteSupplier(Guid id);
		bool SupplierExists(Guid id);
	}
}
