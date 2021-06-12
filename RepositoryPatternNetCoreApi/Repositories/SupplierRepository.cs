using ApiDbContext.Data;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternNet5Api.Interfaces;
using RepositoryPatternNet5Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPatternNet5Api.Repositories
{
	public class SupplierRepository : ISupplierRepository
	{
		private readonly ApiContext _context;

		public SupplierRepository(ApiContext context)
		{
			_context = context;
		}

		public async Task DeleteSupplier(Guid id)
		{
			try
			{
				var supplier = await _context.Supplier.FindAsync(id);
				if (supplier == null)
				{
					return;
				}

				_context.Supplier.Remove(supplier);
				await _context.SaveChangesAsync();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<IEnumerable<Supplier>> GetSupplier()
		{
			try
			{
				return await _context.Supplier.ToListAsync();
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<Supplier> GetSupplierById(Guid id)
		{
			try
			{
				return await _context.Supplier.FindAsync(id);
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<Supplier> PostSupplier(Supplier supplier)
		{
			try
			{
				_context.Supplier.Add(supplier);
				await _context.SaveChangesAsync();
				return supplier;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<Supplier> PutSupplier(Guid id, Supplier supplier)
		{
			try
			{
				_context.Entry(supplier).State = EntityState.Modified;
				await _context.SaveChangesAsync();
				return supplier;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public bool SupplierExists(Guid id)
		{
			try
			{
				return _context.Supplier.Any(e => e.Id == id);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
