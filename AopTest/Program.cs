using AspectCore.DynamicProxy;
using System;

namespace AopTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ProxyGeneratorBuilder proxyGeneratorBuilder = new ProxyGeneratorBuilder();
            using (IProxyGenerator proxyGenerator = proxyGeneratorBuilder.Build())
            {
                Person p = proxyGenerator.CreateClassProxy<Person>();
                Console.WriteLine(p.GetType());
                p.Say("cys");
                p.Say("cys");
                //Console.WriteLine(p.HelloAsync("yzk").Result);
                //Console.WriteLine(p.Add(1, 2));
            }
            Console.ReadKey();

        }
    }
}
