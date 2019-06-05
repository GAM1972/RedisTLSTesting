using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using StackExchange.Redis;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Threading.Tasks;
using System.Net.Security;
using System.Net;

namespace RedisCacheExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult RedisCache()
        {
            ViewBag.Message = "A simple example with Azure Cache for Redis on ASP.NET.";

            var lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                string cacheConnection = ConfigurationManager.AppSettings["CacheConnectiontls1"].ToString();
               
                return ConnectionMultiplexer.Connect(cacheConnection);
            });

           var theconfig = lazyConnection.Value.Configuration.ToString();
           var getthestatus = lazyConnection.Value.GetStatus();
   
   
            // Connection refers to a property that returns a ConnectionMultiplexer
            // as shown in the previous example.
            IDatabase cache = lazyConnection.Value.GetDatabase();

            // Perform cache operations using the cache object...
            
            // Simple PING command
            ViewBag.command1 = "PING";
            ViewBag.command1Result = cache.Execute(ViewBag.command1).ToString();

            // Simple get and put of integral data types into the cache
            ViewBag.command2 = "GET Message";
            ViewBag.command2Result = cache.StringGet("Message").ToString();

            ViewBag.command3 = "SET Message \"Hello! The cache is working from ASP.NET!\"";
            ViewBag.command3Result = cache.StringSet("Message", "Hello! The cache is working from ASP.NET!").ToString();

            // Demonstrate "SET Message" executed as expected...
            ViewBag.command4 = "GET Message";
            ViewBag.command4Result = cache.StringGet("Message").ToString();

            // Get the client list, useful to see if connection list is growing...
            ViewBag.command5 = "CLIENT LIST";
            ViewBag.command5Result = cache.Execute("CLIENT", "LIST").ToString().Replace(" id=", "\rid=");

            ViewBag.lazyconfig = theconfig;

            ViewBag.lazyStatus = getthestatus;

            lazyConnection.Value.Dispose();

            return View();
        }

        public ActionResult RedisCachetls11()
        {
            ViewBag.Message = "A simple example with Azure Cache for Redis on ASP.NET.";

            var lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                string cacheConnection = ConfigurationManager.AppSettings["CacheConnectiontls11"].ToString();

                return ConnectionMultiplexer.Connect(cacheConnection);
            });

            var theconfig = lazyConnection.Value.Configuration.ToString();
            var getthestatus = lazyConnection.Value.GetStatus();



            // Connection refers to a property that returns a ConnectionMultiplexer
            // as shown in the previous example.
            IDatabase cache = lazyConnection.Value.GetDatabase();

            // Perform cache operations using the cache object...

            // Simple PING command
            ViewBag.command1 = "PING";
            ViewBag.command1Result = cache.Execute(ViewBag.command1).ToString();

            // Simple get and put of integral data types into the cache
            ViewBag.command2 = "GET Message";
            ViewBag.command2Result = cache.StringGet("Message").ToString();

            ViewBag.command3 = "SET Message \"Hello! The cache is working from ASP.NET!\"";
            ViewBag.command3Result = cache.StringSet("Message", "Hello! The cache is working from ASP.NET!").ToString();

            // Demonstrate "SET Message" executed as expected...
            ViewBag.command4 = "GET Message";
            ViewBag.command4Result = cache.StringGet("Message").ToString();

            // Get the client list, useful to see if connection list is growing...
            ViewBag.command5 = "CLIENT LIST";
            ViewBag.command5Result = cache.Execute("CLIENT", "LIST").ToString().Replace(" id=", "\rid=");

            ViewBag.lazyconfig = theconfig;

            ViewBag.lazyStatus = getthestatus;

            lazyConnection.Value.Dispose();

            return View();
        }

        public ActionResult RedisCachetls12()
        {
            ViewBag.Message = "A simple example with Azure Cache for Redis on ASP.NET.";

            var lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                string cacheConnection = ConfigurationManager.AppSettings["CacheConnectiontls12"].ToString();

                return ConnectionMultiplexer.Connect(cacheConnection);
            });

            var theconfig = lazyConnection.Value.Configuration.ToString();
            var getthestatus = lazyConnection.Value.GetStatus();

            //SSL level


            // var hostName = "myredis.redis.cache.usgovcloudapi.net";
            //var port = 6380;
            //var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            //var actualProtocol = SslProtocols.None;
            //var protocols = new[] { SslProtocols.Ssl2, SslProtocols.Ssl3, SslProtocols.Tls, SslProtocols.Tls11, SslProtocols.Tls12 
            //socket.Connect(hostName, port);
            //var networkStream = new NetworkStream(socket, false);
            //var sslStream = new SslStream(networkStream);
            //var clientCerts = new System.Security.Cryptography.X509Certificates.X509CertificateCollection();
            //sslStream.AuthenticateAsClient(hostName, clientCerts, SslProtocols.Tls, true);
            //actualProtocol = sslStream.SslProtocol;

            //SSL LEVEL 

            // Connection refers to a property that returns a ConnectionMultiplexer
            // as shown in the previous example.
            IDatabase cache = lazyConnection.Value.GetDatabase();

            // Perform cache operations using the cache object...

            // Simple PING command
            ViewBag.command1 = "PING";
            ViewBag.command1Result = cache.Execute(ViewBag.command1).ToString();

            // Simple get and put of integral data types into the cache
            ViewBag.command2 = "GET Message";
            ViewBag.command2Result = cache.StringGet("Message").ToString();

            ViewBag.command3 = "SET Message \"Hello! The cache is working from ASP.NET!\"";
            ViewBag.command3Result = cache.StringSet("Message", "Hello! The cache is working from ASP.NET!").ToString();

            // Demonstrate "SET Message" executed as expected...
            ViewBag.command4 = "GET Message";
            ViewBag.command4Result = cache.StringGet("Message").ToString();

            // Get the client list, useful to see if connection list is growing...
            ViewBag.command5 = "CLIENT LIST";
            ViewBag.command5Result = cache.Execute("CLIENT", "LIST").ToString().Replace(" id=", "\rid=");

            ViewBag.lazyconfig = theconfig;

            ViewBag.lazyStatus = getthestatus;

            lazyConnection.Value.Dispose();

            return View();
        }

        public ActionResult RedisCacheTLSTEsting()
        {
            //SSL level tls 1.0

            try
            {
                // var hostName = "myredis.redis.cache.usgovcloudapi.net";
                //var port = 6380;

                var FQDN = ConfigurationManager.AppSettings["FQDNToTest"].ToString();
                if (FQDN != null)
                {
                    var hostName = Dns.GetHostEntry(ConfigurationManager.AppSettings["FQDNToTest"].ToString());
                var hostIP = hostName.AddressList[0];
                var port = ConfigurationManager.AppSettings["FQDNPortToTest"];

              

               
                var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                var actualProtocol = SslProtocols.None;
                //var protocols = new[] { SslProtocols.Ssl2, SslProtocols.Ssl3, SslProtocols.Tls, SslProtocols.Tls11, SslProtocols.Tls12 

                socket.Connect(hostIP, Int32.Parse(port));
                var networkStream = new NetworkStream(socket, false);
                var sslStream = new SslStream(networkStream);
                var clientCerts = new System.Security.Cryptography.X509Certificates.X509CertificateCollection();
                sslStream.AuthenticateAsClient(FQDN, clientCerts, SslProtocols.Tls, true);
                actualProtocol = sslStream.SslProtocol;

                ViewBag.ssltesttls1 = "Test Good";
                ViewBag.ssltesttls1protocol = sslStream.SslProtocol.ToString();
                ViewBag.ssltesttls1CipherAl = sslStream.CipherAlgorithm.ToString();
                ViewBag.ssltesttls1CipherSt = sslStream.CipherStrength.ToString();
                ViewBag.ssltesttls1HashAlg = sslStream.HashAlgorithm.ToString();
                ViewBag.ssltesttls1HashStr = sslStream.HashStrength.ToString();
                ViewBag.ssltesttls1KeyExAl = sslStream.KeyExchangeAlgorithm.ToString();
                ViewBag.ssltesttls1KeyExSt = sslStream.KeyExchangeStrength.ToString();
                }
                else
                {
                    ViewBag.ssltesttls1 = "Connection not found";
                }
            }
            catch (Exception)
            {
                ViewBag.ssltesttls1 = "Test Bad";

            }
            //SSL LEVEL tls 1.0

            //SSL level tls 1.1

            try
            {
                var FQDN = ConfigurationManager.AppSettings["FQDNToTest"].ToString();
                if (FQDN != null)
                {
                    var hostName = Dns.GetHostEntry(ConfigurationManager.AppSettings["FQDNToTest"].ToString());
                    var hostIP = hostName.AddressList[0];
                    var port = ConfigurationManager.AppSettings["FQDNPortToTest"];

                    var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                    var actualProtocol = SslProtocols.None;

                    socket.Connect(hostIP, Int32.Parse(port));
                    var networkStream = new NetworkStream(socket, false);
                    var sslStream = new SslStream(networkStream);
                    var clientCerts = new System.Security.Cryptography.X509Certificates.X509CertificateCollection();
                    sslStream.AuthenticateAsClient(FQDN, clientCerts, SslProtocols.Tls11, true);
                    actualProtocol = sslStream.SslProtocol;

                    ViewBag.ssltesttls11 = "Test Good";
                    ViewBag.ssltesttls11protocol = sslStream.SslProtocol.ToString();
                    ViewBag.ssltesttls11CipherAl = sslStream.CipherAlgorithm.ToString();
                    ViewBag.ssltesttls11CipherSt = sslStream.CipherStrength.ToString();
                    ViewBag.ssltesttls11HashAlg = sslStream.HashAlgorithm.ToString();
                    ViewBag.ssltesttls11HashStr = sslStream.HashStrength.ToString();
                    ViewBag.ssltesttls11KeyExAl = sslStream.KeyExchangeAlgorithm.ToString();
                    ViewBag.ssltesttls11KeyExSt = sslStream.KeyExchangeStrength.ToString();
                }
                else
                {
                    ViewBag.ssltesttls11 = "Connection not found";
                }

            }
            catch (Exception)
            {
                ViewBag.ssltesttls11 = "Test Bad";

            }
            //SSL LEVEL tls 1.1


            //SSL level tls 1.2

            try
            {
                var FQDN = ConfigurationManager.AppSettings["FQDNToTest"].ToString();
                if (FQDN != null)
                {
                    var hostName = Dns.GetHostEntry(ConfigurationManager.AppSettings["FQDNToTest"].ToString());
                    var hostIP = hostName.AddressList[0];
                    var port = ConfigurationManager.AppSettings["FQDNPortToTest"];

                    var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                    var actualProtocol = SslProtocols.None;
                    //var protocols = new[] { SslProtocols.Ssl2, SslProtocols.Ssl3, SslProtocols.Tls, SslProtocols.Tls11, SslProtocols.Tls12 

                    socket.Connect(hostIP, Int32.Parse(port));
                    var networkStream = new NetworkStream(socket, false);
                    var sslStream = new SslStream(networkStream);
                    var clientCerts = new System.Security.Cryptography.X509Certificates.X509CertificateCollection();
                    sslStream.AuthenticateAsClient(FQDN, clientCerts, SslProtocols.Tls12, true);
                    actualProtocol = sslStream.SslProtocol;

                    ViewBag.ssltesttls12 = "Test Good";
                    ViewBag.ssltesttls12protocol = sslStream.SslProtocol.ToString();
                    ViewBag.ssltesttls12CipherAl = sslStream.CipherAlgorithm.ToString();
                    ViewBag.ssltesttls12CipherSt = sslStream.CipherStrength.ToString();
                    ViewBag.ssltesttls12HashAlg = sslStream.HashAlgorithm.ToString();
                    ViewBag.ssltesttls12HashStr = sslStream.HashStrength.ToString();
                    ViewBag.ssltesttls12KeyExAl = sslStream.KeyExchangeAlgorithm.ToString();
                    ViewBag.ssltesttls12KeyExSt = sslStream.KeyExchangeStrength.ToString();
                }
                else
                {
                    ViewBag.ssltesttls12 = "Connection not found";
                }

            }
            catch (Exception)
            {
                ViewBag.ssltesttls12 = "Test Bad";

            }
            //SSL LEVEL tls 1.2

            return View();
        }

    }

}