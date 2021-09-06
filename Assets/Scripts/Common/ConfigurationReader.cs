using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Common
{
    /// <summary>
    /// 配置文件读取器
    /// </summary>
    public class ConfigurationReader
    {
        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetConfigFile(string fileName)
        {
            string url;

            #region 分平台判断 StreamingAssets 路径
            //string url = "file://" +Application.streamingAssetsPath+ "/"+fileName;
            //如果在编译器 或者 单机中  ……
            //if(Application.platform == RuntimePlatform.Android )
            //Unity 宏标签
#if UNITY_EDITOR || UNITY_STANDALONE
            url = "file://" + Application.dataPath + "/StreamingAssets/" + fileName;
            //否则如果在Iphone下……
#elif UNITY_IPHONE
            url = "file://" + Application.dataPath + "/Raw/"+ fileName;
            //否则如果在android下……
#elif UNITY_ANDROID
            url = "jar:file://" + Application.dataPath + "!/assets/"+ fileName;
#endif
            #endregion

            WWW www = new WWW(url);
            while (true)
            {
                if (www.isDone)
                    return www.text;
            }
        }

        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="fileContent">文件内容</param>
        /// <param name="handler">行处理逻辑</param>
        public static void Reader(string fileContent, Action<string> handler)
        {
            using (StringReader reader = new StringReader(fileContent))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    handler(line);
                }
            }
        }
    }
}