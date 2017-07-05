using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Restfulapi.Utils
{
    /// <summary>
    /// Model for all the service calls
    /// </summary>
    [DataContract]
    public class ResponseWrapper<T>
    {
        /// <summary>
        ///   Get/Set Meta Data
        /// </summary>
        [DataMember]
        [Required]
        public Metadata metaData { get; set; }

        /// <summary>
        ///     actual response
        /// </summary>
        [DataMember]
        [Required]
        public T data { get; set; }
    }
    /// <summary>
    /// Model for Application level Errors
    /// </summary>
    [DataContract]
    public class ErrorReponse
    {
        /// <summary>
        ///     Set/Get Error Code
        /// </summary>
        [DataMember]
        public string code { get; set; }
        /// <summary>
        ///      Set/Get Error ErrorMessage
        /// </summary>
        [DataMember]
        public string message { get; set; }

    }
    /// <summary>
    /// Model for Application level Errors
    /// </summary>
    [DataContract]
    public class Metadata
    {
        /// <summary>
        ///      Set/Get Description
        /// </summary>
        [DataMember]
        [Required]
        public string description { get; set; }
        /// <summary>
        ///      Set/Get application level errors 
        /// </summary>
        [DataMember]
        public ErrorReponse error { get; set; }
    }

}