using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace NKTOUA
{
    class NKTOUA_Inspector : IDisposable
    {
        #region "properties"
        private Outlook.Inspector _inspector = null;
        private Outlook.Application _application = null;
        private NKTOUA_Item _olItem = null;

        public Outlook.Inspector olInspector
        {
            get { return _inspector; }
            set
            {
                Outlook.InspectorEvents_10_Event inspecEvents = null;
                if (null != _inspector)
                {
                    inspecEvents = _inspector as Outlook.InspectorEvents_10_Event;
                    if(null != inspecEvents)
                    {
                        inspecEvents.Activate -= OnActive;
                        inspecEvents.Deactivate -= OnDeactive;
                        inspecEvents.Close -= OnClose;
                        inspecEvents.PageChange -= OnPageChange;
                    }
                }

                _inspector = value as Outlook.Inspector;
                if (null != _inspector)
                {
                    inspecEvents = _inspector as Outlook.InspectorEvents_10_Event;
                    if (null != inspecEvents)
                    {
                        inspecEvents.Activate += OnActive;
                        inspecEvents.Deactivate += OnDeactive;
                        inspecEvents.Close += OnClose;
                        inspecEvents.PageChange += OnPageChange;
                    }
                }
            }
        }

        public Outlook.Application Application
        {
            get { return _application; }
            set { _application = value as Outlook.Application; }
        }

        public NKTOUA_Item Item
        {
            get { return _olItem; }
            set
            {
                if(null != _olItem)
                {
                    _olItem.Dispose();
                }

                _olItem = value;
            }
        }
        #endregion

        #region "Member functions"
        public NKTOUA_Inspector(Outlook.Inspector inspector)
        {
            olInspector = inspector;
        }

        ~NKTOUA_Inspector()
        {
            Dispose();
        }

        public void Dispose()
        {
            Item = null;
            olInspector = null;
        }
        #endregion

        #region "Event handlers"
        /// <summary>
        /// 
        /// </summary>
        public void OnInit()
        {
            if(null != _inspector)
            {
                Outlook.AppointmentItem appItem = _inspector.CurrentItem as Outlook.AppointmentItem;
                if (null != appItem)
                {
                    Item = new NKTOUA_Appointment(appItem);
                }
            }
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
        private void OnDeactive()
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
        /// <param name="ActivePageName"></param>
        private void OnPageChange(ref string ActivePageName)
        {

        }
        #endregion
    }
}
