using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace Restfulapi.Models
{
    [DataContract]
    public class Cars
    {
        /// <summary>
        /// name=id
        /// position=1
        /// Description=this description
        /// </summary>
        [DataMember]
        public int id { get; set; }

        /// <summary>
        /// name=name
        /// position=2
        /// Description=this description
        /// </summary>
        [DataMember]
        public string name { get; set; }

        /// <summary>
        /// name=description
        /// position=3
        /// Description=this description
        /// </summary>
        [DataMember]
        public string description { get; set; }
    }
}