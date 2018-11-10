using MicroService.Thrift.RPC.Contract;
using System;
using Thrift.Protocol;
using Thrift.Transport;

namespace MicroService.Thrift.RPC.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TTransport transport = new TSocket("localhost", 8800))
            using (TProtocol protocol = new TBinaryProtocol(transport))
            using (var clientUser = new UserService.Client(protocol))
            {
                transport.Open();
                User u = clientUser.Get(1);
                Console.WriteLine($"{u.Id},{u.Name}");
                var list = clientUser.GetAll();
                list.ForEach(e =>
                {
                    Console.WriteLine($"{e.Id},{e.Name}");
                });
            }
        }
    }
}
