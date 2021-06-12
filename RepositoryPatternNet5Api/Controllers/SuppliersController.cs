using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternNet5Api.Interfaces;
using RepositoryPatternNet5Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryPatternNet5Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierRepository _supplierRepository;

        public SuppliersController(ISupplierRepository repository)
        {
            _supplierRepository = repository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSupplier()
        {
			try
            {
                return Ok(await _supplierRepository.GetSupplier());
            }
			catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplierById(Guid id)
        {
			try
            {
                var supplier = await _supplierRepository.GetSupplierById(id);

                if (supplier == null)
                {
                    return NotFound();
                }

                return supplier;
            }
			catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="supplier"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(Guid id, Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return BadRequest();
            }

            try
            {
                supplier = await _supplierRepository.PutSupplier(id, supplier);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_supplierRepository.SupplierExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            return Ok(supplier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Supplier>> PostSupplier(Supplier supplier)
        {
            try
            {
                supplier = await _supplierRepository.PostSupplier(supplier);

                return CreatedAtAction("GetSupplier", new { id = supplier.Id }, supplier);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(Guid id)
        {
            try
            {
                if (_supplierRepository.SupplierExists(id))
                {
                    await _supplierRepository.DeleteSupplier(id);

                    return NoContent();
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
