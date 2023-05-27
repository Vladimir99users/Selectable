using UnityEngine;
using UnityEngine.UI;

namespace Generate
{
    using Elements;
    public class UIElement : MonoBehaviour
    {
        public Toggle SwitchState;
        public Image IsState;

        private Color _defualtColor => Color.gray;
        private Color _changeColor => Color.cyan;


        public UnityEngine.Events.UnityAction<bool> OnSwitchColorImage;

        private ISelectable _myElement;

        public void Initialize(ISelectable myElement)
        {
            _myElement = myElement;
            SwitchState.onValueChanged.AddListener(Switch);
            
            SwitchImageColor(true);
        }

        private void OnEnable() 
        {
            OnSwitchColorImage += SwitchImageColor;
        }

        private void OnDisable()
        {
            OnSwitchColorImage -= SwitchImageColor;
        }
        private void Switch(bool state)
        {
            _myElement.SelectElement(state);
        }

        private void SwitchImageColor(bool state)
        {
            if(state == true)
            {
                IsState.color = _changeColor;
            } else
            {
                IsState.color = _defualtColor;
            }
        }
    }

}