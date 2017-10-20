using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace NKTOUA
{
    class olInspector : IDisposable
    {
        #region "properties"
        private Outlook.Inspector _inspector = null;
        private Outlook.Application _application = null;
        private olItem _olItem = null;

        public Outlook.Inspector Inspector
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

        public olItem Item
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
        public olInspector(Outlook.Inspector inspector)
        {
            Inspector = inspector;
        }

        ~olInspector()
        {
            Dispose();
        }

        public void Dispose()
        {
            Item = null;
            Inspector = null;
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
                    Item = new olAppointmentItem(appItem);
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
