using ChatGPT.Net;
using ChatGPT.Net.DTO.ChatGPT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderPlacement.Database;
using System.Collections.Generic;

namespace OrderPlacement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Statistics : ControllerBase
    {
        [HttpGet]
        [Route("StatisticsNoAI")]

        public string GetMostPopularProduct()
        {
            var allOrders = new DatabaseRepository().GetOrders();
            var MostPopular = allOrders.GroupBy(i => i.Product)
                .OrderByDescending(grp => grp.Count())
                .Select(grp => grp.Key)
                .First();
            return MostPopular;
        }

        [HttpGet]
        [Route("StatisticsWithAI")]
        public string GetMostPopularProductUsingAI()
        {
            var allOrders = new DatabaseRepository().GetOrders();
            var answer = new ChatGPT.ChatGptRepository().AskQuestion("here is some data, what is the most popular product " + JsonConvert.SerializeObject(allOrders));
            return answer;
        }

    }
}
