using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NKTOUA
{
    public enum ECategorizeBy
    {
        Address = 0,
        Subject,
        Date
    }

    public abstract class AppSetting
    {
        public virtual bool Equal(AppSetting other) { return true; }
        public virtual void Copy(AppSetting other) {; }
        public abstract void Load(string Path);
        public abstract void Save(string Path);
    }
    public class AppSettingGeneral : AppSetting
    {
        public AppSettingGeneral()
        {

        }

        public override void Copy(AppSetting other)
        {
            base.Copy(other);
        }

        public override void Load(string Path)
        {
            
        }

        public override void Save(string Path)
        {
            
        }
    }

    public class AppSettingCategorize : AppSetting
    {
        private ECategorizeBy _criteria = ECategorizeBy.Address;

        public ECategorizeBy Criteria
        {
            get { return _criteria; }
            set { _criteria = value; }
        }

        public AppSettingCategorize()
        {

        }

        public override bool Equal(AppSetting other)
        {
            if (!base.Equal(other))
                return false;

            AppSettingCategorize otherCategorize = other as AppSettingCategorize;

            if (this.Criteria != otherCategorize.Criteria)
                return false;

            return true;
        }

        public override void Copy(AppSetting other)
        {
            base.Copy(other);

            AppSettingCategorize otherCategorize = other as AppSettingCategorize;
            this.Criteria = otherCategorize.Criteria;
        }

        public override void Load(string Path)
        {

        }

        public override void Save(string Path)
        {

        }
    }


    public class AppSettings : AppSetting
    {
        private static AppSettings _instance = null;
        private System.Xml.Serialization.XmlSerializer _serializer = null;
        private AppSettingGeneral _general = new AppSettingGeneral();
        private AppSettingCategorize _categorize = new AppSettingCategorize();

        public AppSettingGeneral General
        {
            get { return _general; }
            set { _general = value; }
        }

        public AppSettingCategorize Categorize
        {
            get { return _categorize; }
            set { _categorize = value; }
        }

        private AppSettings()
        {

        }

        public static AppSettings Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = new AppSettings();
                }
                return _instance;
            }
        }

        public override bool Equal(AppSetting other)
        {
            AppSettings otherSettings = other as AppSettings;
            if ( (!otherSettings.General.Equal(this.General))
                || (!otherSettings.Categorize.Equal(this.Categorize)) 
                )

                return false;

            return true;
        }

        public override void Copy(AppSetting other)
        {
            base.Copy(other);
            AppSettings otherSettings = other as AppSettings;
            General.Copy(otherSettings.General);
            Categorize.Copy(otherSettings.Categorize);
        }

        public AppSettings Clone()
        {
            AppSettings newSettings = new AppSettings();
            newSettings.Copy(this);

            return newSettings;
        }

        public override void Load(string Path)
        {
            if(null== _serializer)
            {
                _serializer = new System.Xml.Serialization.XmlSerializer(typeof(AppSettings));
            }
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(Path, System.IO.FileMode.Open);
                System.Xml.XmlReader reader = System.Xml.XmlReader.Create(fs);
                AppSettings tmp = (AppSettings)_serializer.Deserialize(reader);
                fs.Close();
                General = tmp.General;
                Categorize = tmp.Categorize;
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }

        public override void Save(string Path)
        {
            if (null == _serializer)
            {
                _serializer = new System.Xml.Serialization.XmlSerializer(typeof(AppSettings));
            }
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(Path, System.IO.FileMode.OpenOrCreate);
                System.IO.TextWriter writer = new System.IO.StreamWriter(fs);
                _serializer.Serialize(writer, this);
                fs.Close();
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }
    }
}
