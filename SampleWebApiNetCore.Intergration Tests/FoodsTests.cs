using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SampleWebApiAspNetCore.Models;
using SampleWebApiAspNetCore.Entities;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace SampleWebApiAspNetCore.IntegrationTests
{
    public class FoodsTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public FoodsTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetFoodsItemsAsync()
        {
            // Arrange
            var request = "/api/v1/foods";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

       [Fact]
       public async Task TestRequestFoodsItemAsync()
       {
            // Arrange
            var request = new
            {
                Url = "/api/v1/foods/2",
                Body = new
                {
                    id = 2,
                    name = "nametest",
                    type = "Main",
                    calories = 1100,
                    created = "2020-01-07T22:58:30.9586201"
                }
            };

           // Act
           var response = await Client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));
           var responseString = await response.Content.ReadAsStringAsync();

           // Assert
           response.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            /*var fooditem = JsonConvert.DeserializeObject<IEnumerable<FoodEntity>>(responseString);
            Assert.Contains(fooditem, p => p.Name == "test");
            */
            responseString.FirstOrDefault(name => name.ToString().Equals("nametest"));

        }
        /*
      [Fact]
      public async Task TestPutStockItemAsync()
      {
          // Arrange
          var request = new
          {
              Url = "/api/v1/Warehouse/StockItem/1",
              Body = new
              {
                  StockItemName = string.Format("USB anime flash drive - Vegeta {0}", Guid.NewGuid()),
                  SupplierID = 12,
                  Color = 3,
                  UnitPrice = 39.00m
              }
          };

          // Act
          var response = await Client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

          // Assert
          response.EnsureSuccessStatusCode();
      }

      [Fact]
      public async Task TestDeleteStockItemAsync()
      {
          // Arrange

          var postRequest = new
          {
              Url = "/api/v1/Warehouse/StockItem",
              Body = new
            {
                "id": 5,
                "name": "string",
                "type": "string",
                "calories": 0,
                "created": "2020-01-13T04:43:37.358Z"
            }
          };


          // Act
          var postResponse = await Client.PostAsync(postRequest.Url, ContentHelper.GetStringContent(postRequest.Body));
          var jsonFromPostResponse = await postResponse.Content.ReadAsStringAsync();

          var singleResponse = JsonConvert.DeserializeObject<SingleResponse<StockItem>>(jsonFromPostResponse);

          var deleteResponse = await Client.DeleteAsync(string.Format("/api/v1/Warehouse/StockItem/{0}", singleResponse.Model.StockItemID));

          // Assert
          postResponse.EnsureSuccessStatusCode();

          Assert.False(singleResponse.DidError);

          deleteResponse.EnsureSuccessStatusCode();
      }*/
    }
}