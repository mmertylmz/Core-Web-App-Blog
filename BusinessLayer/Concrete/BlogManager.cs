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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void BlogAdd(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void BlogDelete(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void BlogUpdate(Blog blog)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public Blog GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetAllList();
        }
        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.GetAllList(x => x.BlogID.Equals(id));
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetAllList(x => x.WriterID.Equals(id));
        }

        public List<Blog> GetLastThreeBlog()
        {
            return _blogDal.GetAllList().TakeLast(3).ToList();
        }
    }
}
