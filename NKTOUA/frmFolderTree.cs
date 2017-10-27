using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace NKTOUA
{
    public partial class frmFolderTree : Form
    {
        Dictionary<string, TreeNode> _nodes = new Dictionary<string, TreeNode>();
        List<Outlook.Folder> _selectedFolders = new List<Outlook.Folder>();
        TreeNode _rootNode = null;
        public NKTOUA_Application Application { get; set; }
        public string ActionName { get; set; }
        public List<Outlook.Folder> SelectedFolders
        {
            get{ return _selectedFolders; }
        }

        public frmFolderTree()
        {
            InitializeComponent();
        }

        private void frmFolderTree_Load(object sender, EventArgs e)
        {
            this.Text = Properties.Resources.frmTreeFolders;
            this.btnOK.Text = Properties.Resources.frmTreeFolders_BUTTON_OK;
            this.lblChoseFolders.Text = string.Format(Properties.Resources.frmTreeFolders_LABEL_ChoseFolders, ActionName);

            if (null != this.Application)
            {
                _rootNode = treeFolders.Nodes.Add("This Computer");
                foreach (Outlook.Store acc in this.Application.olApplication.Session.Stores)
                {
                    NKTOUA_FolderWalker walker = new NKTOUA_FolderWalker();
                    walker.OnFolder += new NKTOUA_FolderWalker.WalkDirFolderEventHandler(OnFolder);
                    walker.Walk(acc.GetRootFolder() as Outlook.Folder, true);
                }
            }
        }

        private void OnFolder(Outlook.Folder folder, object data)
        {
            if (null == folder)
            {
                return;
            }

            TreeNode newNode = null;
            if (null != folder.Parent)
            {
                Outlook.Folder parentFolder = folder.Parent as Outlook.Folder;
                TreeNode parent = null;
                if (null != parentFolder)
                {
                    parent = _nodes[parentFolder.FullFolderPath];
                }
                if (null != parent)
                {
                    newNode = parent.Nodes.Add(folder.Name);
                }
                else
                {
                    newNode = _rootNode.Nodes.Add(folder.Name);
                }
            }

            if (null != newNode)
            {
                if (!_nodes.ContainsKey(folder.FullFolderPath))
                {
                    _nodes.Add(folder.FullFolderPath, newNode);
                }
            }
        }

        private void frmFolderTree_SizeChanged(object sender, EventArgs e)
        {
            btnOK.Left = this.Width/2 - btnOK.Width / 2;
        }
    }
}
