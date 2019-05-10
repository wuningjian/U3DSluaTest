using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using SLua;

namespace SLuaTestSp
{
    public class ScriptManager : Singleton<ScriptManager>
    {
        private bool mLoadFinish = false;
        private LuaSvr mLuaServer = null;
        private LuaTable mLuaGameObj = null;
        private LuaFunction mLuaUpdateFunc = null;

        public void Init()
        {
            mLuaServer = new LuaSvr();
            mLuaServer.init(null, InitComplete, LuaSvrFlag.LSF_BASIC);      
        }

        private void InitComplete()
        {
            LuaState.main.loaderDelegate = RawFileLoader;

            //string initLua = @"return require(""main"")";
            mLuaGameObj = (LuaTable)mLuaServer.start("main");
            if (mLuaGameObj != null)
            {
                mLuaUpdateFunc = (LuaFunction)mLuaGameObj["Update"];
                mLoadFinish = true;
            }
            else
            {
                Debug.LogError("ScriptManager: Load hello.lua Error");
            }

        }

        public void OnUpdate()
        {
            if (mLoadFinish) {
                mLuaUpdateFunc.call();
            }
        }

        public bool CallFunc(string name)
        {
            if (mLuaGameObj == null)
            {
                return false;
            }
            LuaFunction func = (LuaFunction)mLuaGameObj[name];
            if (func != null)
            {
                func.call();
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private byte[] RawFileLoader(string name, ref string absoluteFn)
        {
            if (Regex.IsMatch(name, "[A-Z]"))
                Debug.LogError("大写脚本名字:" + name);

            string mScriptPath = Application.dataPath + "/LuaScript/";
            string path = FileUtils.CombinePath(mScriptPath, name.Replace('.', '/') + ".lua");
            byte[] data = null;

            Debug.Log("文件路径拼接:" + path);

            if (!File.Exists(path))
            {
                Debug.LogError("文件路径文件不存在");
                return null;
            }

            data = File.ReadAllBytes(path);
            return data;

            // using(obj) using 语句允许程序员指定使用资源的对象应当何时释放资;obj须内部实现了IDisposable接口，用于释放obj
            //using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            //{
            //    byte[] data = new byte[stream.Length];
            //    stream.Read(data, 0, data.Length);
            //    return data;
            //}


        }

        public void StartLoadScript()
        {
            if (mLoadFinish)
                return;

            
        }

        private void LoadScriptRawMode()
        {

        }
    }
}
