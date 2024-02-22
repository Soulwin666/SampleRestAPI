using Microsoft.AspNetCore.Mvc;

namespace SampleRestAPI.Controllers
{
    public interface IBook
    {
        IActionResult GetBooksWithoutParams();

        IActionResult GetBooksWithParams(long id);
    }
}
