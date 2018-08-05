using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
	public class UserController : ApiController
	{

		private readonly IUserManager _usermanager;

		public UserController(IUserManager _usermanager)
		{

		}


		// GET: api/User
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET: api/User/5
		public IHttpActionResult Get(int id)
		{
			return Ok();
		}

		// POST: api/User
		public IHttpActionResult Post([FromBody]string value)
		{
			return Ok();
		}

		// PUT: api/User/5
		public IHttpActionResult Put(int id, [FromBody]string value)
		{
			return Ok();
		}

		// DELETE: api/User/5
		public IHttpActionResult Delete(int id)
		{
			return Ok();
		}
	}
}
