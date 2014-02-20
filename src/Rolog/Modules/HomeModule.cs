/*
 * Created by SharpDevelop.
 * User: JuanJ
 * Date: 2/19/2014
 * Time: 6:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Rolog.Modules
{
	/// <summary>
	/// Description of HomeModule.
	/// </summary>
	public class HomeModule : RavenModule
	{
		public HomeModule() : base("/")
		{
			Get["/"] = _ =>
			{
				var username = "";
				var isLoggedIn = false;
				
				var user = Context.CurrentUser;
				if (user != null)
				{
					isLoggedIn = true;
					username = Context.CurrentUser.UserName;
				}
					
				
				return View["index.html", new {
					UserName = username,
					IsLoggedIn = isLoggedIn
				}];
			};
		}
	}
}
