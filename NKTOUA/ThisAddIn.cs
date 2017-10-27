using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace NKTOUA
{
    public partial class ThisAddIn
    {
        private NKTOUA.NKTOUA_Ribbon _ribbon = null;


        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            NKTOUA_Application.Instance.olApplication = this.Application;
            NKTOUA_Application.Instance.Ribbon = _ribbon;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see http://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            if (null == _ribbon)
            {
                _ribbon = new NKTOUA_Ribbon();
                _ribbon.Application = NKTOUA_Application.Instance;
            }

            return _ribbon;
        }
        #endregion
    }
}
