using System;

namespace cudo
{
    class InfoList
    {
        public static string[] infos = new string[]
        {
            "Copyright © Catrol 2021, Cudone", // -c
            "Cudone Project use MIT License.", // -c
            "Use argument '-h' to see help doc.", // -h
            "Hello Cudone !!!", // -hello
            "See you", // ending
        };

        public static string errHead = "Err :: code(%index%) :: ";

        public static string[] errs = new string[]
        {
            "Fatal Error !", // 致命错误
            "No input file !", // 没有输入文件
            "Command not found !", // 没有找到命令

            "No pair of '<预处理>' with '</预处理>'",
            "No pair of '<代码>' with '</代码>'",
            "Not a right construction of '令/使 %s 为()'",
            "Expected ';' at line : "
        };

        public static string GetInfo(int index) => infos[index];

        public static string GetErrInfo(int errCode) => ($"{errHead.Replace("%index%", $"{errCode}")}{errs[errCode]}");
    }
}