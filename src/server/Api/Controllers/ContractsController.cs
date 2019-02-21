using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EfCore.Models;
using HoneySheet.Api.Dto;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly HoneySheetContext _context;

        public ContractsController(HoneySheetContext context)
        {
            _context = context;
        }

        // GET: api/Contracts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contract>>> GetContract()
        {
            return await _context.Contract.ToListAsync();
        }

        /// <summary>
        /// 根据合同条件查询合同列表，并返回合同名称和合同编号
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>返回合同名称和合同编号</returns>
        // GET: api/Contracts/simple
        [HttpPost("name")]
        public async Task<ActionResult<IEnumerable<ContractNameOutput>>> QueryContractsNames([FromBody]StringInput input)
        {
            var query = _context.Contract.AsQueryable();
            if (input != null)
            {
                if (!string.IsNullOrEmpty(input.Value))
                    query = query.Where(o => o.ContractCode.Contains(input.Value) || 
                                             o.ContractName.Contains(input.Value));
            }

            return await query.Select<Contract, ContractNameOutput>(o =>
                   new ContractNameOutput()
                   {
                       ContractId = o.ContractId,
                       ContractCode = o.ContractCode,
                       ContractName = o.ContractName
                   })
                   .ToListAsync();
        }

        // GET: api/Contracts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contract>> GetContract(int id)
        {
            var contract = await _context.Contract.FindAsync(id);

            if (contract == null)
            {
                return NotFound();
            }

            return contract;
        }

        // PUT: api/Contracts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContract(int id, Contract contract)
        {
            if (id != contract.ContractId)
            {
                return BadRequest();
            }

            _context.Entry(contract).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Contracts
        [HttpPost]
        public async Task<ActionResult<Contract>> PostContract(Contract contract)
        {
            _context.Contract.Add(contract);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContract", new { id = contract.ContractId }, contract);
        }

        // DELETE: api/Contracts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contract>> DeleteContract(int id)
        {
            var contract = await _context.Contract.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }

            _context.Contract.Remove(contract);
            await _context.SaveChangesAsync();

            return contract;
        }

        private bool ContractExists(int id)
        {
            return _context.Contract.Any(e => e.ContractId == id);
        }
    }
}
