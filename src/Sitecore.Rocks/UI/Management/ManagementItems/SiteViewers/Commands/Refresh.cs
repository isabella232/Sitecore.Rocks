// � 2015-2016 Sitecore Corporation A/S. All rights reserved.

using Sitecore.Rocks.Commands;
using Sitecore.Rocks.Data;

namespace Sitecore.Rocks.UI.Management.ManagementItems.SiteViewers.Commands
{
    [Command]
    public class Refresh : CommandBase
    {
        public Refresh()
        {
            Text = Resources.Refresh;
            Group = "Refresh";
            SortingValue = 9000;
            Icon = new Icon("Resources/16x16/refresh.png");
        }

        public override bool CanExecute(object parameter)
        {
            return parameter is SiteViewerContext;
        }

        public override void Execute(object parameter)
        {
            var context = parameter as SiteViewerContext;
            if (context == null)
            {
                return;
            }

            context.SiteViewer.Refresh();
        }
    }
}
