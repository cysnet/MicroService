using MicroService.Thrift.RPC.Contract;
using System;
using Thrift.Server;
using Thrift.Transport;

namespace MicroService.Thrift.RPC.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TServerTransport transport = new TServerSocket(8800);//监听8800端口
            var processor = new UserService.Processor(new UserServiceImpl());//设置实现类
            TServer server = new TThreadPoolServer(processor, transport);
            server.Serve();
        }
    }
}
