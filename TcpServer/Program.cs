using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static void Main(string[] args)
    {
        // 创建 Socket
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        // 绑定到指定的 IP 和端口
        serverSocket.Bind(new IPEndPoint(IPAddress.Any, 8080));
        serverSocket.Listen(10);
        Console.WriteLine("服务器正在等待客户端连接...");

        // 等待并接受客户端的连接
        Socket clientSocket = serverSocket.Accept();
        Console.WriteLine("客户端已连接");

        // 接收客户端传来的数据
        byte[] buffer = new byte[1024];
        int receivedBytes = clientSocket.Receive(buffer);
        string dataReceived = Encoding.UTF8.GetString(buffer, 0, receivedBytes);
        Console.WriteLine($"收到数据: {dataReceived}");

        // 数据处理（假设简单的回显处理）
        string processedData = dataReceived.ToUpper(); // 处理数据（这里将输入转为大写）
        
        // 发送处理后的数据回客户端
        byte[] dataToSend = Encoding.UTF8.GetBytes(processedData);
        clientSocket.Send(dataToSend);

        // 关闭连接
        clientSocket.Shutdown(SocketShutdown.Both);
        clientSocket.Close();
    }
}
