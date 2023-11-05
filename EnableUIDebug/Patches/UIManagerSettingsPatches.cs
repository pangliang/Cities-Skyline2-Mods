﻿using Colossal.UI;
using HarmonyLib;

namespace EnableUIDebug.Patches
{
    [HarmonyPatch(typeof(UIManager.Settings), "SetDefault")]
    class UIManagerSettings_OnCreatePatch
    {
        static void Postfix(UIManager.Settings __instance)
        {
            __instance.enableDebugger = true;
        }
    }
}
