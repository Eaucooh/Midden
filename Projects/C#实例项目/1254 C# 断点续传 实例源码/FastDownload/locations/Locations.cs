using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//设置Locations类的属性为[Serializable] 标记为可序列化
//此类可用于保存续传信息的状态
[Serializable]
public class Locations
{
    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="i">记录数据的开始位置</param>
    /// <param name="i2">记录数据的结束位置</param>
    public Locations(int i, int i2)//构造方法
    {
        start = i;
        end = i2;
    }
    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="i">记录数据的开始位置</param>
    /// <param name="i2">记录数据的结束位置</param>
    /// <param name="url">记录数据下载的地址</param>
    /// <param name="filename">记录下载文件的名称</param>
    /// <param name="filesize">记录下载文件的总大小</param>
    /// <param name="ls">引用一个新的续传点</param>
    public Locations(int i, int i2, string url,
        string filename,long filesize,Locations ls)//构造方法
    {
        start = i;
        end = i2;
        this.url = url;
        this.filename = filename;
        this.ls = ls;
        this.filesize = filesize;
    }
    private int start;//记录数据的开始位置
    private int end;//记录数据的结束位置
    private string url;//记录数据下载的地址
    private string filename;//记录下载文件的名称
    private Locations ls;//引用一个新的续传点
    private long filesize;//记录下载文件的总大小
    public long Filesize//记录下载文件的总大小
    {
        get { return filesize; }
        set { filesize = value; }
    }
    public Locations Ls//引用一个新的续传点
    {
        get { return ls; }
        set { ls = value; }
    }
    public string Filename//记录下载文件的名称
    {
        get { return filename; }
        set { filename = value; }
    }
    public string Url//记录数据下载的地址
    {
        get { return url; }
        set { url = value; }
    }
    public int End//记录数据的结束位置
    {
        get { return end; }
        set { end = value; }
    }
    public int Start//记录数据的开始位置
    {
        get { return start; }
        set { start = value; }
    }
}
