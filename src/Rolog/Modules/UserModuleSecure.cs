/*
 * Created by SharpDevelop.
 * User: JuanJ
 * Date: 2/20/2014
 * Time: 8:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Nancy.Security;

namespace Rolog.Modules
{
	/// <summary>
	/// Description of UserModuleSecure.
	/// </summary>
	public class UserModuleSecure : RavenModule
	{
		public UserModuleSecure() : base ("users")
		{
			this.RequiresAuthentication();
			
			Get["/{id}"] = _ =>
			{
				return View["index.html", Context.CurrentUser];
			};
		}
	}
}
