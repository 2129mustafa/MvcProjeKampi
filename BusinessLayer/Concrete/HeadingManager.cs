using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headinDal;

        public HeadingManager(IHeadingDal headinDal)
        {
            _headinDal = headinDal;
        }

        public Heading GetById(int id)
        {
            return _headinDal.Get(x => x.HeadingId == id);
        }

        public List<Heading> GetList()
        {
            return _headinDal.List();
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headinDal.List(x => x.WriterId == id);
        }

        public void HeadingAdd(Heading heading)
        {
            _headinDal.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
           
            _headinDal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headinDal.Update(heading);
        }
    }
}
