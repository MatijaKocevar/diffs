using System;
using AutoMapper;
using base64diffs.Data;
using base64diffs.DTOs;
using base64diffs.Models;
using Microsoft.AspNetCore.Mvc;

namespace base64diffs.Controllers
{

    [Route("/v1/diff")] //controller level route
    [ApiController] //gives default behaviours
    public class PairsController : ControllerBase
    {
        private readonly IDiffsRepo _repo;

        public PairsController(IDiffsRepo repository)
        {
            _repo = repository;
        }

        // v1/diff/{id}/left
        [HttpPut("{id}/left")]
        public ActionResult UpdateLeft(int id, LeftCreateDTO input)
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
        public ActionResult UpdateRight(int id, RightCreateDTO input)
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