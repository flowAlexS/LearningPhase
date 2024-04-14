using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        public ActionResult GetFile(string fileId)
        {
            throw new NotImplementedException();
        }
    }
}
