using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace NKTOUA
{
    class NKTOUA_Appointment : NKTOUA_Item
    {
        #region "Properties"
        public Outlook.AppointmentItem Item
        {
            get { return _item as Outlook.AppointmentItem; }
            set
            {
                if (null != this.Item)
                {
                    Item.AfterWrite -= AfterWrite;
                    Item.CustomPropertyChange -= OnCustomPropertyChange;
                    Item.Open -= OnOpen;
                    Item.PropertyChange -= OnPropertyChange;
                    Item.Read -= OnRead;
                    Item.ReadComplete -= OnReadComplete;
                    Item.Unload -= OnUnload;
                    Item.Write -= OnWrite;
                }
                base._item = value;
                if (null != this.Item)
                {
                    Item.AfterWrite += AfterWrite;
                    Item.CustomPropertyChange += OnCustomPropertyChange;
                    Item.Open += OnOpen;
                    Item.PropertyChange += OnPropertyChange;
                    Item.Read += OnRead;
                    Item.ReadComplete += OnReadComplete;
                    Item.Unload += OnUnload;
                    Item.Write += OnWrite;
                }
            }
        }
        #endregion

        #region "member functions"
        public NKTOUA_Appointment(Outlook.AppointmentItem item) : base(item)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Dispose()
        {
            Item = null;
        }
        ~NKTOUA_Appointment()
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
        private void AfterWrite()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        private void OnCustomPropertyChange(string Name)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        private void OnPropertyChange(string Name)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Cancel"></param>
        private void OnOpen(ref bool Cancel)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void OnRead()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Cancel"></param>
        private void OnReadComplete(ref bool Cancel)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void OnUnload()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Cancel"></param>
        private void OnWrite(ref bool Cancel)
        {

        }
        #endregion
    }
}
