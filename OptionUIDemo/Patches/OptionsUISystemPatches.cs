using System.Collections.Generic;
using Game.Reflection;
using Game.UI.Localization;
using Game.UI.Menu;
using Game.UI.Widgets;
using HarmonyLib;
using UnityEngine;

namespace OptionUIDemo.Patches
{
    [HarmonyPatch(typeof(OptionsUISystem), "OnCreate")]
    class OptionsUISystem_OnCreatePatch
    {
        private static double floatSliderFieldValue = 0;
        private static bool toggleFieldValue = false;
        static void Postfix(OptionsUISystem __instance)
        {
            Debug.Log("OptionsUISystem OnCreate");
            
            OptionsUISystem.Section section = new OptionsUISystem.Section
            {
                id = "Advanced",
                items =
                {
                    new Button
                    {
                        path = "input.resetbutton",
                        displayName = LocalizedString.Id("Options.OPTION[input.resetbutton]"),
                        action = delegate
                        {
                            Debug.Log("Button click");
                        }
                    },
                    new IntSliderField
                    {
                        displayName = LocalizedString.Value("IntSliderField displayName"),
                        tooltip = LocalizedString.Value("FloatSliderField tooltip"),
                        min = 0,
                        max = 100,
                        step = 3,
                        accessor = new DelegateAccessor<int>(() => (int)floatSliderFieldValue, delegate(int value)
                        {
                            Debug.Log("FloatSliderField set value: " + value);
                            floatSliderFieldValue = value;
                        })
                    },
                    new ToggleField
                    {
                        displayName = LocalizedString.Value("ToggleField displayName"),
                        tooltip = LocalizedString.Value("ToggleField tooltip"),
                        accessor = new DelegateAccessor<bool>(() => toggleFieldValue, delegate(bool value)
                        {
                            Debug.Log("ToggleField set value: " + value);
                            toggleFieldValue = value;
                        })
                    }
                }
            };

            List<OptionsUISystem.Page> options = Traverse.Create(__instance).Field("<options>k__BackingField").GetValue<List<OptionsUISystem.Page>>();
            if (options == null)
            {
                Debug.Log("options is null");
                return;
            }
            
            options.Add(new OptionsUISystem.Page()
            {
                id = "Test",
                sections = {section}
            });
        }
    }
}
