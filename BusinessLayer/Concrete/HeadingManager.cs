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

        public List<Heading> GetList()
        {
            return _headinDal.List();
        }
    }
}
