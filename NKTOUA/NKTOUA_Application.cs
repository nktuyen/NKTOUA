using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace NKTOUA
{
    public class NKTOUA_Application : IDisposable
    {
        #region "Properties"
        private static NKTOUA_Application _instance = null;
        private Outlook.Application _application = null;
        private Outlook.Explorers _explorers = null;
        private List<NKTOUA_Explorer> _olExplorers = null;
        private Outlook.Inspectors _inspectors = null;
        private List<NKTOUA_Inspector> _olInspectors = null;

        public Outlook.Application olApplication
        {
            get { return _application; }
            set
            {
                Outlook.ApplicationEvents_11_Event appEvents = null;
                if (null != _application)
                {
                    appEvents = _application as Outlook.ApplicationEvents_11_Event;
                    if (null != appEvents)
                    {
                        appEvents.ItemSend -= OnItemSend;
                        appEvents.NewMail -= OnNewMail;
                        appEvents.NewMailEx -= OnNewMailEx;
                        appEvents.Quit -= OnQuit;
                        appEvents.Startup -= OnStart;
                    }

                    Explorers = null;
                    Inspectors = null;
                }

                _application = value as Outlook.Application;
                if (null != _application)
                {
                    appEvents = _application as Outlook.ApplicationEvents_11_Event;
                    if (null != appEvents)
                    {
                        appEvents.ItemSend += OnItemSend;
                        appEvents.NewMail += OnNewMail;
                        appEvents.NewMailEx += OnNewMailEx;
                        appEvents.Quit += OnQuit;
                        appEvents.Startup += OnStart;
                    }

                    Explorers = _application.Explorers;
                    Inspectors = _application.Inspectors;
                }

            }
        }

        public NKTOUA_Ribbon Ribbon { get; set; }
        public string Name
        {
            get
            {
                return "NKTOUA";
            }
        }

        public string DataPath
        {
            get
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + Name;
                return path;
            }
        }

        private Outlook.Explorers Explorers
        {
            get { return _explorers; }
            set
            {
                if(null != _explorers)
                {
                    _explorers.NewExplorer -= OnNewExplorer;
                }
                RemoveExplores();
                _explorers = value as Outlook.Explorers;
                if (null != _explorers)
                {
                    NKTOUA_Explorer exploreHandler = null;
                    Outlook.Explorer activeExplore = _application.ActiveExplorer();
                    foreach (Outlook.Explorer explorer in _explorers)
                    {
                        if( (null != explorer) && (activeExplore != explorer) )
                        {
                            exploreHandler = new NKTOUA_Explorer(explorer);
                            exploreHandler.Application = this.olApplication;
                            exploreHandler.OnInit();
                            _olExplorers.Add(exploreHandler);
                        }
                    }

                    //For active explorer
                    if(null != activeExplore)
                    {
                        exploreHandler = new NKTOUA_Explorer(activeExplore);
                        exploreHandler.Application = this.olApplication;
                        exploreHandler.OnInit();
                        exploreHandler.OnActive();
                        _olExplorers.Add(exploreHandler);
                    }
                    _explorers.NewExplorer += OnNewExplorer;
                }
            }
        }

        private Outlook.Inspectors Inspectors
        {
            get { return _inspectors; }
            set
            {
                if(null != _inspectors)
                {
                    _inspectors.NewInspector -= OnNewInspector;
                }
                RemoveInspectors();
                _inspectors = value as Outlook.Inspectors;
                if (null != _inspectors)
                {
                    NKTOUA_Inspector newInspector = null;
                    foreach (Outlook.Inspector inspec in _inspectors)
                    {
                        if (null != inspec)
                        {
                            newInspector = new NKTOUA_Inspector(inspec);
                            newInspector.Application = this.olApplication;
                            newInspector.OnInit();
                            _olInspectors.Add(newInspector);
                        }
                    }
                    _inspectors.NewInspector += OnNewInspector;
                }
            }
        }

        public static NKTOUA_Application Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = new NKTOUA_Application();
                }
                return _instance;
            }
        }
        #endregion

        #region "Life cycle Methods"
        public void Dispose()
        {
            Explorers = null;
            olApplication = null;
        }

        private NKTOUA_Application()
        {
            _olExplorers = new List<NKTOUA_Explorer>();
        }

        ~NKTOUA_Application()
        {
            Dispose();
        }

        private void RemoveExplores()
        {
            if (null != _olExplorers)
            {
                foreach (NKTOUA_Explorer expl in _olExplorers)
                {
                    expl.Dispose();
                }
                _olExplorers.Clear();
            }
        }

        private void RemoveInspectors()
        {
            if(null != _olInspectors)
            {
                foreach(NKTOUA_Inspector inspec in _olInspectors)
                {
                    inspec.Dispose();
                }
                _olInspectors.Clear();
            }
        }
        #endregion

        #region "Event handlers"
        /// <summary>
        /// 
        /// </summary>
        private void OnStart()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnQuit()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void OnNewExplorer(Outlook.Explorer explorer)
        {
            NKTOUA_Explorer newExplorer = new NKTOUA_Explorer(explorer);
            if(null != newExplorer)
            {
                newExplorer.Application = this.olApplication;
                newExplorer.OnInit();
                _olExplorers.Add(newExplorer);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inspector"></param>
        private void OnNewInspector(Outlook.Inspector inspector)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="Cancel"></param>
        private void OnItemSend(object Item, ref bool Cancel)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        private void OnNewMail()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="EntryIDCollection"></param>
        private void OnNewMailEx(string EntryIDCollection)
        {

        }

        
        #endregion
    }
}
