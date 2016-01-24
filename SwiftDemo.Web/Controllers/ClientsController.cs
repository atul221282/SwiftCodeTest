using SwiftDemo.CoreContracts;
using SwiftDemo.Model;
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

namespace SwiftDemo.Web.Controllers
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
        public HttpResponseMessage Post(ClientRecord clientRecord)
        {
            sdUow.ClientRecords.Add(clientRecord);
            sdUow.Commit();
            // Set client record to null to fix circular reference issue
            clientRecord.ClientPhones.ToList().ForEach(x => x.ClientRecord = null);
            var response = Request.CreateResponse(HttpStatusCode.Created, clientRecord);
            return response;
        }

        public async Task<HttpResponseMessage> Put(int Id, ClientRecord clientRecord)
        {
            //sdUow.ClientRecords.Update(clientRecord);
            //sdUow.Commit();
            //var client = new HttpClient();
            var pp = new
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
                        address = "105 collins st, 3000"
                    }
                }
            };
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://app.getswift.co/api/v2/deliveries");
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri("https://app.getswift.co/api/v2/deliveries"));
            request.Content = new StringContent(Newtonsoft.Json.Linq.JObject.FromObject(pp).ToString(),
                                                Encoding.UTF8,
                                                "application/json");

            var result = await client.SendAsync(request);

            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
