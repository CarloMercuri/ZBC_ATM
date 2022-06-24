using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_ATM
{
    public class ATMMachine
    {
        private Card currentCard;
        ATMServer server = ATMServer.Instance;

        public void InputPin(int pin)
        {
            if(server.ValidatePin(currentCard.CardNumber, 9878))
            {

            }
        }
    }
}
