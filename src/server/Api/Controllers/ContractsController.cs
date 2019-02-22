using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HoneySheet.Model;
using HoneySheet.Model.Dto;

namespace HoneySheet.Api.Controllers
{
    [RoutePrefix("api/contract")]
    public class ContractsController : ApiController
    {
        private HoneySheetContext _context = new HoneySheetContext();

        // GET: api/Contracts
        public IQueryable<Contract> GetContracts()
        {
            return _context.Contracts;
        }

        // GET: api/Contracts/5
        [ResponseType(typeof(Contract))]
        public async Task<IHttpActionResult> GetContract(int id)
        {
            Contract contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }

            return Ok(contract);
        }

        /// <summary>
        /// 根据合同条件查询合同列表，并返回合同名称和合同编号
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>返回合同名称和合同编号</returns>
        [HttpPost]
        [Route("name")]
        public async Task<IHttpActionResult> QueryContractsNames([FromBody]StringInput input)
        {
            var query = _context.Contracts.AsQueryable();
            if (input != null)
            {
                if (!string.IsNullOrEmpty(input.Value))
                    query = query.Where(o => o.ContractCode.Contains(input.Value) ||
                                             o.ContractName.Contains(input.Value));
            }

            var result = await query.Select<Contract, ContractNameOutput>(o =>
                   new ContractNameOutput()
                   {
                       ContractId = o.ContractId,
                       ContractCode = o.ContractCode,
                       ContractName = o.ContractName
                   })
                   .ToListAsync();

            return Ok(result);
        }

        /// <summary>
        /// 根据条件查询合同列表数量
        /// </summary>
        /// <param name="condition">合同查询条件对象</param>
        /// <returns>返回合同对象列表数量</returns>
        [HttpPost]
        [Route("query/count")]
        public async Task<IHttpActionResult> QueryContractCountByCondition([FromBody]ContractCondition condition)
        {
            var query = _context.Contracts.AsQueryable();
            query = query.BuildQuery(condition);
            var count = await query.CountAsync();
            return Ok(count);
        }

        /// <summary>
        /// 根据条件查询合同列表
        /// </summary>
        /// <param name="condition">合同查询条件对象</param>
        /// <param name="pageIndex">分页页码</param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns>返回合同对象列表</returns>
        [HttpPost]
        [Route("query/{pageIndex}")]
        public async Task<IHttpActionResult> QueryContractsByCondition([FromBody]ContractCondition condition, int pageIndex, int pageSize = 20)
        {
            var query = _context.Contracts
                                .AsQueryable();
            query = query.BuildQuery(condition)
                         .Skip((pageIndex - 1) * pageSize)
                         .Take(pageSize)
                         .OrderBy(o => o.ContractId);            
            var result = await query.ToListAsync();
            return Ok(result);
        }

        // PUT: api/Contracts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContract(int id, Contract contract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Contracts
        [ResponseType(typeof(Contract))]
        public async Task<IHttpActionResult> PostContract(Contract contract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = contract.ContractId }, contract);
        }

        // DELETE: api/Contracts/5
        [ResponseType(typeof(Contract))]
        public async Task<IHttpActionResult> DeleteContract(int id)
        {
            Contract contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }

            _context.Contracts.Remove(contract);
            await _context.SaveChangesAsync();

            return Ok(contract);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContractExists(int id)
        {
            return _context.Contracts.Count(e => e.ContractId == id) > 0;
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