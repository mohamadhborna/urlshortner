using urlShortner.models;
using Microsoft.AspNetCore.Mvc;
namespace urlShortner.Controllers
{
    [Route("/")]
    public class RedirectController:Controller
    {
        private readonly AppDbContext _context;
        public RedirectController(AppDbContext context){
            _context=context;
        }

        [HttpGet]
        public ActionResult <string> GetLongUrl(string shortUrl){
            //var url=
            var url =_context.urls.Find(shortUrl);
            return Redirect(url.LongUrl);
        }
        
    }
}