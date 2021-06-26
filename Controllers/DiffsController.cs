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
        // v1/diff/{id}
        [HttpGet("{id}")]
        public ActionResult GetDiffs(int id)
        {
            //Get data from database
            var pair = _rep.GetPair(id);
            //check if data is there
            if (pair == null || pair.Left == null || pair.Right == null)
            {
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

            return Ok(response);
        }

        // v1/diff/{id}/left
        [HttpPut("{id}/left")]
        public ActionResult UpdateLeft(int id, Left input)
        {
            if (_rep.PairDoesExist(id))
            {
                _rep.GetPair(id).Left = input.data;
                _rep.SaveChanges();
            }
            else
            {
                Pair pair = new Pair();
                pair.Id = id;
                pair.Left = input.data;
                _rep.CreatePair(pair);
                _rep.SaveChanges();
            }

            return Created("/v1/diff/" + id.ToString(), _rep.GetPair(id));
        }

        // v1/diff/{id}/right
        [HttpPut("{id}/right")]
        public ActionResult UpdateRight(int id, Right input)
        {
            if (_rep.PairDoesExist(id))
            {
                _rep.GetPair(id).Right = input.data;
                _rep.SaveChanges();
            }
            else
            {
                Pair pair = new Pair();
                pair.Id = id;
                pair.Right = input.data;
                _rep.CreatePair(pair);
                _rep.SaveChanges();
            }

            return Created("/v1/diff/" + id.ToString(), _rep.GetPair(id));
        }

    }
}