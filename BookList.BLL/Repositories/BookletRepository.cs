using Booklets.BLL.Interfaces;
using Booklets.DAL.Contexts;
using Booklets.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booklets.BLL.Repositories
{
    public class BookletRepository : IBookletRepository
    {


        private readonly MVCAppDBContexts _db;
        public BookletRepository(MVCAppDBContexts db)
        {
            _db = db;
        }

        public int Add(Booklet model)
        {
            _db.Booklets.Add(model);
            return _db.SaveChanges();
        }

        public int Edit(Booklet model)
        {
            
            var booklet = GetOne(model.BookletID);

            booklet.Activity = model.Activity;
            booklet.Status = model.Status;
            return _db.SaveChanges();
        }

        public List<Booklet> GetAll()
        {
            return _db.Booklets.ToList();
        }

        public List<Booklet> BrowseBooklet()
        {
            return _db.Booklets.Select(z => new Booklet
            {
                BookletID = z.BookletID,
                Activity = z.Activity

            }).ToList();
        }

        public Booklet GetOne(int id)
        {
            return _db.Booklets.Find(id);
        }

        public int Delete(Booklet model)
        {

            var booklet = GetOne(model.BookletID);

            _db.Booklets.Remove(booklet);
            return _db.SaveChanges();
        }

     
    }
}
