using System;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QRemoteClient
{
    static class ConfigManager
    {
        /// <summary>
        /// Путь к конфигу
        /// </summary>
        public static string ConfigPath = Application.StartupPath + "\\config.xml";

        /// <summary>
        /// Получение и десериализация данных конфигурации из файла
        /// </summary>
        /// <returns>Класс с настройками</returns>
        public static ConfigData GetConfigData()
        {
            ConfigData settings;
            try
            {
                using (Stream stream = new FileStream(ConfigPath, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ConfigData));
                    settings  = (ConfigData)serializer.Deserialize(stream);
                    return settings;
                }
            }
            catch
            {
                settings = new ConfigData();
                settings.AutoRun = true;
                settings.Servers = new List<ComboBoxRow>();
                try
                {
                    SaveConfigData(settings);
                }
                catch
                {
                    return settings;
                }
                return settings;
            }
        }

        /// <summary>
        /// Сериализация и сохранение данных конфигурации
        /// </summary>
        /// <param name="data">Файл с записанными настройками</param>
        public static void SaveConfigData(ConfigData data)
        {
            using (Stream writer = new FileStream(ConfigPath, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ConfigData));
                serializer.Serialize(writer, data);
            }
        }
    }
    public class ConfigData
    {
        public bool AutoRun;
        public List<ComboBoxRow> Servers;
        public int FindIP(string ip)
        {
            for (int i = 0; i < Servers.Count; i++)
                if (Servers[i].IP == ip)
                    return i;
            return -1;
        }
    }
}
