using System.Linq;
using urlShortner.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http;
using System.Web;
namespace urlShortner.Controllers
{
    [Route("/redirect/{*shortUrl}")]
    public class RedirectController:Controller
    {
        private readonly AppDbContext _context;
        public RedirectController(AppDbContext context){
            _context=context;
        }

        [HttpGet]
        public ActionResult GetLongUrl(string shortUrl){
            //return Ok();
            if(shortUrl==null){
                return BadRequest();
            }
            char[] chars =shortUrl.ToCharArray();
            if(chars.Length!=8){
                return BadRequest();
            }
            for(int i=0;i<chars.Length;i++){
                if((int)chars[i]<=57&&(int)chars[i]>=48){
                    return BadRequest();
                }
            }
            var url =_context.urls.Find(shortUrl);
            if(url==null){
              
                return NotFound();
            }
            return Redirect(url.LongUrl);
           // return Ok();
        }
        
    }
}