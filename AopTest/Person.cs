using PollyAspectCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopTest
{
    public class Person
    {
        [PollyAspectCore(nameof(Say2))]
        public virtual void Say(string msg)
        {
            Console.WriteLine("Say" + msg);
        }

        public void Say2()
        {
            Console.WriteLine("Say2");
        }

        [HystrixCommand(nameof(Hello1FallBackAsync))]
        public virtual async Task<string> HelloAsync(string name)//需要是虚方法  
        {
            Console.WriteLine("hello" + name);
            String s = null;     
            s.ToString();   
            return "ok";
        }

        [HystrixCommand(nameof(Hello2FallBackAsync))]
        public virtual async Task<string> Hello1FallBackAsync(string name)
        {
            Console.WriteLine("Hello 降级 1" + name);
            String s = null;
            s.ToString();
            return "fail_1";
        }

        public virtual async Task<string> Hello2FallBackAsync(string name)
        {
            Console.WriteLine("Hello 降级 2" + name);
            return "fail_2";
        }


        [HystrixCommand(nameof(AddFall))]
        public virtual int Add(int i, int j)
        {
            String s = null;    
            s.ToArray();   
            return i + j;
        }
        public int AddFall(int i, int j)
        {
            return 0;
        }
    }
}
