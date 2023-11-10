using System;
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
    }
}