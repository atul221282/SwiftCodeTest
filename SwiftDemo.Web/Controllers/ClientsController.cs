﻿using SwiftTest.CoreContracts;
using SwiftTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using SwiftTest.Web.Helpers;

namespace SwiftTest.Web.Controllers
{
    public class ClientsController : ApiControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientsController"/> class.
        /// </summary>
        /// <param name="uow">The uow.</param>
        public ClientsController(ISwiftDemoUow uow)
        {
            sdUow = uow;
        }

        /// <summary>
        /// Gets this clients records.
        /// </summary>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get()
        {
            var list = await Task.Factory.StartNew(() =>
             sdUow.ClientRecords.GetAll().Include(x => x.ClientPhones.Select(y => y.PhoneNumber)).OrderBy(x => x.Name).ToList());

            //get client records with phone numbers where phone numbers contains basic info only
            //to avoid circular reference error
            var filteredList = list
                .Select(x => new ClientRecord
                {
                    Id = x.Id,
                    Address = x.Address,
                    Name = x.Name,
                    RowVersion = x.RowVersion,
                    ClientPhones = x.ClientPhones.Select(y => new ClientPhone
                    {
                        Id = y.Id,
                        ClientRecordId = y.ClientRecordId,
                        PhoneNumber = y.PhoneNumber,
                        RowVersion = y.RowVersion
                    }).ToList()
                });

            return Ok<IEnumerable<ClientRecord>>(filteredList.ToList());
        }

        /// <summary>
        /// Add the specified attendance.
        /// </summary>
        /// <param name="attendance">The attendance.</param>
        /// <returns></returns>
        [Route("Post")]
        public HttpResponseMessage Post(ClientRecord clientRecord)
        {
            sdUow.ClientRecords.Add(clientRecord);
            sdUow.Commit();
            // Set client record to null to fix circular reference issue
            clientRecord.ClientPhones.ToList().ForEach(x => x.ClientRecord = null);
            var response = Request.CreateResponse(HttpStatusCode.Created, clientRecord);
            return response;
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="clientRecord">The client record.</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Put(int Id, ClientRecord clientRecord)
        {
            sdUow.ClientRecords.Update(clientRecord);
            sdUow.Commit();
            return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.NoContent));
        }

        /// <summary>
        /// Sends the delivery.
        /// </summary>
        /// <param name="clientRecord">The client record.</param>
        /// <returns></returns>
        [HttpPost, Route("SendDelivery")]
        public async Task<IHttpActionResult> SendDelivery(ClientRecord clientRecord)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.PostStringAsync<object>(CommonHelper.GetSwiftApi("deliveries"), SetPayload(clientRecord));
                return Ok(JObject.Parse(await result.Content.ReadAsStringAsync()));
            }
        }

        /// <summary>
        /// Sets the payload.
        /// </summary>
        /// <param name="clientRecord">The client record.</param>
        /// <returns></returns>
        private object SetPayload(ClientRecord clientRecord)
        {
            var payLoad = new
            {
                apiKey = "3285db46-93d9-4c10-a708-c2795ae7872d",
                booking = new
                {
                    pickupDetail = new
                    {
                        address = "57 luscombe st, brunswick, melbourne"
                    },
                    dropoffDetail = new
                    {
                        address = clientRecord.Address
                    }
                }
            };
            return payLoad;
        }


    }
}
