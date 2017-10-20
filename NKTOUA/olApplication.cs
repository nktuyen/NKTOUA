using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace NKTOUA
{
    class olApplication : IDisposable
    {
        #region "Properties"
        private static olApplication _instance = null;
        private Outlook.Application _application = null;
        private Outlook.Explorers _explorers = null;
        private List<olExplorer> _olExplorers = null;
        private Outlook.Inspectors _inspectors = null;
        private List<olInspector> _olInspectors = null;

        public Outlook.Application Application
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
                    olExplorer exploreHandler = null;
                    foreach (Outlook.Explorer explorer in _explorers)
                    {
                        if(null != explorer)
                        {
                            exploreHandler = new olExplorer(explorer);
                            exploreHandler.Application = this.Application;
                            exploreHandler.OnInit();
                            _olExplorers.Add(exploreHandler);
                        }
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
                    olInspector newInspector = null;
                    foreach (Outlook.Inspector inspec in _inspectors)
                    {
                        if (null != inspec)
                        {
                            newInspector = new olInspector(inspec);
                            newInspector.Application = this.Application;
                            newInspector.OnInit();
                            _olInspectors.Add(newInspector);
                        }
                    }
                    _inspectors.NewInspector += OnNewInspector;
                }
            }
        }

        public static olApplication Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = new olApplication();
                }
                return _instance;
            }
        }
        #endregion

        #region "Life cycle Methods"
        public void Dispose()
        {
            Explorers = null;
            Application = null;
        }

        private olApplication()
        {
            _olExplorers = new List<olExplorer>();
        }

        ~olApplication()
        {
            Dispose();
        }

        private void RemoveExplores()
        {
            if (null != _olExplorers)
            {
                foreach (olExplorer expl in _olExplorers)
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
                foreach(olInspector inspec in _olInspectors)
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
            olExplorer newExplorer = new olExplorer(explorer);
            if(null != newExplorer)
            {
                newExplorer.Application = this.Application;
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
