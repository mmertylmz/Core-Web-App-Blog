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
    public class Message2Manager:IMessage2Service
    {
        IMessageDal2 _messageDal2;

        public Message2Manager(IMessageDal2 messageDal2)
        {
            _messageDal2 = messageDal2;
        }

        public List<Message2> GetInboxListByWriter(int id)
        {
            return _messageDal2.GetListWithMessageByWriter(id); 
        }

        public List<Message2> GetList()
        {
            return _messageDal2.GetAllList();
        }

        public void TAdd(Message2 t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Message2 t)
        {
            throw new NotImplementedException();
        }

        public Message2 TGetByID(int id)
        {
            return _messageDal2.GetByID(id);
        }

        public void TUpdate(Message2 t)
        {
            throw new NotImplementedException();
        }
    }
}
