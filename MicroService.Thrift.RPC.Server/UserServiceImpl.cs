using MicroService.Thrift.RPC.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Thrift.RPC.Server
{
    public class UserServiceImpl : UserService.Iface
    {
        public User Get(int id)
        {
            User u = new User();
            u.Id = id;
            u.Name = "用户" + id;
            u.Age = 6;
            return u;
        }

        public List<User> GetAll()
        {
            List<User> list = new List<User>();
            list.Add(new User { Id = 1, Name = "yzk", Age = 18, Remark = "hello" });
            list.Add(new User { Id = 2, Name = "rupeng", Age = 6 });
            return list;
        }

        public SaveResult Save(User user)
        {
            Console.WriteLine($"保存用户，{user.Id}"); return SaveResult.SUCCESS;
        }
    }
}
