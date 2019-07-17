using System;
using System.Threading;

namespace Cobalt.ConsoleApp
{
    public partial class ConsoleUtils
    {
        /// <summary>
        /// Show a message for a specified number of seconds before continuing.
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="seconds">Seconds to show message</param>
        /// <param name="showCountdown">Show countdown: "My message...3...2...1"</param>
        public static void TimedMessage(string message, int seconds, bool showCountdown)
        {
            Console.Write(message);

            for (int i = seconds; i > 0; i--)
            {
                if (showCountdown)
                    Console.Write(string.Format("...{0}", i));
                Thread.Sleep(1000);
            }

            Console.WriteLine();
        }
    }
}
