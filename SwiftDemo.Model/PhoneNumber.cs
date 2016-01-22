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
        private ClientRecord _clientRecordBelongTo;
        private int _clientRecordBelongToId;

        /// <summary>
        /// Gets or sets the number.
        /// TODO: Get error messaget from resource file
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        [DataMember,
            Required(ErrorMessage = "Phone number is mandatory"),
            StringLength(15, ErrorMessage = "Phone number is not valid")]
        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        /// <summary>
        /// Gets or sets the client record.
        /// TODO: Get error messaget from resource file
        /// </summary>
        /// <value>
        /// The client record.
        /// </value>
        [DataMember]
        public virtual ClientRecord ClientRecordBelongTo
        {
            get { return _clientRecordBelongTo; }
            set { _clientRecordBelongTo = value; }
        }

        /// <summary>
        /// Gets or sets the client record identifier.
        /// TODO: Get error messaget from resource file
        /// </summary>
        /// <value>
        /// The client record identifier.
        /// </value>
        [DataMember, Required(ErrorMessage = "Client record is mandatory")]
        public int ClientRecordId
        {
            get { return _clientRecordBelongToId; }
            set { _clientRecordBelongToId = value; }
        }

    }
}
