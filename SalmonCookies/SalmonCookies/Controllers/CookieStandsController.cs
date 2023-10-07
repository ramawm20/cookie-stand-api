using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalmonCookies.Data;
using SalmonCookies.DTOs;
using SalmonCookies.Interfaces;
using SalmonCookies.Models;

namespace SalmonCookies.Controllers
{
    [Route("api")]
    [ApiController]
    public class CookieStandsController : ControllerBase
    {
        private readonly ICookieStands _coookiestands;

        public CookieStandsController(ICookieStands coookiestands)
        {
            _coookiestands = coookiestands;
        }

		// GET: api/CookieStands
		[HttpGet("Cookiestands")]
		public async Task<List<CookieStands>> GetAllCookiestands()
        {
            return await _coookiestands.GetAll();
         
            
            
        }

        // GET: api/CookieStands/5
        [HttpGet("CookieStands/{id}")]
        public async Task<ActionResult<CookieStands>> GetById(int id)
        {
            return await _coookiestands.GetById(id);
        }

		// POST: api/CookieStands
		[HttpPost("CookieStands")]
		public async Task<ActionResult> Post(CookieStandsDTO cookieStandsDTO)
		{
			 await _coookiestands.Post(cookieStandsDTO);
			return Ok();
		}

		// PUT: api/CookieStands/5
		[HttpPut("CookieStands/{id}")]
		public async Task<ActionResult<CookieStands>> put(int id, CookieStandsDTO cookieStandsDTO)
		{
			await _coookiestands.Put(id, cookieStandsDTO);
			return Ok();
		}
		
		// DELETE: api/CookieStands/5
	    [HttpDelete("CookieStands/{id}")]
		
		public async Task<IActionResult> Delete(int id)
		{
			await _coookiestands.Delete(id);
			return NoContent();
		}
		
	    
		
	}
}