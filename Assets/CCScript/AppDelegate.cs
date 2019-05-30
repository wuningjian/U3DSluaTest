using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SLua;
using System.IO;
using System.Text.RegularExpressions;

namespace SLuaTestSp
{
    public class AppDelegate : MonoBehaviour {

	    // Use this for initialization
	    void Start () {
            ScriptManager.Instance.Init();
            ScriptManager.Instance.CallFunc("CreateGameObj");
        }
	
	    // Update is called once per frame
	    void Update () {
            ScriptManager.Instance.OnUpdate();
        }


    }
}

