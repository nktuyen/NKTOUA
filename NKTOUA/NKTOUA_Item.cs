using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace NKTOUA
{
    class NKTOUA_Item : IDisposable
    {
        #region "Properties"
        protected dynamic _item = null;

        public NKTOUA_Application Application { get; }
        #endregion

        #region "Member functions"
        public NKTOUA_Item(dynamic item, NKTOUA_Application application = null)
        {
            _item = item;
        }

        public virtual void Dispose()
        {
            
        }
        ~NKTOUA_Item()
        {
            Dispose();
        }
        #endregion
    }
}
