using System.Net.Http;
using System;
using Xunit;
using RA;
//using System.Net;


namespace test
{
    public class UnitTest1
    {
        [Fact]
        public void GetEmptyEndPointTest()
        {
            new RestAssured()
            .Given()
              .Name("Test Empty Get")
              .Header("Content-Type","application/json")
              .Header("Accept-Encoding","utf-8")
            .When()
               .Get("http://localhost:5000/redirect/")
               .Then()
               .TestStatus("test Empty Get",r => r==400)
               .AssertAll();
        }
       
        

        // }

        // public void PostEmptyEndPointTest(){
            
        // }

        // public void KhafanTest(){
        //     Url url = new Url();
        //     url.LongUrl="http://www.google.com";
        //     HttpResponseMessage response = await client.PostAsJsonAsync(
        //      "http://localhost:5000/urls", url);
        //     response.EnsureSuccessStatusCode();

    // return URI of the created resource.
            // response.body;
            //JObje

            // HttpClient client =new HttpClient();
            // Url url =null;
            //  HttpResponseMessage response = await client.GetAsync();
            // if (response.IsSuccessStatusCode)
            // {
            //     product = await response.Content.ReadAsAsync<Product>(http://localhost:5000/);
            // }


        
    }
}
