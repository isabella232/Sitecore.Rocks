// � 2015-2016 Sitecore Corporation A/S. All rights reserved.

using System;
using Sitecore.Configuration;
using Sitecore.Data.Serialization;
using Sitecore.Diagnostics;

namespace Sitecore.Rocks.Server.Requests.Serialization
{
    public class UpdateDatabase
    {
        protected bool ForceUpdate { get; set; }

        [NotNull]
        public string Execute([NotNull] string databaseName)
        {
            Assert.ArgumentNotNull(databaseName, nameof(databaseName));

            var database = Factory.GetDatabase(databaseName);
            if (database == null)
            {
                throw new Exception("Database not found");
            }

            var item = database.GetRootItem();
            if (item == null)
            {
                throw new Exception("Item not found");
            }

            VersionSpecific.Services.SerializationService.UpdateTree(item.Uri.ToString(), ForceUpdate);
            return string.Empty;
        }
    }
}
