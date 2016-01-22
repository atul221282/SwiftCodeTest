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
    /// Represents the client record
    /// </summary>
    [DataContract]
    public class ClientRecord : BaseClass
    {
        private string _name;
        private string _address;
        private ICollection<PhoneNumber> _phoneNumbers;
        private string _formattedphoneNumbers;

        

        public ClientRecord()
        {
            this.PhoneNumbers = new List<PhoneNumber>();
        }
        /// <summary>
        /// Gets or sets the name of the client.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets the address of the client.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [DataMember]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        /// <summary>
        /// Gets or sets the phone numbers of the client.
        /// </summary>
        /// <value>
        /// The phone numbers.
        /// </value>
        [DataMember]
        public ICollection<PhoneNumber> PhoneNumbers
        {
            get { return _phoneNumbers; }
            set { _phoneNumbers = value; }
        }

        [DataMember]
        public string FormattedphoneNumbers
        {
            get
            {
                return _formattedphoneNumbers
                  = this.PhoneNumbers != null
                  ? string.Join(", ", this.PhoneNumbers.Select(x => x.Number).ToArray())
                  : string.Empty;
            }
        }
    }
}
