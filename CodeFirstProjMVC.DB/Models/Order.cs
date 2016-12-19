using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstProjMVC.DB.Models
{
    public class Order
    {
        public string TackingID { get; set; }
        public string ServCode { get; set; }
        public string ShipFrom { get; set; }
        public string DeliverTo { get; set; }
        public string Value { get; set; }
        public string Date { get; set; }
        public string Weight { get; set; }
        public string Pieces { get; set; }
        public string ShipmentRef { get; set; }
        public string AirportCode { get; set; }
        public string DELIVERYINSTRUCTIONS { get; set; }
        public string DELIVERYSIGNATUREALWAYSREQUIRED { get; set; }
        public string OrderNo { get; set; }
        public string TackerName { get; set; }
        public string TackerID { get; set; }
        public byte[] TackingIDBC { get; set; }
        public byte[] TackerIDBC { get; set; }
    }
}
