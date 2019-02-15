using BussinessLogic.Service;
using BussinessLogic.Service.Master;
using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Bootcamp.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ItemController : ApiController
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        // GET: api/Item
        public IEnumerable<Item> Get()
        {
            return _itemService.Get();
        }

        // GET: api/Item/5
        
        public Item Get(int id)
        {
            var get = _itemService.Get(id);
            return get;
        }

        // POST: api/Item
        [HttpPost]
        public void Post(ItemParam itemParam)
        {
            _itemService.Insert(itemParam);
        }

        // PUT: api/Item/5
        public void Put(int id, ItemParam itemParam)
        {
            _itemService.Update(id, itemParam);
        }

        // DELETE: api/Item/5
        public void Delete(int id)
        {
            _itemService.Delete(id);
        }
    }
}
