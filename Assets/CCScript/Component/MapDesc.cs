using System;
using System.Collections.Generic;
using SLua;
using UnityEngine;
using SLuaTestSp;

[DoNotToLua]
[Serializable]
public class MapAssetInfo
{
    public string _bundleName;
    public string _assetName;
}

[DoNotToLua]
[Serializable]
public class MapRenderSetting
{
    public bool _fog;
    public FogMode _fogMode;
    public Color _fogColor;
    public float _fogDensity;
    public float _fogStartDistance;
    public float _fogEndDistance;
}

[DoNotToLua]
[Serializable]
public class MainDirLightInfo
{
    public bool _hasLight;
    public Color _color;
    public float _instensity;
    public Quaternion _rotation;
}

[DoNotToLua]
[Serializable]
public class MapLightmapInfo
{
    public string _name;
    public int _index;
    public Vector4 _scaleOffset;
}

[DoNotToLua]
[Serializable]
public class MapColliderItem
{
    public Vector3 _position;
    public Quaternion _rotation;
    public Vector3 _scale;
    public bool _isMeshCollider = false;
    public string _bundleName;
    public string _assetName;
}

[DoNotToLua]
[Serializable]
public class MapColliderInfo
{
    public string _name;
    public List<MapColliderItem> _itemList;
}

[DoNotToLua]
[Serializable]
public class MapElementItem
{
    public int _groupID;
    public string _name;
    public string _bundleName;
    public string _assetName;
    public Vector3 _position;
    public Quaternion _rotation;
    public Vector3 _scale;
    public List<MapLightmapInfo> _lightmapList = new List<MapLightmapInfo>();

    [NonSerialized]
    public Bounds _boundingBox;

    public void AddLightmapInfo(string key, int index, float x, float y, float z, float w)
    {
        MapLightmapInfo lightmapInfo = new MapLightmapInfo();
        lightmapInfo._name = key;
        lightmapInfo._index = index;
        lightmapInfo._scaleOffset = new Vector4(x, y, z, w);
        _lightmapList.Add(lightmapInfo);
    }

    public void AddLightmapInfo(string key, int index, Vector4 scaleOffset)
    {
        MapLightmapInfo lightmapInfo = new MapLightmapInfo();
        lightmapInfo._name = key;
        lightmapInfo._index = index;
        lightmapInfo._scaleOffset = scaleOffset;
        _lightmapList.Add(lightmapInfo);
    }
}

[DoNotToLua]
[Serializable]
public class MapElementInfo
{
    public string _name;
    public List<MapElementItem> _itemList;
}

[DoNotToLua]
[Serializable]
public class MapEffectItem
{
    public string _name;
    public string _bundle;
    public Vector3 _position;
    public Quaternion _rotation;
    public Vector3 _scale;
}

[DoNotToLua]
[Serializable]
public class MapEffectInfo
{
    public string _name;
    public List<MapEffectItem> _itemList;
}

[Serializable]
[CustomLuaClass]
public class MapDesc:ScriptableObject
{
    public string _id;
    public int _width;
    public int _height;

    [SerializeField]
    public List<MapAssetInfo> _assetList = new List<MapAssetInfo>();
    [SerializeField]
    public MapRenderSetting _renderSettings = new MapRenderSetting();
    [SerializeField]
    public MainDirLightInfo _mainDirLightInfo = new MainDirLightInfo();

    // MapColliderInfo里面就包含所有碰撞体，包括navigation(地板刚体)，height(场景中的一个个刚体)
    [SerializeField]
    public List<MapColliderInfo> _mapColliderInfoList = new List<MapColliderInfo>();

    // sky_box, terrain_root, big, middle, small
    [SerializeField]
    public List<MapElementInfo> _mapElementInfoList = new List<MapElementInfo>();

    [SerializeField]
    public List<MapEffectInfo> _mapEffectInfoList = new List<MapEffectInfo>();

    [SerializeField]
    public MapAssetInfo _lightMapAsset = null;
    [SerializeField]
    public MapAssetInfo _navigationAsset = null;

    #region Editor 用的方法
    [DoNotToLua]
    public void AddAsset(string bundleName, string assetName)
    {
        foreach (var item in _assetList)
        {
            if (item._assetName == assetName && item._bundleName == bundleName) {
                return;
            }
        }
        MapAssetInfo info = new MapAssetInfo();
        info._bundleName = bundleName;
        info._assetName = assetName;
        _assetList.Add(info);
    }

    [DoNotToLua]
    public void SetLightmapAsset(string bundleName, string assetName)
    {
        _lightMapAsset = new MapAssetInfo();
        _lightMapAsset._bundleName = bundleName;
        _lightMapAsset._assetName = assetName;
        AddAsset(bundleName, assetName);
    }

    [DoNotToLua]
    public void SetNavigationAsset(string bundleName, string assetName)
    {
        _navigationAsset = new MapAssetInfo();
        _navigationAsset._bundleName = bundleName;
        _navigationAsset._assetName = assetName;
        AddAsset(bundleName, assetName);
    }

    [DoNotToLua]
    public List<MapElementItem> GetMapElementList(string name)
    {
        foreach (var item in _mapElementInfoList)
        {
            if (item._name == name)
            {
                return item._itemList;
            }
        }
        return null;
    }

    [DoNotToLua]
    public void AddMapElementList(string name, List<MapElementItem> itemList)
    {
        foreach (var item in _mapElementInfoList)
        {
            if (item._name == name)
            {
                Debug.LogError("MapDesc Has Same Map Element Info");
                return;
            }
        }

        MapElementInfo info = new MapElementInfo();
        info._name = name;
        info._itemList = itemList;
        _mapElementInfoList.Add(info);
    }

    [DoNotToLua]
    public List<MapEffectItem> GetMapEffectList(string name)
    {
        foreach (var item in _mapEffectInfoList)
        {
            if (item._name == name)
            {
                return item._itemList;
            }
        }
        return null;
    }

    [DoNotToLua]
    public void AddMapEffectList(string name, List<MapEffectItem> itemList)
    {
        foreach (var item in _mapEffectInfoList)
        {
            if (item._name == name)
            {
                Debug.LogError("MapDesc Has Same Map Effect Info");
                return;
            }
        }

        MapEffectInfo info = new MapEffectInfo();
        info._name = name;
        info._itemList = itemList;
        _mapEffectInfoList.Add(info);
    }

    [DoNotToLua]
    public List<MapColliderItem> GetMapColliderList(string name)
    {
        foreach (var item in _mapColliderInfoList)
        {
            if (item._name == name)
            {
                return item._itemList;
            }
        }
        return null;
    }

    [DoNotToLua]
    public void AddMapColliderList(string name, List<MapColliderItem> itemList)
    {
        foreach (var item in _mapColliderInfoList)
        {
            if (item._name == name)
            {
                Debug.LogError("MapDesc Has Same Map Collider Info");
                return;
            }
        }

        MapColliderInfo info = new MapColliderInfo();
        info._name = name;
        info._itemList = itemList;
        _mapColliderInfoList.Add(info);
    }

    [DoNotToLua]
    public void RefreshDesc()
    {
        for (int i = 0; i < _mapElementInfoList.Count; i++)
        {
            RefreshElementInfo(_mapElementInfoList[i]);
        }
    }

    [DoNotToLua]
    private void RefreshElementInfo(MapElementInfo info)
    {
        float minX = float.MaxValue;
        float minZ = float.MaxValue;
        float maxX = float.MinValue;
        float maxZ = float.MinValue;

        foreach (var item in info._itemList)
        {
            if (item._boundingBox.min.x < minX)
                minX = item._boundingBox.min.x;
            if (item._boundingBox.min.z < minZ)
                minZ = item._boundingBox.min.z;
            if (item._boundingBox.max.x > maxX)
                maxX = item._boundingBox.max.x;
            if (item._boundingBox.max.z > maxZ)
                maxZ = item._boundingBox.max.z;
        }

        float deltaX = maxX - minX;
        float deltaZ = maxZ - minZ;
        float interval = 70.0f;
        int column = Mathf.CeilToInt(deltaZ / interval);
        if (column < 0)
            column = 1;

        foreach (var item in info._itemList)
        {
            if (item._boundingBox.size.z > interval || item._boundingBox.size.x > interval)
            {
                item._groupID = 1;
            }
            else
            {
                int x = Mathf.CeilToInt((item._boundingBox.center.x - minX) / interval);
                int z = Mathf.FloorToInt((item._boundingBox.center.z - minZ) / interval);
                item._groupID = z * column + x + 1;
            }
        }
    }
    #endregion

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    [UnityEngine.Scripting.Preserve]
    public static int GetAssetList(IntPtr l)
    {
        MapDesc desc = (MapDesc)LuaObject.checkSelf(l);

        LuaObject.pushValue(l, true);
        LuaDLL.lua_newtable(l);
        for (int i=0; i<desc._assetList.Count; i++)
        {
            LuaDLL.lua_pushinteger(l, i + 1);
            LuaDLL.lua_newtable(l);
            LuaDLL.lua_pushinteger(l, 1);
            LuaDLL.lua_pushstring(l, desc._assetList[i]._bundleName);
            LuaDLL.lua_settable(l, -3);
            LuaDLL.lua_pushinteger(l, 2);
            LuaDLL.lua_pushstring(l, desc._assetList[i]._assetName);
            LuaDLL.lua_settable(l, -3);
            LuaDLL.lua_settable(l, -3);
        }
        return 2; // Lua栈返回两个参数，一个true，一个完成的asset table
    }

    public int GetMapElementNum(string name)
    {
        for (int i=0; i<_mapElementInfoList.Count;i++)
        {
            if (_mapElementInfoList[i]._name == name)
            {
                return _mapElementInfoList[i]._itemList.Count;
            }
        }
        return 0;
    }

    public void LoadMapElement(string name, int index, Transform parent, bool is_static = true)
    {
        for (int i=0; i < _mapElementInfoList.Count; i++)
        {
            if (_mapElementInfoList[i]._name == name)
            {
                if (index < _mapElementInfoList[i]._itemList.Count)
                {
                    CreateMapElement(_mapElementInfoList[i]._itemList[index], parent, is_static);
                }
                return;
            }
        }
    }

    private void CreateMapElement(MapElementItem info, Transform parent, bool is_static)
    {
        GameObject prefab = AssetManager.Instance.GetGameObject(info._bundleName, info._assetName);

    }
}