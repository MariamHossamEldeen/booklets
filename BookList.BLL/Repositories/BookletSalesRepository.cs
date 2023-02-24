
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
    public class BookletSalesRepository :  IBookletSalesRepository
    {
        private readonly MVCAppDBContexts _db;
        public BookletSalesRepository(MVCAppDBContexts db)
        {
            _db = db;
        }

        public int Add(BookletSales model)
        {
            _db.BookletSales.Add(model);
            return _db.SaveChanges();
        }

        public int Edit(BookletSales model)
        {

            var booklet = GetOne(model.ID);

            booklet.Date = model.Date;
            booklet.BookletID = model.BookletID;
            booklet.CustomerID = model.CustomerID;
            booklet.CustomerName = model.CustomerName;
            return _db.SaveChanges();
        }

        public List<BookletSales> GetAll()
        {
            return _db.BookletSales.ToList();
        }

        public List<BookletSales> BrowseBooklet()
        {
            return _db.BookletSales.Select(z => new BookletSales
            {
                ID = z.ID,
                Date = z.Date,
                BookletID = z.BookletID,
                CustomerID = z.CustomerID,
                CustomerName = z.CustomerName

            }).ToList();
        }

        public BookletSales GetOne(int id)
        {
            return _db.BookletSales.Find(id);
        }

        public int Delete(BookletSales model)
        {

            var bookletSales = GetOne(model.ID);

            _db.BookletSales.Remove(bookletSales);
            return _db.SaveChanges();
        }

    }
}
