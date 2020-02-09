using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureChatApp.Repository
{
    public interface IChatRepo
    {
        IList<Message> GetAll();
        Message Get(Guid id);
        Message Store(Message customer);
    }
}
