using AspectCore.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AopTest
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HystrixCommandAttribute : AbstractInterceptorAttribute
    {
        public HystrixCommandAttribute(string fallBackMethod)
        {
            this.FallBackMethod = fallBackMethod;
        }

        public string FallBackMethod { get; set; }
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            try
            {
                await next(context);//执行被拦截的方法             
            }
            catch (Exception ex)
            {
                //context.ServiceMethod 被拦截的方法。context.ServiceMethod.DeclaringType 被拦截方法所在的类                 
                //context.Implementation 实际执行的对象 p                 
                //context.Parameters 方法参数值                 
                //如果执行失败，则执行 FallBackMethod                 
                var fallBackMethod = context.ServiceMethod.DeclaringType.GetMethod(this.FallBackMethod);
                Object fallBackResult = fallBackMethod.Invoke(context.Implementation, context.Parameters);
                context.ReturnValue = fallBackResult;
            }
        }
    }
}
