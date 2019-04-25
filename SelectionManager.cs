using Autodesk.Revit.UI;

namespace Revit.SDK.Entools.Ribbon.CS
{
    internal class SelectionManager
    {
        private ExternalCommandData revit;

        public SelectionManager(ExternalCommandData revit)
        {
            this.revit = revit;
        }
    }
}