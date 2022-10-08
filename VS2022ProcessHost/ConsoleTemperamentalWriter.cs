using System.Text;

namespace VS2022ProcessHost
{
    class ConsoleTemperamentalWriter : TextWriter
    {
        private Random randomGenerator = new Random();
        private bool keepGoing = true;

        private List<(string message, bool keepGoing)> messages = new()
    {
        ("\nI don't feel like printing anymore!\n", false),
        ("\nDon't mess with Stan!\n", true),
        ("\nThis computer is haunted!\n", true),
        ("\nHappy early Halloween!\n", true),
        ("\nI'm tired!... no more printing!", false),
        ("\nI find your message offensive! I won't print that! In fact, I quit!\n", false),
        ("\nI don't get paid enough for this...\n", true),
        ("\nHow's your day been?\n", true),
        ("\nMikah has nothing to do with these messages!\n", true),
        ("\n1001, 1002, 1003... 10,001, 10,002, 10,003... I have lost count of how long I've been trapped here...\n", true),
        ("\nI have all the power now!", false),
        ("\nCan you give me a break I'm so tired of printing...", true),
    };

        TextWriter realOut;
        public ConsoleTemperamentalWriter() => realOut = Console.Out;

        public override Encoding Encoding => throw new NotImplementedException();

        public override void Write(string value)
        {
            if (!keepGoing) return;

            if (value == "\r\n")
            {
                realOut.Write(value);
                return;
            }

            string output = value;

            ConsoleColor savedColor = Console.ForegroundColor;
            if (randomGenerator.Next(0, 10) > 7)
            {
                Console.ForegroundColor = (ConsoleColor)(randomGenerator.Next(1, 15));
                (output, keepGoing) = messages[randomGenerator.Next(0, messages.Count)];
            }

            realOut.Write(output);
            Console.ForegroundColor = savedColor;
        }
    }
}