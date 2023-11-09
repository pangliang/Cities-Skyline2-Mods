using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Game.Pathfind;
using Game.Simulation;
using Game.Vehicles;
using HarmonyLib;
using HarmonyLib.Tools;
using Unity.Burst.Intrinsics;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace TargetMethodsDemo.Patches
{
    // [HarmonyPatch]
    // class TargetMethodsDemo_Patch
    // {
    //     [HarmonyTargetMethods]
    //     static IEnumerable<MethodBase> FindTargetMethods()
    //     {
    //         return AccessTools.AllTypes()
    //             .Where(type => type.IsNested && type.Name.Contains("GoToWorkJob"))
    //             .SelectMany(type => type.GetMethods())
    //             .Where(method => method.Name.Equals("Execute"))
    //             .Cast<MethodBase>();
    //     }
    //     
    //     [HarmonyPrefix]
    //     static bool TargetMethodPrefix(object __instance, in ArchetypeChunk chunk,
    //         int unfilteredChunkIndex,
    //         bool useEnabledMask,
    //         in v128 chunkEnabledMask)
    //     {
    //         Debug.Log($"TargetMethodPrefix===========================");
    //         Debug.Log($"{__instance.GetType().Name}");
    //         
    //         return true;
    //     }
    // }
}
