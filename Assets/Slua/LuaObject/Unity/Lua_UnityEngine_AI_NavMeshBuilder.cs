﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_AI_NavMeshBuilder : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CollectSources_s(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#else
			Profiler.BeginSample(methodName);
			#endif
			#endif
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Transform),typeof(int),typeof(UnityEngine.AI.NavMeshCollectGeometry),typeof(int),typeof(List<UnityEngine.AI.NavMeshBuildMarkup>),typeof(List<UnityEngine.AI.NavMeshBuildSource>))){
				UnityEngine.Transform a1;
				checkType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.AI.NavMeshCollectGeometry a3;
				a3 = (UnityEngine.AI.NavMeshCollectGeometry)LuaDLL.luaL_checkinteger(l, 3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Collections.Generic.List<UnityEngine.AI.NavMeshBuildMarkup> a5;
				checkType(l,5,out a5);
				System.Collections.Generic.List<UnityEngine.AI.NavMeshBuildSource> a6;
				checkType(l,6,out a6);
				UnityEngine.AI.NavMeshBuilder.CollectSources(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Bounds),typeof(int),typeof(UnityEngine.AI.NavMeshCollectGeometry),typeof(int),typeof(List<UnityEngine.AI.NavMeshBuildMarkup>),typeof(List<UnityEngine.AI.NavMeshBuildSource>))){
				UnityEngine.Bounds a1;
				checkValueType(l,1,out a1);
				System.Int32 a2;
				checkType(l,2,out a2);
				UnityEngine.AI.NavMeshCollectGeometry a3;
				a3 = (UnityEngine.AI.NavMeshCollectGeometry)LuaDLL.luaL_checkinteger(l, 3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Collections.Generic.List<UnityEngine.AI.NavMeshBuildMarkup> a5;
				checkType(l,5,out a5);
				System.Collections.Generic.List<UnityEngine.AI.NavMeshBuildSource> a6;
				checkType(l,6,out a6);
				UnityEngine.AI.NavMeshBuilder.CollectSources(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function CollectSources to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
		#if DEBUG
		finally {
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.EndSample();
			#else
			Profiler.EndSample();
			#endif
		}
		#endif
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int BuildNavMeshData_s(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#else
			Profiler.BeginSample(methodName);
			#endif
			#endif
			UnityEngine.AI.NavMeshBuildSettings a1;
			checkValueType(l,1,out a1);
			System.Collections.Generic.List<UnityEngine.AI.NavMeshBuildSource> a2;
			checkType(l,2,out a2);
			UnityEngine.Bounds a3;
			checkValueType(l,3,out a3);
			UnityEngine.Vector3 a4;
			checkType(l,4,out a4);
			UnityEngine.Quaternion a5;
			checkType(l,5,out a5);
			var ret=UnityEngine.AI.NavMeshBuilder.BuildNavMeshData(a1,a2,a3,a4,a5);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
		#if DEBUG
		finally {
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.EndSample();
			#else
			Profiler.EndSample();
			#endif
		}
		#endif
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int UpdateNavMeshData_s(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#else
			Profiler.BeginSample(methodName);
			#endif
			#endif
			UnityEngine.AI.NavMeshData a1;
			checkType(l,1,out a1);
			UnityEngine.AI.NavMeshBuildSettings a2;
			checkValueType(l,2,out a2);
			System.Collections.Generic.List<UnityEngine.AI.NavMeshBuildSource> a3;
			checkType(l,3,out a3);
			UnityEngine.Bounds a4;
			checkValueType(l,4,out a4);
			var ret=UnityEngine.AI.NavMeshBuilder.UpdateNavMeshData(a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
		#if DEBUG
		finally {
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.EndSample();
			#else
			Profiler.EndSample();
			#endif
		}
		#endif
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int UpdateNavMeshDataAsync_s(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#else
			Profiler.BeginSample(methodName);
			#endif
			#endif
			UnityEngine.AI.NavMeshData a1;
			checkType(l,1,out a1);
			UnityEngine.AI.NavMeshBuildSettings a2;
			checkValueType(l,2,out a2);
			System.Collections.Generic.List<UnityEngine.AI.NavMeshBuildSource> a3;
			checkType(l,3,out a3);
			UnityEngine.Bounds a4;
			checkValueType(l,4,out a4);
			var ret=UnityEngine.AI.NavMeshBuilder.UpdateNavMeshDataAsync(a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
		#if DEBUG
		finally {
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.EndSample();
			#else
			Profiler.EndSample();
			#endif
		}
		#endif
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Cancel_s(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#else
			Profiler.BeginSample(methodName);
			#endif
			#endif
			UnityEngine.AI.NavMeshData a1;
			checkType(l,1,out a1);
			UnityEngine.AI.NavMeshBuilder.Cancel(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
		#if DEBUG
		finally {
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.EndSample();
			#else
			Profiler.EndSample();
			#endif
		}
		#endif
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AI.NavMeshBuilder");
		addMember(l,CollectSources_s);
		addMember(l,BuildNavMeshData_s);
		addMember(l,UpdateNavMeshData_s);
		addMember(l,UpdateNavMeshDataAsync_s);
		addMember(l,Cancel_s);
		createTypeMetatable(l,null, typeof(UnityEngine.AI.NavMeshBuilder));
	}
}
