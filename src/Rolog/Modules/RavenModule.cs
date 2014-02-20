/*
 * Created by SharpDevelop.
 * User: JuanJ
 * Date: 2/19/2014
 * Time: 6:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Nancy;
using Raven.Client;

namespace Rolog.Modules
{
	/// <summary>
	/// Description of RavenModule.
	/// </summary>
	public class RavenModule : NancyModule
	{
		protected IDocumentSession RavenSession;

		protected IDocumentStore RavenDocumentStore
		{
			get
			{
				return Context.Items["RavenDocumentStore"] as IDocumentStore;
			}
		}

		public RavenModule(string path) : base(path)
		{
			this.Before.AddItemToEndOfPipeline(ctx =>
			{
				RavenSession = RavenDocumentStore.OpenSession();
				return null;
			});

			this.After.AddItemToEndOfPipeline(ctx =>
			{
				if (RavenSession != null)
				{
					RavenSession.SaveChanges();
					RavenSession.Dispose();
				}

			});


		}

		public RavenModule() : this("")
		{
		}
	}

}
