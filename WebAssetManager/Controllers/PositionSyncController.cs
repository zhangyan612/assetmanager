using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAssetManager.Models;

namespace WebAssetManager.Controllers
{
    public class PositionSyncController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public Position GetPositionById(int id)
        {
            var position = db.Positions.Find(id);
            return position;
        }

        [HttpGet]
        public IEnumerable<dynamic> GetAllPositions(string userId)
        {
            var positions = db.Positions.Select(a => new
            {
                Id = a.PositionId,
                StockName = a.StockName,
                Symbol = a.Symbol,
                HoldingAmount = a.HoldingAmount,
                SellableAmount = a.SellableAmount,
                CostPrice = a.CostPrice,
                CurrentPrice = a.CurrentPrice,
                Account = a.AccountId,
                Strategy = a.StrategyId
            }).AsEnumerable();

            return positions;
        }

        [HttpPost]
        public IHttpActionResult Add(Position position)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Positions.Add(position);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.OK);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, int HoldingAmount, int SellableAmount, decimal CurrentPrice)
        {
            var position = db.Positions.Find(id);
            if (position == null)
            {
                return BadRequest();
            }
            try
            {
                position.HoldingAmount = HoldingAmount;
                position.SellableAmount = SellableAmount;
                position.CurrentPrice = CurrentPrice;
                db.Entry(position).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch(DbUpdateConcurrencyException)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.OK);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var position = db.Positions.Find(id);

            if (position == null)
            {
                return NotFound();
            }

            db.Positions.Remove(position);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
