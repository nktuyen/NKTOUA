using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.ComponentModel;
using System.Diagnostics;

namespace NKTOUA
{
    class NKTOUA_Explorer : IDisposable
    {
        #region "Propertiess"
        private Outlook.Explorer _explorer = null;
        private Outlook.Application _application = null;
        private bool _active = false;

        public Outlook.Explorer olExplorer
        {
            get { return _explorer; }
            set
            {
                Outlook.ExplorerEvents_10_Event explEvents = null;
                if (null != _explorer)
                {
                    explEvents = _explorer as Outlook.ExplorerEvents_10_Event;
                    if (null != explEvents)
                    {
                        explEvents.Activate -= OnActive;
                        explEvents.BeforeFolderSwitch -= BeforeFolderSwitch;
                        explEvents.Close -= OnClose;
                        explEvents.Deactivate -= OnDeactive;
                        explEvents.FolderSwitch -= OnFolderSwitch;
                        explEvents.SelectionChange -= OnSelectionChange;
                        explEvents.ViewSwitch -= OnViewSwitch;
                    }
                }

                _explorer = value as Outlook.Explorer;
                if (null != _explorer)
                {
                    explEvents = _explorer as Outlook.ExplorerEvents_10_Event;
                    if (null != explEvents)
                    {
                        explEvents.Activate += OnActive;
                        explEvents.BeforeFolderSwitch += BeforeFolderSwitch;
                        explEvents.Close += OnClose;
                        explEvents.Deactivate += OnDeactive;
                        explEvents.FolderSwitch += OnFolderSwitch;
                        explEvents.SelectionChange += OnSelectionChange;
                        explEvents.ViewSwitch += OnViewSwitch;
                    }
                }
            }
        }

        public Outlook.Application Application
        {
            get { return _application; }
            set { _application = value as Outlook.Application; }
        }


        public bool Activated
        {
            get{return _active; }
            set { _active = value; }
        }
        #endregion

        #region "Life cycle methods"
        public NKTOUA_Explorer(Outlook.Explorer explorer)
        {
            olExplorer = explorer;
        }

        public void Dispose()
        {
            olExplorer = null;
        }

        ~NKTOUA_Explorer()
        {
            Dispose();
        }
        #endregion

        #region "Event handlers"
        /// <summary>
        /// 
        /// </summary>
        public void OnInit()
        {
            
        }


        /// <summary>
        /// 
        /// </summary>
        public void OnActive()
        {
            Activated = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnClose()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void OnDeactive()
        {
            Activated = false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void BeforeFolderSwitch(object NewFolder, ref bool Cancel)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void OnFolderSwitch()
        {
            Debug.Print("OnFolderSwitch: "+ _explorer.CurrentFolder.FullFolderPath);
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnSelectionChange()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void OnViewSwitch()
        {
            Outlook.View view = _explorer.CurrentView as Outlook.View;
            if (null != view)
            {
                switch (view.ViewType)
                {
                    case Microsoft.Office.Interop.Outlook.OlViewType.olBusinessCardView:
                        Debug.Print("OnViewSwitch: olBusinessCardView");
                        break;
                    case Microsoft.Office.Interop.Outlook.OlViewType.olCalendarView:
                        Debug.Print("OnViewSwitch: olCalendarView");
                        break;
                    case Microsoft.Office.Interop.Outlook.OlViewType.olCardView:
                        Debug.Print("OnViewSwitch: olCardView");
                        break;
                    case Outlook.OlViewType.olDailyTaskListView:
                        Debug.Print("OnViewSwitch: olDailyTaskListView");
                        break;
                    case Outlook.OlViewType.olIconView:
                        Debug.Print("OnViewSwitch: olIconView");
                        break;
                    case Outlook.OlViewType.olPeopleView:
                        Debug.Print("OnViewSwitch: olPeopleView");
                        break;
                    case Outlook.OlViewType.olTableView:
                        Debug.Print("OnViewSwitch: olTableView");
                        break;
                    case Outlook.OlViewType.olTimelineView:
                        Debug.Print("OnViewSwitch: olTimelineView");
                        break;
                    default:
                        Debug.Print("OnViewSwitch: Unknown");
                        break;
                }
            }
        }
        #endregion
    }
}
