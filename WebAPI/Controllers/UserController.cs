﻿using BusinessLayer;
using DataAccess.Models;
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

		public UserController(IUserManager usermanager)
		{
			_usermanager = usermanager;
		}


		// GET: api/User
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET: api/User/5
		public IHttpActionResult Get(int id)
		{
			try
			{
				if (_usermanager.Read(id) != null)
					return Ok();
				else
					return NotFound();
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		// POST: api/User
		public IHttpActionResult Post(User user)
		{
			return Ok(_usermanager.Create(user));
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
