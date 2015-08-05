using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProcessLogger
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IEnumerable<Process> processlist = Process.GetProcesses().AsEnumerable();

            XElement xElement = new XElement("ProcessList");
            foreach (var process in Process.GetProcesses().AsEnumerable())
            {
                xElement.Add(new XElement("Process", process.ProcessName));
                var StartInfo = new XElement("StartInfo");
                StartInfo.Add(new XElement("FileName", process.StartInfo.FileName));
                StartInfo.Add(new XElement("Arguments", process.StartInfo.Arguments));
                StartInfo.Add(new XElement("CreateNoWindow", process.StartInfo.CreateNoWindow));
                StartInfo.Add(new XElement("Domain", process.StartInfo.Domain));
                StartInfo.Add(new XElement("EnvironmentVariables", process.StartInfo.EnvironmentVariables));
                StartInfo.Add(new XElement("ErrorDialog", process.StartInfo.ErrorDialog));
                StartInfo.Add(new XElement("ErrorDialogParentHandle", process.StartInfo.ErrorDialogParentHandle));
                StartInfo.Add(new XElement("LoadUserProfile", process.StartInfo.LoadUserProfile));
                StartInfo.Add(new XElement("Password", process.StartInfo.Password));
                StartInfo.Add(new XElement("RedirectStandardError", process.StartInfo.RedirectStandardError));
                StartInfo.Add(new XElement("Arguments", process.StartInfo.WorkingDirectory));
                StartInfo.Add(new XElement("IsFixedSize", process.StartInfo.Verbs.IsFixedSize));
                StartInfo.Add(new XElement("FileName", process.StartInfo.FileName));
                StartInfo.Add(new XElement("FileName", process.StartInfo.FileName));
                StartInfo.Add(new XElement("FileName", process.StartInfo.FileName));
                StartInfo.Add(new XElement("FileName", process.StartInfo.FileName));
                StartInfo.Add(new XElement("FileName", process.StartInfo.FileName));
                StartInfo.Add(new XElement("FileName", process.StartInfo.FileName));
                StartInfo.Add(new XElement("FileName", process.StartInfo.FileName));
                xElement.Add(StartInfo);
            }

            xElement.Save(string.Format(@"D:\temp\Process{0}.xml", DateTime.Now.ToString("yyyyMMddHHmmss")));
        }
    }
    public static class Extrension
    {
        public static XElement ToXML(this object o)
        {
            Type t = o.GetType();

            Type[] extraTypes = t.GetProperties()
                .Where(p => p.PropertyType.IsInterface)
                .Select(p => p.GetValue(o, null).GetType())
                .ToArray();

            DataContractSerializer serializer = new DataContractSerializer(t, extraTypes);
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            serializer.WriteObject(xw, o);
            return XElement.Parse(sw.ToString());
        }
    }

}



