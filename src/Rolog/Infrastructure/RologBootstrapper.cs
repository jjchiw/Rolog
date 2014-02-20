/*
 * Created by SharpDevelop.
 * User: JuanJ
 * Date: 2/19/2014
 * Time: 7:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;
using Raven.Abstractions.Data;
using Raven.Client;
using Raven.Client.Document;

namespace Rolog.Infrastructure
{
	/// <summary>
	/// Description of RologBootstrapper.
	/// </summary>
	public class RologBootstrapper : DefaultNancyBootstrapper
	{

		protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
		{
			base.ConfigureRequestContainer(container, context);


			// Here we register our user mapper as a per-request singleton.
			// As this is now per-request we could inject a request scoped
			// database "context" or other request scoped services.

			var parser = ConnectionStringParser<RavenConnectionStringOptions>.FromConnectionStringName("RavenDB");
			parser.Parse();

			var documentStore = new DocumentStore
			{
				ApiKey = parser.ConnectionStringOptions.ApiKey,
				Url = parser.ConnectionStringOptions.Url
			};

			documentStore.Initialize();

			container.Register<IDocumentStore>(documentStore);
			container.Register<IUserMapper, UserMapper>();

			context.Items["RavenDocumentStore"] = documentStore;
		}

		protected override void RequestStartup(TinyIoCContainer requestContainer, IPipelines pipelines, NancyContext context)
		{
			// At request startup we modify the request pipelines to
			// include forms authentication - passing in our now request
			// scoped user name mapper.
			//
			// The pipelines passed in here are specific to this request,
			// so we can add/remove/update items in them as we please.
			var formsAuthConfiguration =
				new FormsAuthenticationConfiguration()
				{
					RedirectUrl = "/",
					UserMapper = requestContainer.Resolve<IUserMapper>(),
				};
			FormsAuthentication.Enable(pipelines, formsAuthConfiguration);
		}
		
		protected override void ConfigureConventions(NancyConventions conventions)
		{
			base.ConfigureConventions(conventions);

			conventions.StaticContentsConventions.Add(
				StaticContentConventionBuilder.AddDirectory("css", @"Content/css")
			);

			conventions.StaticContentsConventions.Add(
				StaticContentConventionBuilder.AddDirectory("js", @"Content/js")
			);
			
			conventions.StaticContentsConventions.Add(
				StaticContentConventionBuilder.AddDirectory("img", @"Content/img")
			);
		}
	}
}
