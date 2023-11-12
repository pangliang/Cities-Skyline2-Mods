using Game.UI.Localization;
using Game.UI.Tooltip;
using HarmonyLib;

namespace Cities1Unit.Patches
{
    [HarmonyPatch]
    class NetCourseTooltipSystem_Patch
    {
        public static FloatTooltip m_Length_U;
        
        [HarmonyPatch(typeof(NetCourseTooltipSystem), "OnCreate")]
        [HarmonyPostfix]
        static void OnCreate_Postfix(NetCourseTooltipSystem __instance)
        {
            TooltipGroup m_Group = Traverse.Create(__instance).Field("m_Group").GetValue<TooltipGroup>();
            if(m_Group == null) {
                return;
            }

            m_Length_U = new FloatTooltip
            {
                icon = "Media/Glyphs/Length.svg",
                unit = "floatTwoFractions",
                label = LocalizedString.Value("U")
            };

            m_Group.children.Add(m_Length_U);

        }
        
        [HarmonyPatch(typeof(NetCourseTooltipSystem), "OnUpdate")]
        [HarmonyPostfix]
        static void OnUpdate_Postfix(NetCourseTooltipSystem __instance)
        {
            FloatTooltip m_Length = Traverse.Create(__instance).Field("m_Length").GetValue<FloatTooltip>();
            if (m_Length_U != null && m_Length != null)
            {
                m_Length_U.value = m_Length.value / 8f;
            }
        }
    }
}
