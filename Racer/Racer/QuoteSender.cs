using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racer
{
    public class QuoteSender : EmailDecorator
    {
        private Random randomizer = new Random(DateTime.Now.Millisecond);
        private string[] quotes =
            {
                "Always borrow money from a pessimist. He won’t expect it back. -Oscar Wilde",
                "Knowledge is knowing a tomato is a fruit; wisdom is not putting it in a fruit salad. -Miles Kington",
                "I asked God for a bike, but I know God doesn’t work that way. So I stole a bike and asked for forgiveness. -Emo Philips",
                "...whenever any Form of Government becomes destructive of these ends, it is the Right of the People to alter or to abolish it -Declaration of Independence",
                "If you want to build a ship, don't drum up the men to gather wood, divide the work, and give orders. Instead, teach them to yearn for the vast and endless sea. -Antoine de Saint-Exupery",
                "Pay the laborer his wages before his sweat dries. - Muhammad",
                "Well acting is a unique profession. Because it's rare when a baker is confused with a cake. Only a crazy person would confuse a baker and a cake. But almost everyone confuses Sean Connery with James Bond. — Judd Nelson"
            };

        public override string AppendMessage(string message)
        {
            string randomQuote = quotes[randomizer.Next(0, quotes.Length)];
            if (Next != null)
                return Next.AppendMessage(message) + "\n\nP.S. " + randomQuote;
            return message + "\n\nP.S. " + randomQuote;
        }
    }
}
