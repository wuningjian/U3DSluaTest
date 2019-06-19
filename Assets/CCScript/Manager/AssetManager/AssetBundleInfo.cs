using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SLua;
using UnityEngine;

namespace SLuaTestSp
{
    [DoNotToLua]
    public class AssetBundleInfo
    {
        static private readonly string AtlasDescAssetName = "ui_atlas_desc";
        // 保存该bundle所依赖的所有bundle对应的bundleInfo
        private List<AssetBundleInfo> mDirDepsBundleList = new List<AssetBundleInfo>();

        [DoNotToLua]
        public enum AssetState
        {
            Unload,
            Loading,
            Loaded,
        }

        public AssetState State { get; private set; }
        public string AssetBundleName { get; private set; }
        private AssetBundle mAssetBundle = null;
        private bool mResourceMode = false;

        public AssetBundleInfo(string name, bool resourceMode)
        {
            State = AssetState.Unload;
            AssetBundleName = name;
            mAssetBundle = null;
            mResourceMode = resourceMode;
        }

        public void InitDependency(List<string> depList)
        {
            if (depList !=null && depList.Count > 0)
            {
                AssetManager mgr = AssetManager.Instance;
                for(int i = 0; i < depList.Count; i++)
                {
                    AssetBundleInfo info = mgr.GetBundleInfo(depList[i]);
                    mDirDepsBundleList.Add(info);
                }
            }
        }

        public T GetAssetObjWithType<T>(string name) where T : class
        {

            return null;
        }
    }
}
