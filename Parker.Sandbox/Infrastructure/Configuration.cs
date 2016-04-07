using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Xml;

namespace Parker.Sandbox.Infrastructure
{
	public class Configuration : IConfigurationSectionHandler
	{
		static Configuration current = ConfigurationManager.GetSection("sandbox") as Configuration;
		public static Configuration Current { get { return current; } }

		public object Create(object parent, object configContext, XmlNode section)
		{
			return new Configuration();
		}
	}
}