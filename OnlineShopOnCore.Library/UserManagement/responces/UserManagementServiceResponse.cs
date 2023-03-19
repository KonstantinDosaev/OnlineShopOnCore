using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopOnCore.Library.UserManagement.responces
{
    public class UserManagementServiceResponse<T>
    {
        public T Payload { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
