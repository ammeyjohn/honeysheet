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
    [Route("api/contracts")]
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

        /// <summary>
        /// 根据条件查询合同列表数量
        /// </summary>
        /// <param name="condition">合同查询条件对象</param>
        /// <returns>返回合同对象列表数量</returns>
        [HttpPost("query/count")]
        public async Task<ActionResult<int>> QueryContractCountByCondition([FromBody]ContractCondition condition)
        {
            var query = _context.Contract.AsQueryable();
            query = query.BuildQuery(condition);
            return await query.CountAsync();
        }

        /// <summary>
        /// 根据条件查询合同列表
        /// </summary>
        /// <param name="condition">合同查询条件对象</param>
        /// <param name="pageIndex">分页页码</param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns>返回合同对象列表</returns>
        [HttpPost("query/{pageIndex}")]
        public async Task<ActionResult<IEnumerable<Contract>>> QueryContractsByCondition([FromBody]ContractCondition condition, int pageIndex, int pageSize = 20)
        {
            var query = _context.Contract
                                .Include(o => o.Department)
                                .AsQueryable();
            query = query.BuildQuery(condition)
                         .Skip((pageIndex - 1) * pageSize)
                         .Take(pageSize)
                         .OrderBy(o => o.ContractId);
            var list = await query.ToListAsync();
            return list;
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

    public static class ContractExtension
    {
        /// <summary>
        /// 构建查询条件
        /// </summary>
        /// <param name="querier"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IQueryable<Contract> BuildQuery(this IQueryable<Contract> query, ContractCondition condition)
        {
            if (condition != null)
            {
                if (condition.ContractIds != null && condition.ContractIds.Length > 0)
                    query = query.Where(o => condition.ContractIds.Contains(o.ContractId));
                if (!string.IsNullOrEmpty(condition.ContractName))
                    query = query.Where(o => o.ContractName.Contains(condition.ContractName));
                if (!string.IsNullOrEmpty(condition.ContractName))
                    query = query.Where(o => o.ContractName.Contains(condition.ContractName));
                if (condition.DateOfSign0.HasValue)
                    query = query.Where(o => o.DateOfSign >= condition.DateOfSign0);
                if (condition.DateOfSign1.HasValue)
                    query = query.Where(o => o.DateOfSign < condition.DateOfSign1);
                if (condition.ContractAmount0.HasValue)
                    query = query.Where(o => o.ContractAmount >= condition.ContractAmount0);
                if (condition.ContractAmount1.HasValue)
                    query = query.Where(o => o.ContractAmount < condition.ContractAmount1);
                if (condition.Salesmans != null && condition.Salesmans.Length > 0)
                    query = query.Where(o => condition.Salesmans.Contains(o.Salesman));
                if (condition.DepartmentIds != null && condition.DepartmentIds.Length > 0)
                    query = query.Where(o => condition.DepartmentIds.Contains(o.DepartmentId));
            }
            return query;
        }
    }
}
