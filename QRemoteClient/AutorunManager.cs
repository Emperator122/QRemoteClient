using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRemoteClient
{
    static class AutorunManager
    {
        const string name = "QRemoteClient";
        public static bool SetAutorunValue(bool autorun)
        {
            string ExePath = System.Windows.Forms.Application.ExecutablePath;
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                if (autorun)
                    reg.SetValue(name, ExePath);
                else
                    reg.DeleteValue(name);

                reg.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static bool isAppOnAutorun()
        {
            string ExePath = System.Windows.Forms.Application.ExecutablePath;
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                string value = (string)reg.GetValue(name);
                reg.Close();
                return value == ExePath;
            }
            catch
            {
                return false;
            }
        }
    }
}
