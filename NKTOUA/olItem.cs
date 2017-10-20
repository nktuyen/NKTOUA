using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace NKTOUA
{
    class olItem : IDisposable
    {
        #region "Properties"
        protected Outlook.Application _application = null;
        protected dynamic _item = null;

        public Outlook.Application Application
        {
            get { return _application; }
            set { _application = value as Outlook.Application; }
        }
        #endregion

        #region "Member functions"
        public olItem(dynamic item)
        {
            _item = item;
        }

        public virtual void Dispose()
        {
            
        }
        ~olItem()
        {
            Dispose();
        }
        #endregion
    }
}
