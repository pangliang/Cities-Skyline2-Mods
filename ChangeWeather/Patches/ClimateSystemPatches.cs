using Game.Simulation;
using Game;
using HarmonyLib;
using ChangeWeather.Systems;
using Game.Audio;

namespace ChangeWeather.Patches
{
    [HarmonyPatch(typeof(AudioManager), "OnGameLoadingComplete")]
    class AudioManager_OnGameLoadingCompletePatch
    {
        static void Postfix(AudioManager __instance, Colossal.Serialization.Entities.Purpose purpose, GameMode mode)
        {
            if (!GameModeExtensions.IsGameOrEditor(mode))
                return;

            UnityEngine.Debug.Log("OnGameLoadingComplete");
            __instance.World.GetOrCreateSystem<ChangeWeatherSystem>();
        }
    }
}
