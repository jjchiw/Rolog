/*
 * Created by SharpDevelop.
 * User: JuanJ
 * Date: 2/19/2014
 * Time: 8:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Nancy.Authentication.Forms;
using Raven.Client;
using Rolog.Models;
using System.Linq;

namespace Rolog.Infrastructure
{
	/// <summary>
	/// Description of UserMapper.
	/// </summary>
	public class UserMapper : IUserMapper
	{
		private IDocumentStore _documentStore;

		public UserMapper(IDocumentStore documentStore)
		{
			_documentStore = documentStore;
		}
		#region IUserMapper Members

		public Nancy.Security.IUserIdentity GetUserFromIdentifier(Guid identifier, Nancy.NancyContext context)
		{
			using (IDocumentSession session = _documentStore.OpenSession())
			{
				var user = session.Query<User>().FirstOrDefault(x => x.Guid == identifier);

				return user;
			}
		}
		
		#endregion
	}
}
