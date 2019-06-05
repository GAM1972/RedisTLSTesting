using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class TlsVersionTest
    {
        public static void Run(string hostnameFQDN, int port)
        {
            Console.WriteLine();
            Console.WriteLine($"[{DateTimeOffset.Now.TimeOfDay}] *********   Running TLS/SSL Tests against: {hostnameFQDN}:{port}   *********\r\n");

            var protocols = new[] { SslProtocols.Ssl2, SslProtocols.Ssl3, SslProtocols.Tls, SslProtocols.Tls11, SslProtocols.Tls12 };

            var tasks = new HashSet<Task<String>>();

            foreach (var p in protocols)
            {
                tasks.Add(TestSslProtocol(hostnameFQDN, port, p, p.ToString()));
            }

            //tasks.Add(TestSslProtocol(hostnameFQDN, AnySSLProtocol(), "AllowAny"));
            tasks.Add(TestSslProtocol(hostnameFQDN, port, SslProtocols.Default, "Default"));

            while (tasks.Any())
            {
                var completed = Task.WhenAny(tasks).Result;
                string result = completed.Result;
                Console.WriteLine(result);
                tasks.Remove(completed);
            }
        }

        private static async Task<string> TestSslProtocol(string hostName, int port, SslProtocols p, string testDescription)
        {
            //Console.WriteLine($"P:{p}");
            await Task.Yield();

            var sb = new StringBuilder();
            Stopwatch sw = Stopwatch.StartNew();
            var actualProtocol = SslProtocols.None;

            try
            {

                using (var socket = new Socket(SocketType.Stream, ProtocolType.Tcp))
                {
                    socket.Connect(hostName, port);
                    var networkStream = new NetworkStream(socket, false);

                    var sslStream = new SslStream(networkStream);
                    var clientCerts = new System.Security.Cryptography.X509Certificates.X509CertificateCollection();

                

                    sslStream.AuthenticateAsClient(hostName, clientCerts, p, true);

                    actualProtocol = sslStream.SslProtocol;

                    sw.Stop();
                    sb.AppendLine($"{testDescription}: Allowed, Duration={sw.ElapsedMilliseconds}ms, Protocols Allowed: {p.ToStringExpanded()}, Protocol Used: {actualProtocol}");

                    sb.AppendLine($"  Cipher: {sslStream.CipherAlgorithm}, strength {sslStream.CipherStrength} bits");
                    sb.AppendLine($"  Hash: {sslStream.HashAlgorithm}, strength {sslStream.HashStrength} bits");
                    sb.AppendLine($"  Key exchange: {sslStream.KeyExchangeAlgorithm}, strength {sslStream.KeyExchangeStrength} bits");
                }
            }
            catch (Exception)
            {
                sb.AppendLine($"{testDescription}: BLOCKED, Duration={sw.ElapsedMilliseconds}ms, Protocols Attempted: {p.ToStringExpanded()}");
            }

            return sb.ToString();
        }

        private static SslProtocols AnySSLProtocol()
        {
            SslProtocols retval = SslProtocols.None;
            foreach (var t in Enum.GetValues(typeof(SslProtocols)).Cast<SslProtocols>())
            {
                retval = t | retval;
            }

            return retval;
        }

        private static string ToStringExpanded(this SslProtocols p)
        {
            var list = new System.Collections.Generic.List<SslProtocols>();
            foreach (var v in Enum.GetValues(typeof(SslProtocols)).Cast<SslProtocols>())
            {
                if (v == SslProtocols.Default || v == SslProtocols.None)
                    continue;

                if (p.HasFlag(v))
                    list.Add(v);
            }

            return string.Join(",", list);
        }
    }
}