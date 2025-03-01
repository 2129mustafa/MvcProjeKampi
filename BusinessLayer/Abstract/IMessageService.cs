﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string mail);
        List<Message> GetListSendbox(string mail);

        void MessageAdd(Message message);
        Message GetById(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);

        List<Message> GetInboxReadList(string mail);
        List<Message> GetInboxUnReadList(string mail);
    }
}
