using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PopEye.WPF.Controls
{
    public class MarkdownHelper
    {
        public string Content { get; set; }

        public ElementsList GetElements() => new ElementsList(Content);

        public static ElementsList GetElements(string content) => new MarkdownHelper()
        {
            Content = content
        }.GetElements();
    }

    public class ElementsList
    {
        private Dictionary<Type, object> els = new Dictionary<Type, object>();

        public ElementsList(string content)
        {
            content.Replace("\r\n", "₡");
            char[] sets = content.ToCharArray();
            for (int i = 0; i < sets.Length; i++)
            {
                switch (sets[i])
                {
                    case '#':
                        int level = 1, index = i + 1, flag = i + 1;
                        while (true)
                        {
                            if(sets[index] == '#')
                            {
                                level++;
                                index++;
                            }
                            else
                            {
                                flag = index;
                                break;
                            }
                        }
                        while (true)
                        {
                            if (!(sets[flag] == '\r' || sets[flag] == '\n'))
                            {
                                index += 2;
                                break;
                            }
                            else
                            {
                                flag++;
                            }
                        }
                        string c = "";
                        for (int j = index; j < flag; j++)
                        {
                            c += sets[j];
                        }
                        els.Add(Type.Tag, new Tag()
                        {
                            Level = level,
                            content = c
                        });
                        i = flag;
                        break;
                }
            }
        }
    }

    public enum Type
    {
        Tag
    }

    public struct Tag
    {
        public int Level { get; set; }

        public string content { get; set; }
    }
}
