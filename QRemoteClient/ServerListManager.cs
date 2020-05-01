using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRemoteClient
{
    static class ServerListManager
    {
        public static string ServerListPath = "serverlist.dat";
        public static List<string> GetServers()
        {
            List<string> result = new List<string>();
            try
            {
                StreamReader sr = new StreamReader(ServerListPath);
                while (!sr.EndOfStream)
                    result.Add(sr.ReadLine());
                sr.Close();
                return result;
            }
            catch
            {
                result = new List<string>();
                return result;
            }
        }
        public static void AddServer(string ip_port)
        {
            List<string> servers = new List<string>();
            try
            {
                if (File.Exists(ServerListPath))
                {
                    StreamReader sr = new StreamReader(ServerListPath);
                    while (!sr.EndOfStream)
                    {
                        string server = sr.ReadLine();
                        if (server != ip_port)
                            servers.Add(server);
                    }
                    sr.Close();
                    servers.Add(ip_port);
                    File.WriteAllLines(ServerListPath, servers);
                }
                else
                    File.WriteAllLines(ServerListPath, new string[] { ip_port });
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
