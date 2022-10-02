using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.codes
{
    public class InputNameUpdater : MonoBehaviour
    {
        [SerializeField]
        PlayerInput _playerInput;
        [SerializeField]
        string _label;
        [SerializeField]
        string _actionName;
        [SerializeField]
        bool _isComposite;
        [SerializeField]
        TextMeshProUGUI _result;
        // Use this for initialization
        void Start()
        {

            if (_isComposite)
            {
                if (InputNameUtility.TryGetAllActionBindingNames(_playerInput.actions, _actionName, out Dictionary<string, string> bindings))
                {
                    _result.text = $"{_label}: {string.Join("/", bindings.Values)}";
                }
                else gameObject.SetActive(false);
            }
            else if(InputNameUtility.TryGetActionBindingName(_playerInput.actions, _actionName, out string name))
            {
                    _result.text = $"{_label}: {name}";
            }
            else gameObject.SetActive(false);
        }
    }
}