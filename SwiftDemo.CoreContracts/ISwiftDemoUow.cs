using SwiftDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftDemo.CoreContracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISwiftDemoUow
    {
        /// <summary>
        /// Save pending changes to the data store.
        /// </summary>
        void Commit();

        /// <summary>
        /// Gets the client records.
        /// </summary>
        /// <value>
        /// The client records.
        /// </value>
        IRepository<ClientRecord> ClientRecords { get; }
        
    }
}
