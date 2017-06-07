using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.UI.WebControls;
using Models.Repository;
using Models.Models;

namespace TipsLel.Controllers
{
    public class GetDailyTipController : ApiController
    {
        private ITipsRepository _tipsRepository;

        // GET api/<controller>
        public List<TipsEveryDay> Get()
        {
            _tipsRepository = new TipsRepository();
            var lista = _tipsRepository.GetAllTips();
            return lista;
        }

        // GET api/<controller>/5
        public JsonResult<List<TipsEveryDay>> Get(int id)
        {
            _tipsRepository = new TipsRepository();
            var valor = _tipsRepository.GetTipById(id);
            
            return Json(valor);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}