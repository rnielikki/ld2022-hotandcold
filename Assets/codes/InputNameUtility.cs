using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.codes
{
    public static class InputNameUtility
    {
        public static bool TryGetActionBindingName(InputActionAsset inputActions, string actionName, out string name)
        {
            //Note: To make GetBindingDisplayString() work, you MUST select CORRECT BINDING TYPE (keyboard, gamepad...) in input system.
            var actionBindingName = inputActions.FindAction(actionName)?.GetBindingDisplayString();
            name = actionBindingName;
            return !string.IsNullOrEmpty(actionBindingName);
        }
        public static bool TryGetAllActionBindingNames(InputActionAsset inputActions, string actionName,
            out Dictionary<string, string> bindingNames)
        {
            var action = inputActions.FindAction(actionName);

            bindingNames = new Dictionary<string, string>();
            if (action == null) return false;
            var bindingMask = GetInputBindingMask();

            for (int i = 0; i < action.bindings.Count; i++)
            {
                var binding = action.bindings[i];
                if ((bindingMask?.Matches(binding) ?? true) && binding.isPartOfComposite && !bindingNames.ContainsKey(binding.name))
                {
                    bindingNames.Add(binding.name, action.GetBindingDisplayString(i));
                }
            }
            return bindingNames.Count != 0;

            //from InputAction.FindEffectiveBindingMask
            InputBinding? GetInputBindingMask()
            {
                if (action.bindingMask != null) return action.bindingMask;
                else if (action.actionMap.bindingMask != null) return action.actionMap.bindingMask;
                else return action.actionMap.asset.bindingMask;
            }
        }
    }
}