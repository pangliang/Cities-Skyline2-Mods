using System.Collections.Generic;
using Game;
using Game.Audio;
using Game.Prefabs;
using Game.Reflection;
using Game.Simulation;
using Game.UI.Localization;
using Game.UI.Menu;
using Game.UI.Widgets;
using HarmonyLib;
using Unity.Assertions;
using Unity.Entities;
using UnityEngine;
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
            AddMenuOption();

            Debug.Log("ChangeWeatherSystem OnCreate");
        }

        private void AddMenuOption()
        {
            ClimateSystem climateSystem = World.GetExistingSystemManaged<ClimateSystem>();
            OptionsUISystem optionsUISystem = World.GetExistingSystemManaged<OptionsUISystem>();
            Assert.IsTrue(climateSystem != null && optionsUISystem != null);

            OptionsUISystem.Page gameplayPage = Traverse.Create(optionsUISystem)
                .Field("<options>k__BackingField")
                .GetValue<List<OptionsUISystem.Page>>()
                ?.Find(it => it.id == "Gameplay");
            Assert.IsTrue(gameplayPage != null);

            List<IWidget> items = new List<IWidget>()
            {
                new Divider(),
                new ToggleField
                {
                    displayName = LocalizedString.Value("Disable rain and snow"),
                    accessor = new DelegateAccessor<bool>(() => climateSystem.precipitation.overrideState, delegate(bool value)
                    {
                        Debug.Log("precipitation set value: " + value);
                        if(value)
                        {
                            climateSystem.precipitation.overrideState = true;
                            climateSystem.precipitation.overrideValue = 0;
                        }else
                        {
                            climateSystem.precipitation.overrideState = false;
                        }
                    })
                }
            };
            
            OptionsUISystem.Section advacedSection = gameplayPage.sections.Find(it => it.id == "Advanced");
            if (advacedSection == null)
            {
                advacedSection = new OptionsUISystem.Section()
                {
                    id = "Advanced",
                    items = items
                };
                gameplayPage.sections.Add(advacedSection);
            }
            else
            {
                advacedSection.items.AddRange(items);
            }

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

            Debug.Log("OnTogglePrecipitation precipitation.overrideState:" + precipitation.overrideState + ", precipitation.overrideValue:" + precipitation.overrideValue);
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
