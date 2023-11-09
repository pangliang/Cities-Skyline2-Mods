using System.Collections.Generic;
using Game.Citizens;
using Game.Common;
using Game.Prefabs;
using Game.Reflection;
using Game.Simulation;
using Game.UI.Localization;
using Game.UI.Menu;
using Game.UI.Widgets;
using HarmonyLib;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace TrafficReduction.Patches
{
    [HarmonyPatch]
    static class TrafficReduction_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(EconomyPrefab), MethodType.Constructor)]
        static void EconomyPrefab_Constructor_Postfix(EconomyPrefab __instance)
        {
            Debug.Log($"Constructor, __instance:{__instance.GetType().FullName}, m_TrafficReduction:{__instance.m_TrafficReduction}");
            __instance.m_TrafficReduction = 0.0f;
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(EconomyPrefab), nameof(EconomyPrefab.LateInitialize))]
        static bool EconomyPrefab_LateInitialize_Prefix(EconomyPrefab __instance, EntityManager entityManager, Entity entity)
        {
            Debug.Log($"LateInitialize, __instance:{__instance.GetType().FullName}, m_TrafficReduction:{__instance.m_TrafficReduction}");
            entityManager.SetComponentData<EconomyParameterData>(entity, new EconomyParameterData()
            {
                m_CommercialDiscount = __instance.m_CommercialDiscount,
                m_ExtractorCompanyExportMultiplier = __instance.m_ExtractorCompanyExportMultiplier,
                m_Wage0 = __instance.m_Wage0,
                m_Wage1 = __instance.m_Wage1,
                m_Wage2 = __instance.m_Wage2,
                m_Wage3 = __instance.m_Wage3,
                m_Wage4 = __instance.m_Wage4,
                m_CommuterWageMultiplier = __instance.m_CommuterWageMultiplier,
                m_CompanyBankruptcyLimit = __instance.m_CompanyBankruptcyLimit,
                m_ResidentialMinimumEarnings = __instance.m_ResidentialMinimumEarnings,
                m_UnemploymentBenefit = __instance.m_UnemploymentBenefit,
                m_Pension = __instance.m_Pension,
                m_FamilyAllowance = __instance.m_FamilyAllowance,
                m_ResourceConsumption = __instance.m_ResourceConsumption,
                m_TouristConsumptionMultiplier = __instance.m_TouristConsumptionMultiplier,
                m_WorkDayStart = __instance.m_WorkDayStart,
                m_WorkDayEnd = __instance.m_WorkDayEnd,
                m_RentReturnUneducated = __instance.m_RentReturnUneducated,
                m_RentReturnPoorlyEducated = __instance.m_RentReturnPoorlyEducated,
                m_RentReturnEducated = __instance.m_RentReturnEducated,
                m_RentReturnWellEducated = __instance.m_RentReturnWellEducated,
                m_RentReturnHighlyEducated = __instance.m_RentReturnHighlyEducated,
                m_CommercialEfficiency = __instance.m_CommercialEfficiency,
                m_IndustrialEfficiency = __instance.m_IndustrialEfficiency,
                m_ExtractorEfficiency = __instance.m_ExtractorEfficiency,
                m_IndustrialProfitFactor = __instance.m_IndustrialProfitFactor,
                m_TrafficReduction = 0.0f
            });
            return false;
        }
    }
}
