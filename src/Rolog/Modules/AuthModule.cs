/*
 * Created by SharpDevelop.
 * User: JuanJ
 * Date: 2/20/2014
 * Time: 9:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Nancy;
using Nancy.Authentication.Forms;

namespace Rolog.Modules
{
	/// <summary>
	/// Description of AuthModule.
	/// </summary>
	public class AuthModule : NancyModule
	{
		public AuthModule() : base("auth")
		{
			Get["/logout"] = parameters =>
			{
				return this.LogoutAndRedirect("/");
			};

		}
	}
}
