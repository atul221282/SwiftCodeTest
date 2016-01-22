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

        /// <summary>
        /// Gets or sets the client record.
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
        /// </summary>
        /// <value>
        /// The client record identifier.
        /// </value>
        [DataMember]
        public int ClientRecordId
        {
            get { return _clientRecordBelongToId; }
            set { _clientRecordBelongToId = value; }
        }

    }
}
