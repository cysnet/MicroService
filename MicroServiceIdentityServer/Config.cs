using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceIdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            List<ApiResource> resources = new List<ApiResource>();         
            resources.Add(new ApiResource("MsgAPI", "消息服务API"));
            return resources;
        }

        /// <summary>         
        /// 返回账号列表         
        /// </summary>        
        /// <returns></returns>        
        public static IEnumerable<Client> GetClients()
        {
            List<Client> clients = new List<Client>();
            clients.Add(new Client
            {
                ClientId = "clientPC1",//API账号、客户端Id  
                //ClientName="clientPC1",
                ClientSecrets =
                {
                    new Secret("123321".Sha256())//秘钥          
                },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
     
                AllowedScopes = { "MsgAPI" }//这个账号支持访问哪些应用       
            });
            return clients;
        }
    }
}
