using System;
using Racer;
using NUnit.Framework;

namespace RacerTest
{
    [TestFixture]
    public class SenderTester
    {
        [TestCase]
        public void TestHeaderSender()
        {
            HeaderSender sender = new HeaderSender("Hello");

            string expected = "Hello\n\nGoodbye";

            StringAssert.AreEqualIgnoringCase(sender.AppendMessage("Goodbye"), expected);
        }

        [TestCase]
        public void TestFooterSender()
        {
            FooterSender sender = new FooterSender("Hello");

            string expected = "Goodbye\n\nHello";

            StringAssert.AreEqualIgnoringCase(sender.AppendMessage("Goodbye"), expected);
        }

        [TestCase]
        public void TestHeaderFooterSender()
        {
            EmailSender sender = new FooterSender("Goodbye", new HeaderSender("Hello"));
            EmailSender sender2 = new HeaderSender("Hello", new FooterSender("Goodbye"));

            string expected = "Hello\n\nSir\n\nGoodbye";

            StringAssert.AreEqualIgnoringCase(sender.AppendMessage("Sir"), expected);
            StringAssert.AreEqualIgnoringCase(sender2.AppendMessage("Sir"), expected);
        }
    }
}
