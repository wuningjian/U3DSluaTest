using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] // 非运行时也能触发效果
[RequireComponent(typeof(Camera))]//屏幕后处理特效一般都需要绑定在摄像机上
public class PostEffectBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Shader shader = null;
    private Material _material = null;
    public Material _Material
    {
        get
        {
            if (_material == null)
                _material = GenerateMaterial(shader);
            return _material;
        }
    }

    protected Material GenerateMaterial(Shader shader)
    {
        if (shader == null)
            return null;
        if (shader.isSupported == false)
            return null;
        Material material = new Material(shader);
        material.hideFlags = HideFlags.DontSave;
        if (material)
        {
            return material;
        }
        return null;
    }
}
