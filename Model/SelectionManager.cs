using Autodesk.Revit.UI;

namespace EntoolsBroom.Model
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