using System.ServiceProcess;

namespace MessengerService
{
    public static class Program
    {
        private static void Main()
        {
            ServiceBase.Run(new ServiceBase[] { new MessengerService() });
        }
    }
}
