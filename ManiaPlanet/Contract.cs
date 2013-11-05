using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet
{
    public enum ContractState
    {
        WaitingForConfirmation = 1,
        Valid = 2
    }

    public class Contract
    {
        public int id { get; set; }
        public int teamId { get; set; }
        public Team team { get; set; }
        public string login { get; set; }
        public Player player { get; set; }
        public ContractState state { get; set; }
        public Date date { get; set; }
    }
}
