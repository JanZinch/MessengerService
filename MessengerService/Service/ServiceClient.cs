using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using MessengerService.Core.Infrastructure;
using MessengerService.Core.Models;
using MessengerService.Utilities;

namespace MessengerService.Service
{
    public class ServiceClient : IDisposable
    {
        private readonly IPEndPoint _remotePoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);
        private readonly UdpClient _udpClient;
        
        private static readonly TimeSpan UpdatePeriod = TimeSpan.FromSeconds(1.0f);
        private Timer _updateTimer;

        public ServiceClient()
        {
            _udpClient = new UdpClient();
            Start();
        }
        
        public void Start()
        {
            _updateTimer = new Timer(Update, null, UpdatePeriod, UpdatePeriod);
        }
    
        private void Update(object parameter)
        {
            GetMessagesAsync(null);
        }
    
        private async void GetMessagesAsync(Action<List<Message>> onCompleteCallback)
        {
            Query query = new Query(QueryHeader.UpdateChat);
            byte[] binaryQuery = Encoding.UTF8.GetBytes(query.ToString());

            await _udpClient.SendAsync(binaryQuery, binaryQuery.Length, _remotePoint);
            
            UdpReceiveResult rawResult = await _udpClient.ReceiveAsync();
            Response response = Response.FromRawLine(Encoding.UTF8.GetString(rawResult.Buffer));

            LogUtility.WriteLine("Received data: " + response.JsonDataString);
            //List<Message> messagesList = JsonSerializer.Deserialize<List<Message>>(response.JsonDataString);
            //onCompleteCallback?.Invoke(messagesList);
        }
        
        public void Stop()
        {
            _updateTimer?.Dispose();
        }

        public void Dispose()
        {
            Stop();
            _udpClient?.Close();
        }
    }
}