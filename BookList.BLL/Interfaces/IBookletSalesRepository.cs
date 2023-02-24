using Booklets.BLL.Repositories;
using Booklets.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booklets.BLL.Interfaces
{
    public interface IBookletSalesRepository 
    {

        int Add(BookletSales model);


        int Edit(BookletSales model);


        List<BookletSales> GetAll();


        List<BookletSales> BrowseBooklet();



        BookletSales GetOne(int id);


        int Delete(BookletSales model);
    }
}
