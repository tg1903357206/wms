using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ToolApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetDefultValue();
        }
        private void SetDefultValue()
        {
            tbSolutionPath.Text = @"E:\框架应用\WMS\";

            tbDomainDll.Text = @"Domain\bin\Debug\com.tg.WMS.Domain.dll";
            tbDomainNameSpace.Text = "com.tg.WMS.Domain";

            tbServicePath.Text = @"Service";
            tbServiceNameSpace.Text = "com.tg.WMS.Service";

            tbManagerPath.Text = @"Manager";
            tbManagerNameSpace.Text = "com.tg.WMS.Manager";

            tbComponentPath.Text = @"Component";
            tbComponentNameSpace.Text = "com.tg.WMS.Component";

            tbXmlFile.Text = @"Web\config\service.xml";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            IList<string> lstContent = new List<string>();
            IList<string> xmlContent = new List<string>();
            xmlContent.Add("<?xml version='1.0' encoding='utf-8' ?>");
            xmlContent.Add("<configuration>");
            xmlContent.Add("    <components>");

            //解决方案路径
            string solutionPath = tbSolutionPath.Text;

            //Domain层
            string domainDll = tbDomainDll.Text;
            string domainNameSpace = tbDomainNameSpace.Text;

            //Service层
            string servicePath = tbServicePath.Text;
            string serviceNameSpace = tbServiceNameSpace.Text;

            //Manager层
            string managerPath = tbManagerPath.Text;
            string managerNameSpace = tbManagerNameSpace.Text;

            //Component层
            string componentPath = tbComponentPath.Text;
            string componentNameSpace = tbComponentNameSpace.Text;

            //配置文件名（含相对路径）
            string xmlFile = tbXmlFile.Text;

            Type[] types = Assembly.LoadFrom(solutionPath + domainDll).GetTypes();

            foreach (Type className in types)
            {
                if (className.Namespace == domainNameSpace)
                {
                    string entityName = className.Name;
                    if (entityName.Contains("BaseEntity")) continue;

                    #region 生成Service层的cs文件
                    lstContent.Clear();
                    lstContent.Add(string.Format("using {0};", domainNameSpace));
                    lstContent.Add("");
                    lstContent.Add(string.Format("namespace {0}", serviceNameSpace));
                    lstContent.Add("{");
                    lstContent.Add(string.Format("  public interface IService{0} : BaseService<{0}>", entityName));
                    lstContent.Add("    {");
                    lstContent.Add("    }");
                    lstContent.Add("}");
                    File.WriteAllLines(string.Format(@"{0}{1}\IService{2}.cs", solutionPath, servicePath, entityName), lstContent, Encoding.UTF8);
                    #endregion

                    #region 生成Manager层的cs文件
                    lstContent.Clear();
                    lstContent.Add(string.Format("using {0};", domainNameSpace));
                    lstContent.Add("");
                    lstContent.Add(string.Format("namespace {0}", managerNameSpace));
                    lstContent.Add("{");
                    lstContent.Add(string.Format("  public class Manager{0} : BaseManager<{0}>", entityName));
                    lstContent.Add("    {");
                    lstContent.Add("    }");
                    lstContent.Add("}");
                    File.WriteAllLines(string.Format(@"{0}{1}\Manager{2}.cs", solutionPath, managerPath, entityName), lstContent, Encoding.UTF8);
                    #endregion

                    #region 生成Component层的cs文件 
                    lstContent.Clear();
                    lstContent.Add(string.Format("using {0};", domainNameSpace));
                    lstContent.Add(string.Format("using {0};", serviceNameSpace));
                    lstContent.Add(string.Format("using {0};", managerNameSpace));
                    lstContent.Add("");
                    lstContent.Add(string.Format("namespace {0}", componentNameSpace));
                    lstContent.Add("{");
                    lstContent.Add(string.Format("  public  class Component{0}:BaseComponent<{0},Manager{0}>,IService{0}", entityName));
                    lstContent.Add("    {");
                    lstContent.Add("    }");
                    lstContent.Add("}");
                    File.WriteAllLines(string.Format(@"{0}{1}\Component{2}.cs", solutionPath, componentPath, entityName), lstContent, Encoding.UTF8);
                    #endregion

                    #region 生成XML文件中的配置内容
                    xmlContent.Add(string.Format(@"<component id='{0}Service' service='{1}.IService{0},{1}' type='{2}.Component{0},{2}' isTransactional='true' />", entityName, serviceNameSpace, componentNameSpace));
                    #endregion
                }
            }
            //保存配置文件
            xmlContent.Add("    </components>");
            xmlContent.Add("</configuration>");
            File.WriteAllLines(string.Format(@"{0}{1}", solutionPath, xmlFile), xmlContent, Encoding.UTF8);

            MessageBox.Show("生成完毕,请将生成的代码文件添加到项目中.....");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
