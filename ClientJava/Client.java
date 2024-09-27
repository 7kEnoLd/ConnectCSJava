import java.io.*;
import java.net.*;

public class Client {
    public static void main(String[] args) {
        try {
            // 连接到 C# 服务器（假设服务器在本地运行）
            Socket socket = new Socket("127.0.0.1", 8080);

            // 发送数据到服务器
            OutputStream output = socket.getOutputStream();
            PrintWriter writer = new PrintWriter(output, true);
            String messageToSend = "hello, c#";
            writer.println(messageToSend);
            System.out.println("发送数据: " + messageToSend);

            // 从服务器接收处理后的数据
            InputStream input = socket.getInputStream();
            BufferedReader reader = new BufferedReader(new InputStreamReader(input));
            String response = reader.readLine();
            System.out.println("收到服务器的响应: " + response);

            // 关闭连接
            socket.close();
        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }
}