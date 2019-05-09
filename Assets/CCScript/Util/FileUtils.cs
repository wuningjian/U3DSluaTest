using System;
using System.Collections;
using UnityEngine;
using System.IO;

namespace SLuaTest
{
    class FileUtils
    {
        public static string CombinePath(string p1, string p2)
        {
            string path = Path.Combine(p1, p2);
            return path.Replace('\\', '/');
        }
    }
}
