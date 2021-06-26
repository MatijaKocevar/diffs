using AutoMapper;
using base64diffs.Data;
using base64diffs.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace base64diffs.Controllers
{

    [Route("/v1/diff")] //controller level route
    [ApiController] //gives default behaviours
    public class DiffsController : ControllerBase
    {
        private readonly IDiffsRepo _repo;
        private readonly IMapper _mapper;

        public DiffsController(IDiffsRepo repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        // v1/diff/{id}
        [HttpGet("{id}")]
        public ActionResult GetResults(int id)
        {
            //Get data from database by id
            var pair = _repo.GetPair(id);
            //check if data is there
            if (pair == null || pair.Left == null || pair.Right == null)
            {
                //if pair is not found or if one of the pairs is missing..return status 404
                return NotFound();
            }

            //calculate diffs from given data
            var response = _repo.GetResults(pair);
            //Check if diffs are found...if they're not only return response type and status 200
            if (response.diffResultType == "SizeDoNotMatch" || response.diffResultType == "Equals")
            {
                //uses DTO's to return only ResultType..without empty diffs[...] + 200 code
                return Ok(_mapper.Map<ResultTypeDTO>(response));
            }

            //returns Result type and diffs + status 200
            return Ok(response);
        }

    }
}