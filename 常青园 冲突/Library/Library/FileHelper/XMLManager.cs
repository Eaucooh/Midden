using System.IO;
using System.Xml;

namespace Library.FileHelper
{
    public class XMLManager
    {
        public XmlDocument doc = new XmlDocument();

        private string DocPath { get; set; }
        public XmlNode rootNode;

        /// <summary>
        /// 传入路径的构造函数
        /// </summary>
        /// <param name="path">XML文档路径</param>
        public XMLManager(string path)
        {
            DocPath = path;
            Initialize();
        }

        /// <summary>
        /// 初始化XML文档
        /// </summary>
        public void Initialize()
        {
            doc.Load(DocPath);
            rootNode = doc.DocumentElement.FirstChild;
        }

        /// <summary>
        /// All - 包括根节点在内所有节点全部清除
        /// ExceptRootNode - 清除根节点的所有子节点
        /// EvenFile - 连同磁盘上的XML文档一起清除
        /// </summary>
        public enum ClearScope { All, ExceptRootNode, EvenFile }

        /// <summary>
        /// 添加节点至指定节点的子节点列表末尾
        /// </summary>
        /// <param name="father">指定节点</param>
        /// <param name="son">追加节点</param>
        public void AppendNode(XmlNode father, XmlNode son)
        {
            father.AppendChild(son);
        }

        /// <summary>
        /// 以指定的范围清除XML文档
        /// </summary>
        /// <param name="cs">范围</param>
        public void Clear(ClearScope cs)
        {
            switch (cs)
            {
                case ClearScope.All:
                    if(!FileHelper.WriteIn(DocPath, "<?xml version=\"1.0\" encoding=\"utf - 8\" ?>").SoF)
                    {
                        throw new System.Exception("Wrong write in.");
                    }
                    break;
                case ClearScope.ExceptRootNode:
                    rootNode.RemoveAll();
                    break;
                case ClearScope.EvenFile:
                    File.Delete(DocPath);
                    break;
            }
        }

        /// <summary>
        /// 保存XML文档
        /// </summary>
        /// <returns>保存是否成功</returns>
        public Exp.Exception_Simple.Returning Save()
        {
            try
            {
                doc.Save(DocPath);
                return new Exp.Exception_Simple.Returning() { SoF = true, Ex = null };
            }
            catch (System.Exception o)
            {
                return new Exp.Exception_Simple.Returning() { SoF = false, Ex = o };
            }
        }

        /// <summary>
        /// 创建一个具有指定标签的节点
        /// </summary>
        /// <param name="tag">指定标签</param>
        /// <returns>节点</returns>
        public XmlNode CreateNode(string tag)
        {
            return doc.CreateNode("element", tag, "");
        }

        /// <summary>
        /// 向指定节点的属性列中添加一个属性
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="name">属性名</param>
        /// <param name="content">属性内容</param>
        public XmlNode AddAttribute(XmlNode node, string name, string content)
        {
            XmlAttribute xa = doc.CreateAttribute(name);
            xa.InnerText = content;
            node.Attributes.Append(xa);
            return node;
        }
    }
}
