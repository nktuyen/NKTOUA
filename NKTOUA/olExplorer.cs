using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace NKTOUA
{
    class olExplorer : IDisposable
    {
        #region "Propertiess"
        private Outlook.Explorer _explorer = null;
        private Outlook.Application _application = null;

        public Outlook.Explorer Explorer
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
        #endregion

        #region "Life cycle methods"
        public olExplorer(Outlook.Explorer explorer)
        {
            Explorer = explorer;
        }

        public void Dispose()
        {
            Explorer = null;
        }

        ~olExplorer()
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
        private void OnActive()
        {

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

        }
        #endregion
    }
}
