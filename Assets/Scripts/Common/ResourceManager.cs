using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Common
{
    /// <summary>
    /// 资源管理器
    /// </summary>
    public class ResourceManager
    {
        private static Dictionary<string, string> configMap;

        //作用：初始化类的静态数据成员
        //时机：类被加载时执行一次
        static ResourceManager()
        {
            configMap = new Dictionary<string, string>();

            //加载文件
            string fileContent = ConfigurationReader.GetConfigFile("ConfigMap.txt");

            //解析文件(string  --->  Dictionary<string,string>)
            //BuildMap(fileContent);
            ConfigurationReader.Reader(fileContent, BuildMap);
        }

        private static void BuildMap(string line)
        {
            string[] keyValue = line.Split('=');
            configMap.Add(keyValue[0], keyValue[1]);
        }

        //private static void BuildMap(string fileContent)
        //{
        //    configMap = new Dictionary<string, string>();
        //    //文件名=路径\r\n文件名=路径
        //    //StringReader 字符串读取器，提供了逐行读取字符串功能
        //    using (StringReader reader = new StringReader(fileContent))
        //    {
        //        string line;
        //        //1.读一行，满足条件则解析
        //        while ((line =reader.ReadLine()) != null)
        //        {
        //            //解析行数据
        //            string[] keyValue = line.Split('=');
        //            //文件名  keyValue[0]   路径 keyValue[1]   
        //            configMap.Add(keyValue[0], keyValue[1]); 
        //        }

        //        //1先读一行
        //        //string line = reader.ReadLine();
        //        //2不为空则解析/4再判断条件
        //        //while (line !=null)
        //        //{ 
        //        //    string[] keyValue = line.Split('=');
        //        //    //文件名  keyValue[0]   路径 keyValue[1]   
        //        //    configMap.Add(keyValue[0], keyValue[1]);
        //        //3再读一行
        //        //    line = reader.ReadLine();
        //        //}
        //    }//当程序退出using代码块，将自动调用 reader.Dispose() 方法
        //}

        public static T Load<T>(string prefabName) where T : UnityEngine.Object
        {
            //prefabName  --->  prefabPath
            //如果字典中 不包含指定key 则退出
            if (!configMap.ContainsKey(prefabName)) return null;
            string prefabPath = configMap[prefabName];
            return Resources.Load<T>(prefabPath);
        }
    }
}