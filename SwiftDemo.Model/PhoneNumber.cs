using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SwiftDemo.Model
{
    /// <summary>
    /// Represents the client phone number
    /// </summary>
    [DataContract]
    public class PhoneNumber : BaseClass
    {
        private string _number;

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        [DataMember]
        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

    }
}
