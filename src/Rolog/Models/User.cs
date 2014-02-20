/*
 * Created by SharpDevelop.
 * User: JuanJ
 * Date: 2/19/2014
 * Time: 7:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Nancy.Security;
using Rolog.Models.Helpers;

namespace Rolog.Models
{
	/// <summary>
	/// Description of User.
	/// </summary>
	public class User : IUserIdentity, IUserDenormalized
	{
		public string Id { get; set; }
		public Guid Guid { get; set; }
		public string Email { get; set; }

		public string Token { get; set; }

		#region IUserIdentity Members

		public string UserName { get; set; }
		public IEnumerable<string> Claims { get; set; }

		#endregion
	}
}
