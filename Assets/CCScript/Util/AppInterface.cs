using System.Collections;
using UnityEngine;


namespace SLuaTestSp
{
    public static class AppInterface
    {
        public delegate Coroutine StartCoroutineFunc(IEnumerator emu);
        public delegate void StopCoroutineFunc(Coroutine co);
        public delegate Component AddComponentFunc(System.Type t);

        public static StartCoroutineFunc StartCoroutine;
        public static StopCoroutineFunc StopCoroutine;
        public static AddComponentFunc AddComponent;
    }
}
