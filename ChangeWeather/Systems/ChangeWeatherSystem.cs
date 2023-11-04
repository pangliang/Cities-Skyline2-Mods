using Game;
using Game.Audio;
using Game.Prefabs;
using Game.Simulation;
using Unity.Entities;
using UnityEngine.InputSystem;
using UnityEngine.Scripting;

namespace ChangeWeather.Systems
{
    public class ChangeWeatherSystem : GameSystemBase
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            CreateKeyBinding();

            UnityEngine.Debug.Log("ChangeWeatherSystem OnCreate");
        }

        private void CreateKeyBinding()
        {
            var inputAction = new InputAction("TogglePrecipitation");
            inputAction.AddCompositeBinding("ButtonWithOneModifier")
                .With("Modifier", "<Keyboard>/ctrl")
                .With("Modifier", "<Keyboard>/shift")
                .With("Button", "<Keyboard>/r");
            inputAction.performed += OnTogglePrecipitation;
            inputAction.Enable();
        }

        private void OnTogglePrecipitation(InputAction.CallbackContext obj )
        {
            ClimateSystem climateSystem = World.GetExistingSystemManaged<ClimateSystem>();
            OverridableProperty<float> precipitation = climateSystem.precipitation;
            if(precipitation.overrideState)
            {
                precipitation.overrideState = false;
            }else
            {
                precipitation.overrideState = true;
                precipitation.overrideValue = 0;
            }

            var soundQuery = GetEntityQuery(ComponentType.ReadOnly<ToolUXSoundSettingsData>());
            AudioManager.instance.PlayUISound(soundQuery.GetSingleton<ToolUXSoundSettingsData>().m_TutorialStartedSound);

            UnityEngine.Debug.Log("OnTogglePrecipitation precipitation.overrideState:" + precipitation.overrideState + ", precipitation.overrideValue:" + precipitation.overrideValue);
        }

        protected override void OnUpdate()
        {
        }

        [Preserve]
        public ChangeWeatherSystem()
        {
        }
    }
}
