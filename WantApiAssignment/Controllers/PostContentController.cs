using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WantApiAssignment.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PostContentController : ControllerBase
    {
        private readonly IPostContentRepository _postContentRepository;
        public PostContentController(IPostContentRepository postContentRepository)
        {
            _postContentRepository = postContentRepository;
        }

        [HttpGet]
        public ActionResult GetContentList(int PageNumber=1, int RecordsPerPage = 10)
        {
            try
            {
                var contentlist = _postContentRepository.GetContents(PageNumber, RecordsPerPage);
                return Ok(contentlist);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }

        }
        [HttpGet]
        public ActionResult GetContentById(int id)
        {
            try
            {
                var contentlist = _postContentRepository.ContentById(id);
                return Ok(contentlist);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }

        }
        [HttpPost]
        public ActionResult AddContent(PostContentRequest postContentRequest)
        {
            try
            {
                var addContent = _postContentRepository.AddContent(postContentRequest);
                return Ok(addContent);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }

        }
    }
}

