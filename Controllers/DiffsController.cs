using System;
using System.Collections.Generic;
using base64diffs.Data;
using base64diffs.Models;
using Microsoft.AspNetCore.Mvc;

namespace base64diffs.Controllers
{
    [Route("/v1/diff")]
    [ApiController]
    public class DiffsController : ControllerBase
    {
        private readonly IPairsRepo _rep;

        public DiffsController(IPairsRepo repository)
        {
            _rep = repository;
        }

        // v1/diff/1
        [HttpGet("{id}")]
        public ActionResult GetDiffs(int id)
        {
            var response = _rep.GetDiffs(id);

            if (response.diffs == null)
            {
                ResultType res = new ResultType();
                res.diffResultType = response.diffResultType;
                return Ok(res);
            }

            return Ok(response);
        }

        // v1/diff/1/left
        [HttpPut("{id}/left")]
        public ActionResult PutLeft(int id)
        {
            return Ok();
        }

        // v1/diff/1/right
        [HttpPut("{id}/right")]
        public ActionResult PutRight(int id)
        {
            return Ok();
        }

    }
}