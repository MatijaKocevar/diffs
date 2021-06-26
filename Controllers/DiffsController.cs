using System;
using base64diffs.Data;
using base64diffs.Models;
using Microsoft.AspNetCore.Mvc;

namespace base64diffs.Controllers
{

    [Route("/v1/diff")] //controller level route
    [ApiController] //gives default behaviours
    public class DiffsController : ControllerBase
    {
        private readonly IDiffsRepo _rep;

        public DiffsController(IDiffsRepo repository)
        {
            _rep = repository;
        }

        // v1/diff/{id}
        [HttpGet("{id}")]
        public ActionResult GetDiffs(int id)
        {
            //Get data from database
            var pair = _rep.GetPair(id);
            //check if data is there
            if (pair == null || pair.Left == null || pair.Right == null)
            {
                //if pair is not found or if one of the pairs is missing..return status 404
                return NotFound();
            }

            //get diffs from data
            var response = _rep.GetDiffs(pair);
            //Check if diffs are found...if they're not only return response type
            if (response.diffs == null)
            {
                ResultType res = new ResultType();
                res.diffResultType = response.diffResultType;
                return Ok(res);
            }

            //returns Result type and diffs
            return Ok(response);
        }

    }
}