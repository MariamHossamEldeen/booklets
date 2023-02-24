using Booklets.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booklets.BLL.Interfaces
{
    public interface IBookletRepository 
    {
        int Add(Booklet model);


        int Edit(Booklet model);


        List<Booklet> GetAll();


        List<Booklet> BrowseBooklet();



        Booklet GetOne(int id);


        int Delete(Booklet model);
    }
}
