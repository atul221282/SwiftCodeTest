﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SwiftTest.Model
{
    /// <summary>
    /// Represents base class property
    /// </summary>
    [DataContract]
    public abstract class BaseClass
    {
        private int _id;
        private byte[] _rowVersion { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember, Key]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Gets or sets the row version.
        /// </summary>
        /// <value>
        /// The row version.
        /// </value>
        [DataMember, Timestamp]
        public byte[] RowVersion
        {
            get { return _rowVersion; }
            set { _rowVersion = value; }
        }

    }
}