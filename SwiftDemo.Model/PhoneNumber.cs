using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SwiftDemo.Model
{
    /// <summary>
    /// Phone number class
    /// </summary>
    /// <seealso cref="SwiftDemo.Model.BaseClass" />
    [DataContract]
    public class PhoneNumber : BaseClass
    {
        private string _number;

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        /// <value>
        /// The numbers.
        /// </value>
        [DataMember]
        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

    }
}
