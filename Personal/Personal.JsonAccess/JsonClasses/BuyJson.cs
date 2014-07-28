using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.JsonAccess.JsonClasses
{
    public class BuyJson
    {
        public string session_id { get; set; }
        public string device { get; set; }
        public string element_id{ get; set; }
        public string quality { get; set; }


        public BuyJson()
        {
            session_id = string.Empty;
            device = "windows_phone";
            element_id = string.Empty;
            quality = string.Empty;
        }       

    }
}
