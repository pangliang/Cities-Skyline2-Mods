using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Game.Prefabs;
using HarmonyLib;
using MonoMod.Utils;
using Unity.Entities;
using UnityEngine;

namespace TargetMethodsDemo.Patches
{
    [HarmonyPatch]
    class TargetMethodsDemo_Patch
    {
        [HarmonyTargetMethods]
        static IEnumerable<MethodBase> InitializeTargetMethods()
        {
            return AccessTools.AllTypes()
                .Where(type => type.IsSubclassOf(typeof(ComponentBase)))
                .Where(type => type == typeof(Hospital) || type == typeof(School))
                .SelectMany(type => type.GetMethods())
                .Where(method => method.Name.Equals("Initialize"))
                .Cast<MethodBase>();
        }
        
        [HarmonyPrefix]
        static bool InitializePrefix(object __instance, EntityManager entityManager, Entity entity)
        {
            switch (__instance.GetType().Name)
            {
                case "Hospital":
                case "School":
                    Debug.Log($"{__instance.GetType().Name}");
                    break;
            }
            
            return true;
        }
    }
}
