using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SLuaTestSp
{
    public class AssetManager:Singleton<AssetManager> 
    {
        //保存名字和对应的AssetBundleInfo,再次需要就不用重新初始化
        private Dictionary<string, AssetBundleInfo> mBundleInfoMap = new Dictionary<string, AssetBundleInfo>();
        //bundle name 和对应的依赖列表
        private Dictionary<string, List<string>> mDependencyMap = new Dictionary<string, List<string>>();

        private bool mIsResourceMode = false;


        public GameObject GetGameObject(string bundleName, string assetName)
        {
            return GetAssetObjWithType<GameObject>(bundleName, assetName);
        }

        public T GetAssetObjWithType<T>(string bundleName, string assetName) where T :class
        {
            AssetBundleInfo info = GetBundleInfo(bundleName);
            if (info != null)
            {
                return info.GetAssetObjWithType<T>(assetName);
            }
            return null;
        }

        public AssetBundleInfo GetBundleInfo(string bundleName)
        {
            AssetBundleInfo info = null;
            if (mBundleInfoMap.TryGetValue(bundleName, out info))
            {
                return info;
            }
            else
            {
                info = new AssetBundleInfo(bundleName, mIsResourceMode);
                mBundleInfoMap.Add(bundleName, info);

                List<string> depList = null;
                mDependencyMap.TryGetValue(bundleName, out depList);
                info.InitDependency(depList);
            }

            return info;
        }
    }
}
