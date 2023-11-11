using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MessengerService.Core.Infrastructure;
using MessengerService.Service;
using MessengerService.Utilities;
using NUnit.Framework;

namespace MessengerServiceTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestLog()
        {
            LogUtility.WriteLine("Test message ___");
        }

        [Test]
        public async Task GetAllMessages()
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint remotePoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);
            
            byte[] binaryQuery = Encoding.UTF8.GetBytes(new Query(QueryHeader.UpdateChat).ToString());
            await udpClient.SendAsync(binaryQuery, binaryQuery.Length, remotePoint);
            
            UdpReceiveResult rawResult = await udpClient.ReceiveAsync();
            Response response = Response.FromRawLine(Encoding.UTF8.GetString(rawResult.Buffer));

            Console.WriteLine("Received data: " + response.JsonDataString);
            
        }
    }
}