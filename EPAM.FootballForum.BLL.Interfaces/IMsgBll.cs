using EPAM.FootballForum.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.FootballForum.BLL.Interfaces
{
    public interface IMsgBll
    {
        bool AddMessage(Message newMessage);
    }
}
