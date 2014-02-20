/*
 * Created by SharpDevelop.
 * User: JuanJ
 * Date: 2/19/2014
 * Time: 7:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Rolog.Models.Helpers
{
	/// <summary>
	/// Description of UserDenormalized.
	/// </summary>
	public class UserDenormalized<T> where T : IUserDenormalized
	{
		public string Id { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }

		public static implicit operator UserDenormalized<T>(T doc)
		{
			return new UserDenormalized<T>
			{
				Id = doc.Id,
				UserName = doc.UserName,
				Email = doc.Email
			};
		}
	}
}
