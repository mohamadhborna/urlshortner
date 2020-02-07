using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using urlShortner.models;
namespace urlShortner.Controllers
{
    [Route("/urls")]
    [ApiController]
    public class UrlController:Controller
    {
        // [HttpGet]
        // public ActionResult <String> Get(){
        //     return "jafar getter";
        // }
        private readonly AppDbContext _context;
        public UrlController(AppDbContext context){
            _context=context;
        }

        // [HttpGet]
        // public ActionResult <string> Get(){
        //    Url url = Request.ToString();

        // }


        [HttpPost]
        public ActionResult <string> getUrl([FromBody]Url url){
            //return "asghar";
            url.ShortUrl=ShortUrlBuilder(url);
            _context.urls.Add(url);
            _context.SaveChanges();
            return url.ShortUrl;
           // return "asghar";
        }

        public string  ShortUrlBuilder(Url url){
            int startIndex=65;
            int endIndex=90;
            Random randomGenerator=new Random();
            string shortUrl="";
            for(int i=0;i<8;i++){
                 int randomAsciCode =randomGenerator.Next(startIndex,endIndex);
                 char character=Convert.ToChar(randomAsciCode);
                 //shortUrl=shortUrl.Concat(character.ToString()).ToString();
                 shortUrl=shortUrl+character.ToString();
            }
            for(int i=0;i<8;i++){
                 int randomAsciCode =randomGenerator.Next(startIndex+32,endIndex+32);
                 char character=Convert.ToChar(randomAsciCode);
                 //shortUrl=shortUrl.Concat(character.ToString()).ToString();
                 shortUrl=shortUrl+character.ToString();
            }

            return shortUrl;
        }
        
    }
}