using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using System.ComponentModel;

// TODO:  Follow these steps to enable the Ribbon (XML) item:

// 1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new Ribbon();
//  }

// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


namespace NKTOUA
{
    [ComVisible(true)]
    public class Ribbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        private static Ribbon _instance = null;
        public delegate void RibbonControlCommandEventHandler(Office.IRibbonControl control);
        public delegate string RibbonControlGetLabelEventHandler(Office.IRibbonControl control);
        public delegate bool RibbonControlGetEnableEventHandler(Office.IRibbonControl control);
        public delegate void RibbonLoad(Office.IRibbonUI ribbonUI);
        public event RibbonControlCommandEventHandler About;
        public event RibbonControlCommandEventHandler Settings;
        public event RibbonControlCommandEventHandler Categorize;
        public event RibbonControlGetLabelEventHandler AboutLabel;
        public event RibbonControlGetLabelEventHandler CategorizeLabel;
        public event RibbonControlGetLabelEventHandler SettingsLabel;
        public event RibbonControlGetEnableEventHandler AboutEnable;
        public event RibbonControlGetEnableEventHandler CategorizeEnable;
        public event RibbonControlGetEnableEventHandler SettingsEnable;
        public event RibbonLoad Load;

        private const string ABOUT_BUTTON_ID = "NKTOUA.dropDown.About";
        private const string SETTINGS_BUTTON_ID = "NKTOUA.dropDown.Settings";
        private const string CATEGORIZE_BUTTON_ID = "NKTOUA.dropDown.Categorize";

        public static Ribbon Instance
        {
            get { return _instance; }
        }

        public Ribbon()
        {
            _instance = this;
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("NKTOUA.Ribbon.xml");
        }

        #endregion

        internal class PictureConverter : AxHost
        {
            private PictureConverter() : base(String.Empty) { }

            static public stdole.IPictureDisp ImageToPictureDisp(System.Drawing.Image image)
            {
                return (stdole.IPictureDisp)GetIPictureDispFromPicture(image);
            }

            static public stdole.IPictureDisp IconToPictureDisp(System.Drawing.Icon icon)
            {
                return ImageToPictureDisp(icon.ToBitmap());
            }

            static public System.Drawing.Image PictureDispToImage(stdole.IPictureDisp picture)
            {
                return GetPictureFromIPicture(picture);
            }
        }

        public stdole.IPictureDisp GetImage(string imageName)
        {
            switch (imageName)
            {
                case "About":
                    return PictureConverter.IconToPictureDisp(Properties.Resources.About);
                case "Settings":
                    return PictureConverter.IconToPictureDisp(Properties.Resources.Settings);
                case "Categorize":
                    return PictureConverter.IconToPictureDisp(Properties.Resources.Categorize);
                default:
                    return null;
            }
        }

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit http://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
            if (null != Load)
            {
                Load(ribbonUI);
            }
        }

        public string OnGetLabel(Office.IRibbonControl control)
        {
            if (null != control)
            {
                switch (control.Id)
                {
                    case ABOUT_BUTTON_ID:
                        if (null != AboutLabel)
                        {
                            return AboutLabel(control);
                        }
                        break;
                    case SETTINGS_BUTTON_ID:
                        if (null != SettingsLabel)
                        {
                            return SettingsLabel(control);
                        }
                        break;
                    case CATEGORIZE_BUTTON_ID:
                        if (null != CategorizeLabel)
                        {
                            return CategorizeLabel(control);
                        }
                        break;
                    default:
                        return "";
                }
            }

            return "";
        }

        public void OnCommand(Office.IRibbonControl control)
        {
            if (null != control)
            {
                switch (control.Id)
                {
                    case ABOUT_BUTTON_ID:
                        if (null != About)
                        {
                            About(control);
                        }
                        break;
                    case SETTINGS_BUTTON_ID:
                        if (null != Settings)
                        {
                            Settings(control);
                        }
                        break;
                    case CATEGORIZE_BUTTON_ID:
                        if(null != Categorize)
                        {
                            Categorize(control);
                        }
                        break;
                }
            }
        }

        public bool OnGetEnable(Office.IRibbonControl control)
        {
            if (null != control)
            {
                switch (control.Id)
                {
                    case ABOUT_BUTTON_ID:
                        if (null != AboutEnable)
                        {
                            return AboutEnable(control);
                        }
                        break;
                    case SETTINGS_BUTTON_ID:
                        if (null != SettingsEnable)
                        {
                            return SettingsEnable(control);
                        }
                        break;
                    case CATEGORIZE_BUTTON_ID:
                        if (null != CategorizeEnable)
                        {
                            return CategorizeEnable(control);
                        }
                        break;
                    default:
                        return false;
                }
            }

            return false;
        }
        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
