using Microsoft.AspNetCore.Mvc;


namespace PSG_Webapp.Controllers
{
    public class VideoController : Controller
    {
        public IActionResult Index(string name)
        {
            var fullpath = "C:/Users/Trevor/Documents/GitHub/Glimesh_apiWebapp/WebApplication1/wwwroot/Video/"+name;
            return PhysicalFile(fullpath,"application/octet-stream", enableRangeProcessing: true);
        }
    }
}
