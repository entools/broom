using Autodesk.Revit.UI;

namespace Entools.Model
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