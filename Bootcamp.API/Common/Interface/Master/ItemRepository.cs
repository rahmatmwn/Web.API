using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;

namespace Common.Interface.Master
{
    public class ItemRepository : IItemRepository
    {
        bool status = false;
        MyContext _context = new MyContext();
        Item item = new Item();
        public bool Delete(int? Id)
        {
            var result = 0;
            Item item = Get(Id);
            item.IsDelete = true;
            item.DeleteDate = DateTimeOffset.Now.ToLocalTime();
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Item> Get()
        {
            var get = _context.Items.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Item Get(int? Id)
        {
            var get = _context.Items.Where(x => x.IsDelete == false && x.Id == Id).SingleOrDefault();
            return get;
        }

        public bool Insert(ItemParam itemParam)
        {
            var supplier = _context.Suppliers.Find(itemParam.Supplier_Id);
            var result = 0;
            item.Name = itemParam.Name;
            item.Price = itemParam.Price;
            item.Stock = itemParam.Stock;
            item.Suppliers = supplier;
            item.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Items.Add(item);
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? Id, ItemParam itemParam)
        {
            var get = _context.Items.Find(Id);
            var supplier = _context.Suppliers.Find(itemParam.Supplier_Id);
            var result = 0;
            get.Name = itemParam.Name;
            get.Price = itemParam.Price;
            get.Stock = itemParam.Stock;
            get.Suppliers = supplier;
            get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = _context.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
