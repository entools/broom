using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Entools.View;
using Entools.ViewModel;
using EntoolsBroomRevit.Model;

namespace Entools.Model
{
    /// <summary>
    /// Implements the Revit add-in interface IExternalCommand,Move walls, Y direction
    /// </summary>
    /// 

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]

    public class Entools : IExternalCommand
    {
        public Result Execute(ExternalCommandData revit,
            ref string message, 
            ElementSet elements)
        {

            try
            {
                Main main = new Main();
                main.MainClass(revit);

                return Autodesk.Revit.UI.Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = ex.ToString();
                return Autodesk.Revit.UI.Result.Failed;
            }


        }
    }
}