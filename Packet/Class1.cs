using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Packet
{
    [Serializable]
    public class Trade
    {
        public int number;
        public string category = null;
        public DateTime transaction;
        public DateTime deadline;
        public string orderer = null;
        public string demander = null;
        public string contents = null;
        public string product = null;
        public string OS = null;
        public int quantity;
        public int price;
        public string manager = null;
        public DateTime inspection;
        public DateTime bill;
        public DateTime modify;
        public string registrar = null;
    }

    [Serializable]
    public class User
    {
        public string name;
        public string id;
        public string password;
    }
}
