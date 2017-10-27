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
using Outlook = Microsoft.Office.Interop.Outlook;


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
    public class CmdUI : IDisposable
    {
        public string Label { get; set; }
        public bool Visible { get; set; }
        public bool Enable { get; set; }
        public string Description { get; set; }
        public string Id { get; private set; }
        public string KeyTip { get; set; }
        public string ScreenTip { get; set; }
        public string SuperTip { get; set; }
        public CmdUI(string id)
        {
            Id = id;
        }

        public void Dispose()
        {
            
        }

        ~CmdUI()
        {
            Dispose();
        }
    }

    public class NKTOUA_Folder : IDisposable
    {
        private Outlook.Folder _folder = null;

        public Outlook.Folder Origin
        {
            get { return _folder; }
        }
        public string Category { get; set; }
        public NKTOUA_Folder(Outlook.Folder folder)
        {
            _folder = folder;
        }

        public void Dispose()
        {
            
        }
        ~NKTOUA_Folder()
        {
            Dispose();
        }
    }

    [ComVisible(true)]
    public class NKTOUA_Ribbon : Office.IRibbonExtensibility
    {
        private const string NKTOUA_GROUP = "NKTOUA";
        private const string NKTOUA_DROPDOWN_MENU = "NKTOUA.dropDown";
        private const string NKTOUA_SETTINGS_BUTTON = "NKTOUA.dropDown.Settings";
        private const string NKTOUA_CATEGORIZE_BUTTON = "NKTOUA.dropDown.Categorize";
        private const string NKTOUA_MOVEALLTOROOT_BUTTON = "NKTOUA.dropDown.MoveAllToRoot";

        public delegate void UpdateCommandUIEvent(CmdUI ui);
        public delegate void CommandUIEvent(string id, object args);
        public event UpdateCommandUIEvent UpdateCommandUI;
        public event CommandUIEvent CommandUI;

        private enum WalkDirEvents { None=0, MoveAllToRoot_Preparation, MoveAllToRoot, Grouping_Preparation, Grouping}

        public NKTOUA_Application Application { get; set; }

        public NKTOUA_Ribbon()
        {
            this.UpdateCommandUI = new UpdateCommandUIEvent(OnUpdateCommandUI);
            this.CommandUI += new CommandUIEvent(OnCommandUI);
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("NKTOUA.NKTOUA_Ribbon.xml");
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
                case NKTOUA_SETTINGS_BUTTON:
                    return PictureConverter.IconToPictureDisp(Properties.Resources.Settings);
                case NKTOUA_CATEGORIZE_BUTTON:
                    return PictureConverter.IconToPictureDisp(Properties.Resources.Categorize);
                case NKTOUA_MOVEALLTOROOT_BUTTON:
                    return PictureConverter.IconToPictureDisp(Properties.Resources.MoveAllToRoot);
                default:
                    return null;
            }
        }

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit http://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            
        }

        public void OnAction(Office.IRibbonControl control)
        {
            if (null != control)
            {
                this.CommandUI?.Invoke(control.Id, control.Tag);
            }
        }

        public string GetLabel(Office.IRibbonControl control)
        {
            if( (null==control) || (null==this.UpdateCommandUI) )
            {
                return string.Empty;
            }
            else
            {
                CmdUI ui = new CmdUI(control.Id);
                UpdateCommandUI?.Invoke(ui);
                return ui.Label;
            }
        }

        public string GetDescription(Office.IRibbonControl control)
        {
            if ((null == control) || (null == this.UpdateCommandUI))
            {
                return string.Empty;
            }
            else
            {
                CmdUI ui = new CmdUI(control.Id);
                UpdateCommandUI?.Invoke(ui);
                return ui.Description;
            }
        }

        public string GetKeytip(Office.IRibbonControl control)
        {
            if ((null == control) || (null == this.UpdateCommandUI))
            {
                return string.Empty;
            }
            else
            {
                CmdUI ui = new CmdUI(control.Id);
                UpdateCommandUI?.Invoke(ui);
                return ui.Description;
            }
        }

        public string GetSupertip(Office.IRibbonControl control)
        {
            if ((null == control) || (null == this.UpdateCommandUI))
            {
                return string.Empty;
            }
            else
            {
                CmdUI ui = new CmdUI(control.Id);
                UpdateCommandUI?.Invoke(ui);
                return ui.Description;
            }
        }

        public string GetScreentip(Office.IRibbonControl control)
        {
            if ((null == control) || (null == this.UpdateCommandUI))
            {
                return string.Empty;
            }
            else
            {
                CmdUI ui = new CmdUI(control.Id);
                UpdateCommandUI?.Invoke(ui);
                return ui.ScreenTip;
            }
        }

        public bool GetVisible(Office.IRibbonControl control)
        {
            if ((null == control) || (null == this.UpdateCommandUI))
            {
                return false;
            }
            else
            {
                CmdUI ui = new CmdUI(control.Id);
                UpdateCommandUI?.Invoke(ui);
                return ui.Visible;
            }
        }

        public bool GetEnable(Office.IRibbonControl control)
        {
            if ((null == control) || (null == this.UpdateCommandUI))
            {
                return false;
            }
            else
            {
                CmdUI ui = new CmdUI(control.Id);
                UpdateCommandUI?.Invoke(ui);
                return ui.Enable;
            }
        }


        public void OnUpdateCommandUI(CmdUI ui)
        {
            if (null != ui)
            {
                switch (ui.Id)
                {
                    case NKTOUA_GROUP:
                        ui.Visible = true;
                        ui.Enable = true;
                        ui.Label = NKTOUA_Application.Instance.Name;
                        break;
                    case NKTOUA_DROPDOWN_MENU:
                        ui.Visible = true;
                        ui.Enable = true;
                        ui.Label = NKTOUA_Application.Instance.Name;
                        ui.Description = Properties.Resources.NKTOUA_DROPDOWN_MENU_DESC;
                        ui.KeyTip = Properties.Resources.NKTOUA_DROPDOWN_MENU_TOOLTIP;
                        ui.ScreenTip = Properties.Resources.NKTOUA_DROPDOWN_MENU_TOOLTIP;
                        ui.SuperTip = Properties.Resources.NKTOUA_DROPDOWN_MENU_TOOLTIP;
                        break;
                    case NKTOUA_SETTINGS_BUTTON:
                        ui.Visible = true;
                        ui.Enable = true;
                        ui.Label = Properties.Resources.NKTOUA_SETTINGS_BUTTON_LABEL;
                        ui.Description = Properties.Resources.NKTOUA_SETTINGS_BUTTON_DESC;
                        ui.KeyTip = Properties.Resources.NKTOUA_SETTINGS_BUTTON_TOOLTIP;
                        ui.ScreenTip = Properties.Resources.NKTOUA_SETTINGS_BUTTON_TOOLTIP;
                        ui.SuperTip = Properties.Resources.NKTOUA_SETTINGS_BUTTON_TOOLTIP;
                        break;
                    case NKTOUA_CATEGORIZE_BUTTON:
                        ui.Visible = true;
                        ui.Enable = true;
                        ui.Label = Properties.Resources.NKTOUA_GROUPING_BUTTON_LABEL;
                        ui.Description = Properties.Resources.NKTOUA_CATEGORIZE_BUTTON_DESC;
                        ui.KeyTip = Properties.Resources.NKTOUA_CATEGORIZE_BUTTON_TOOLTIP;
                        ui.ScreenTip = Properties.Resources.NKTOUA_CATEGORIZE_BUTTON_TOOLTIP;
                        ui.SuperTip = Properties.Resources.NKTOUA_CATEGORIZE_BUTTON_TOOLTIP;
                        break;
                    case NKTOUA_MOVEALLTOROOT_BUTTON:
                        ui.Visible = true;
                        ui.Enable = true;
                        ui.Label = Properties.Resources.NKTOUA_MOVEALLTOROOT_BUTTON_LABEL;
                        ui.Description = Properties.Resources.NKTOUA_MOVEALLTOROOT_BUTTON_DESC;
                        ui.KeyTip = Properties.Resources.NKTOUA_MOVEALLTOROOT_BUTTON_TOOLTIP;
                        ui.ScreenTip = Properties.Resources.NKTOUA_MOVEALLTOROOT_BUTTON_TOOLTIP;
                        ui.SuperTip = Properties.Resources.NKTOUA_MOVEALLTOROOT_BUTTON_TOOLTIP;
                        break;
                    default:
                        break;
                }
            }
        }

        private void OnWalkDir(Outlook.Folder folder, dynamic item, object data)
        {
            if (null != data)
            {
                KeyValuePair<WalkDirEvents, List<NKTOUA_Folder>> e = (KeyValuePair<WalkDirEvents, List<NKTOUA_Folder>>)data;

            }
        }

        private void OnCommandUI(string uiID, object arg)
        {
            switch (uiID)
            {
                case NKTOUA_SETTINGS_BUTTON:
                    {
                        frmSettings settings = new frmSettings();
                        settings.ShowDialog();
                    }
                    break;
                case NKTOUA_CATEGORIZE_BUTTON:
                    {
                        frmFolderTree frm = new frmFolderTree();
                        frm.Application = this.Application;
                        frm.ActionName = Properties.Resources.NKTOUA_GROUPING_BUTTON_LABEL;
                        frm.ShowDialog();

                        foreach(Outlook.Folder folder in frm.SelectedFolders)
                        {
                            MessageBox.Show(folder.FullFolderPath);
                        }
                    }
                    break;
                case NKTOUA_MOVEALLTOROOT_BUTTON:
                    {
                        frmFolderTree frm = new frmFolderTree();
                        frm.Application = this.Application;
                        frm.ActionName = Properties.Resources.NKTOUA_MOVEALLTOROOT_BUTTON_LABEL;
                        frm.ShowDialog();

                        foreach (Outlook.Folder folder in frm.SelectedFolders)
                        {
                            MessageBox.Show(folder.FullFolderPath);
                        }
                    }
                    break;
                default:
                    break;
            }
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
