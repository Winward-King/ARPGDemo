using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.FSM
{
	/// <summary>
	/// AI配置文件读取器工厂
	/// </summary>
	public class AIConfigurationReaderFactory
	{
        private static Dictionary<string, AIConfigurationReader> cache;
        static AIConfigurationReaderFactory()
        {
            cache = new Dictionary<string, AIConfigurationReader>();
        }

        public static Dictionary<string, Dictionary<string, string>> GetMap(string fileName)
        {
            if (!cache.ContainsKey(fileName))
            {
                cache.Add(fileName, new AIConfigurationReader(fileName));
            }
            return cache[fileName].Map;
        }
	}
}