using System;
using System.Collections.Generic;
using AutoMapper;
using Diffing.Data;
using Diffing.DTOs;
using Diffing.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diffing.Controllers
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

        // v1/diff
        [HttpGet]
        public ActionResult<IEnumerable<Pair>> GetAllData()
        {
            if (_repo.DoesDataExist() == false)
                return NotFound();

            return Ok(_repo.GetAllData());
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


        // v1/diff/{id}/left
        [HttpPut("{id}/left")]
        public ActionResult UpdateLeft(int id, Base64Input input)
        {
            //checks if the input data is a valid BASE64 encoded string
            try
            {
                byte[] T = Convert.FromBase64String(input.data);
            }
            catch (FormatException)
            {
                return BadRequest("Not a BASE64 encoded string");
            }

            //checks if pair exists in the database 
            if (_repo.PairDoesExist(id))
            {
                //updates data and saves changes to database
                _repo.GetPair(id).Left = input.data;
                _repo.SaveChanges();
            }
            else
            {
                //creates new pair and saves changes to database
                Pair pair = new Pair();
                pair.Id = id;
                pair.Left = input.data;
                _repo.CreatePair(pair);
                _repo.SaveChanges();
            }

            //returns status 201 (with path to get to new element and element itself)
            return Created("/v1/diff/" + id.ToString(), _repo.GetPair(id));
        }

        // v1/diff/{id}/right
        [HttpPut("{id}/right")]
        public ActionResult UpdateRight(int id, Base64Input input)
        {
            //checks if the input data is a valid BASE64 encoded string
            try
            {
                byte[] T = Convert.FromBase64String(input.data);
            }
            catch (FormatException)
            {
                return BadRequest("Not a BASE64 encoded string");
            }

            //checks if pair exists in the database 
            if (_repo.PairDoesExist(id))
            {
                //updates data and saves changes to database
                _repo.GetPair(id).Right = input.data;
                _repo.SaveChanges();
            }
            else
            {
                //creates new pair and saves changes to database
                Pair pair = new Pair();
                pair.Id = id;
                pair.Right = input.data;
                _repo.CreatePair(pair);
                _repo.SaveChanges();
            }

            //returns status 201 (with path to get to new element and element itself)
            return Created("/v1/diff/" + id.ToString(), _repo.GetPair(id));
        }

    }

}