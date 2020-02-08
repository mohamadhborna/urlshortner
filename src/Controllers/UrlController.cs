using System.Text.RegularExpressions;
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
        private readonly AppDbContext _context;
        public UrlController(AppDbContext context){
            _context=context;
        }

        [HttpPost]
        public ActionResult <string> PostUrl([FromBody]Url url){
             if(url==null){
                return BadRequest();
            }
            if(IsCorrectUrl(url)){
             url.ShortUrl=ShortUrlBuilder(url);
            _context.urls.Add(url);
            _context.SaveChanges();
            return url.ShortUrl;
            }
            else{

                return BadRequest();
            }


        }
        public string  ShortUrlBuilder(Url url){
            int startIndex=65;
            int endIndex=90;
            Random randomGenerator=new Random();
            string shortUrl="";
            for(int i=0;i<8;i++){
                 int randomAsciCode =randomGenerator.Next(startIndex,endIndex);
                 char character=Convert.ToChar(randomAsciCode);
                 shortUrl=shortUrl+character.ToString();
            }
            return shortUrl;
        }
        public bool IsCorrectUrl(Url url){
  
            Regex regex =new Regex(@"((www\.|(http|https|ftp|news|file)+\:\/\/)[_.a-z0-9-]+\.[a-z0-9\/_:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])");
            Match match= regex.Match(url.LongUrl);
            if(match.Success){
                return true;
            }
            else{
                return false;
            }
        }
        
    }
}