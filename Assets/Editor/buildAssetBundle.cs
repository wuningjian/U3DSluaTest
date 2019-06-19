using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildAssetBundle
{
    [MenuItem("AssetBundle/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("Assets/ABs", BuildAssetBundleOptions.CollectDependencies, BuildTarget.Android);
    }
}
