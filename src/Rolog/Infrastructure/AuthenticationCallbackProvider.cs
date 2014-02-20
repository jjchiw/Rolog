/*
 * Created by SharpDevelop.
 * User: JuanJ
 * Date: 2/20/2014
 * Time: 8:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.SimpleAuthentication;
using Raven.Client;
using Rolog.Models;
using Rolog.Models.ViewModel;
using System.Linq;

namespace Rolog.Infrastructure
{
	/// <summary>
	/// Description of AuthenticationCallbackProvider.
	/// </summary>
	public class AuthenticationCallbackProvider : IAuthenticationCallbackProvider
    {
        public dynamic Process(NancyModule nancyModule, AuthenticateCallbackData model)
        {
        	var email = model.AuthenticatedClient.UserInformation.Email;
			User user = null;
			var documentStore = nancyModule.Context.Items["RavenDocumentStore"] as IDocumentStore;
			using(var session = documentStore.OpenSession())
			{
				user = session.Query<User>()
							  .FirstOrDefault(x => x.Email == email);

				if (user == null)
				{
					user = new User
					{
						Email = email,
						UserName = email,
						Guid = Guid.NewGuid()
					};
	
					session.Store(user);
					session.SaveChanges();
				}
				
				
			}

			return nancyModule.LoginAndRedirect(user.Guid, DateTime.UtcNow.AddDays(7), string.Format("/{0}", user.Id));
        }

        public dynamic OnRedirectToAuthenticationProviderError(NancyModule nancyModule, string errorMessage)
        {
            var model = new IndexViewModel
            {
                ErrorMessage = errorMessage
            };

            return nancyModule.View["index", model];
        }
    }

}
