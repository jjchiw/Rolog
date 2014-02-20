/*
 * Created by SharpDevelop.
 * User: JuanJ
 * Date: 2/19/2014
 * Time: 7:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Rolog.Models.Helpers
{
	/// <summary>
	/// Description of IUserDenormalized.
	/// </summary>
	public interface IUserDenormalized
	{
		string Id { get; set; }
		string UserName { get; set; }
		string Email { get; set; }
	}
}
