using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_ATM
{
    public class ATMServer
    {
        private static ATMServer instance = null;
        private static readonly object padlock = new object();

        public static ATMServer Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ATMServer();
                    }
                    return instance;
                }
            }
        }

        private Dictionary<string, string> Offsets = new Dictionary<string, string>();

        public ATMServer()
        {
            Offsets.Add("4029302940283948", "4029302940281109"); // pin 2839
            Offsets.Add("4029384928398129", "4029384928391931"); // pin 6198
            Offsets.Add("4029384928394423", "4029384928392258"); // pin 2165
            Offsets.Add("4029384928395209", "4029384928392094"); // pin 3115
            Offsets.Add("4029384928399829", "4029384928394831"); // pin 4998
        }

        public bool ValidatePin(string card_number, int pin)
        {
            // Server stores Offsets. 
            // Offset is card number where the last 4 digits are
            // the original last 4 digits - pin code.
            // So when a user inputs the pin code, both the pin and
            // the card number are sent to the server, which substracts the pin
            // and if the result is the same as the stored value, the pin is correct.
            // this is an oversimplified version of how it happens in reality

            string lastFour = GetLastFourDigits(card_number);
            int lastToInt = Int32.Parse(lastFour);
            int offset = Math.Abs(lastToInt - pin);

            string newNumber = card_number.Substring(0, card_number.Length - 4) + offset.ToString();

            if (Offsets[card_number] == newNumber)
            {
                return true;
            }

            return false;
        }

        public string GetLastFourDigits(string number)
        {
            return number.Substring(number.Length - 4);
        }

    }
}
