using Polly;
using Polly.Timeout;
using System;
using System.Threading;

namespace PollyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ////policy捕获异常
            //Policy policy = Policy
            //    .Handle<ArgumentException>()
            //    .Fallback(() =>
            //    {
            //        Console.WriteLine("执行出错");
            //    });

            //policy.Execute(() =>
            //{
            //    Console.WriteLine("开始任务");
            //    throw new ArgumentException("Error");
            //    Console.WriteLine("完成任务");
            //});

            ////policy获取异常信息
            //policy = Policy
            //    .Handle<ArgumentException>()
            //    .Fallback(() =>
            //    {
            //        Console.WriteLine("执行出错");
            //    },
            //    ex =>
            //    {
            //        Console.WriteLine(ex);
            //    });

            //policy.Execute(() =>
            //{
            //    Console.WriteLine("开始任务");
            //    throw new ArgumentException("Error");
            //    Console.WriteLine("完成任务");
            //});

            ////policy返回值
            //Policy<string> policy1 = Policy<string>
            //    .Handle<Exception>()
            //    .Fallback(()=>
            //    {
            //        Console.WriteLine("执行出错");
            //        return "降级的值";
            //    });
            //string value = policy1.Execute(()=> {
            //    Console.WriteLine("开始任务");
            //    //throw new Exception("Error");
            //    Console.WriteLine("完成任务");
            //    return "正常的值";
            //});
            //Console.WriteLine("返回值："+value);

            ////重试
            //Policy policy = Policy
            //    .Handle<Exception>()
            //    .Retry(3);

            //policy.Execute(()=> {
            //    Console.WriteLine("开始执行");
            //    throw new Exception("Error");
            //});

            //Policy policy = Policy
            //    .Handle<Exception>()
            //    .CircuitBreaker(6, TimeSpan.FromSeconds(5));

            //while (true)
            //{

            //    try
            //    {
            //        policy.Execute(() =>
            //        {
            //            Console.WriteLine("开始任务");
            //            throw new Exception("Error");
            //        });
            //    }
            //    catch (Exception ex) { }
            //    Console.WriteLine("end");
            //}

            //Policy policyRetry = Policxy.Handle<Exception>().Retry(3);
            //Policy policyFallback = Policy.Handle<Exception>().Fallback(() => { Console.WriteLine("降级"); });
            //var policy = policyFallback.Wrap(policyRetry);
            //policy.Execute(()=> {
            //    Console.WriteLine("start");
            //    throw new Exception("Error");
            //});

            Policy policy = Policy.Handle<Exception>().Fallback(()=> { Console.WriteLine("执行出错"); });
            policy = policy.Wrap(Policy.Timeout(2,TimeoutStrategy.Pessimistic));
            policy.Execute(()=> {
                Console.WriteLine("开始任务");
                Thread.Sleep(5000);

            });
        }
    }
}
