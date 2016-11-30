using System;  
using System.Net;  
using System.Text;  
using System.Net.Sockets;  
  
namespace ConsoleApplication
 {  
    class TcpHelper
       {  
          public static void Main(string[] args)  
             {  
                // Start the server  
                TcpHelper.StartServer(8080);  
                TcpHelper.Listen(); // Start listening.  
             }  
        private static TcpListener listener { get; set; }  
        private static bool accept { get; set; } = false;  
   
        public static void StartServer(int port) {  
            IPAddress address = IPAddress.Parse("0.0.0.0");  
            listener = new TcpListener(address, port);  
   
            listener.Start();  
            accept = true;  
   
            Console.WriteLine($"Server started. Listening to TCP clients at 127.0.0.1:{port}");  
        }  
   
        public static void Listen()
       {  
            if(listener != null && accept) 
            {  
   
                // Continue listening.  
                while (true)
                 {  
                    Console.WriteLine("Waiting for client...");  
                    var clientTask = listener.AcceptTcpClientAsync(); // Get the client  
   
                    if(clientTask.Result != null)
                      {  
                        Console.WriteLine("Client connected. Waiting for data.");  
                        var client = clientTask.Result;  
                        string message = "";  
   
                        byte[] data = Encoding.ASCII.GetBytes("HEAD / HTTP/1.0\r\n\r\nHello world!");  
                        client.GetStream().Write(data, 0, data.Length);  
   
                        client.GetStream().Dispose();  
                    }  
                }  
            }  
        }  
    }  
}  


