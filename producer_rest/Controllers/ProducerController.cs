using Microsoft.AspNetCore.Mvc;
using producer_rest.DbConext;
using producer_rest.Models;
using RabbitMQ.Client;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace producer_rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducerController : Controller
    {
        private readonly ProducerDBContext _context;

        public ProducerController(ProducerDBContext context)
        {
            _context = context;
        }

        [HttpPost("Producer/task")]
        public async Task<IActionResult> CreateAsync(Producer producer)
        {
            _context.Add(producer);
            _context.SaveChanges();

            var factory = new ConnectionFactory() { HostName = "localhost" };


            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://reqres.in/api/login"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse.Contains(producer.email))
                    {
                        using (var connection = factory.CreateConnection())
                        using (var channel = connection.CreateModel())
                        {

                            //channel.ExchangeDeclare(exchange: "webBooking", ExchangeType.Fanout, true);

                            var message = $"QpwL5tke4Pnpja7X4";
                            var bytes = System.Text.Encoding.UTF8.GetBytes(message);

                            channel.BasicPublish(exchange: "",
                             routingKey: "TaskQueue",
                             basicProperties: null,
                             body: bytes);


                        }
                    }
                }
            }

            return Accepted();
        }
    }
}
