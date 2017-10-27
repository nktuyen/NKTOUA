using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace NKTOUA
{
    class NKTOUA_FolderWalker : IDisposable
    {
        #region "Attributes"
        public delegate void WalkDirFolderEventHandler(Outlook.Folder folder, object data);
        public delegate void WalkDirItemEventHandler(Outlook.Folder folder, dynamic item, object data);
        public event WalkDirFolderEventHandler OnFolder;
        public event WalkDirItemEventHandler OnItem;
        #endregion

        #region "Properties"
        #endregion

        #region "Member functions"
        public NKTOUA_FolderWalker()
        {
            
        }

        public void Dispose()
        {

        }

        ~NKTOUA_FolderWalker()
        {
            Dispose();
        }

        public void Walk(Outlook.Folder root, bool recursive = false, object data = null)
        {
            if (null != root)
            {
                OnFolder?.Invoke(root, data);

                foreach(dynamic item in root.Items)
                {
                    OnItem?.Invoke(root, item, data);
                }

                if((recursive) && (root.Folders.Count > 0))
                {
                    foreach(Outlook.Folder child in root.Folders)
                    {
                        Walk(child, recursive, data);
                    }
                }
            }
        }
        #endregion

        #region "Event handlers"
        #endregion
    }
}
