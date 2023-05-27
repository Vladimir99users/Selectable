using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Generate
{
    using Elements;

    public class UIMenu : MonoBehaviour
    {
        [Header("настройка верхней панели")]

        [SerializeField] private Button _switchVisibleObjectButton;
        [SerializeField] private Toggle _selectAllObject;


        [Space]
        [Header("Кнопки для прозрачности")]
        [SerializeField] private Button _firstAlpha;
        [SerializeField] private Button _secondAlpha;
        [SerializeField] private Button _thirdAlpha;
        [SerializeField] private Button _fourtingAlpha;
        [SerializeField] private Button _fiftenAlpha;

        [Space]
        [Header("Настройки для генерации объектов")]
        [SerializeField] private UIElement _prefabsElement;
        [SerializeField] private Transform _parentTransform;

        


        private List<IManipulation> _allObject;

        private Dictionary<IManipulation,UIElement> _testing = new Dictionary<IManipulation, UIElement>();

        private void Start() 
        {
            _firstAlpha.onClick.AddListener(delegate {ChangeAlphaMaterial(1); });
            _secondAlpha.onClick.AddListener(delegate {ChangeAlphaMaterial(0.75f); });
            _thirdAlpha.onClick.AddListener(delegate {ChangeAlphaMaterial(0.5f); });
            _fourtingAlpha.onClick.AddListener(delegate {ChangeAlphaMaterial(0.25f); });
            _fiftenAlpha.onClick.AddListener(delegate {ChangeAlphaMaterial(0.1f); });


            _switchVisibleObjectButton.onClick.AddListener(delegate {VisibleElement(); });


            _selectAllObject.onValueChanged.AddListener(SelectAllElement);
        }
        public void Initialize(List<IManipulation> allObject)
        {
            _allObject = allObject;

            if(_allObject is null || _allObject.Count == 0) return;

            GenerateUIElementInBoard(); 
        }


        private void GenerateUIElementInBoard()
        {
            for(int i = 0; i < _allObject.Count;i++)
            {
                UIElement element = Instantiate(_prefabsElement, _parentTransform);
                element.Initialize(_allObject[i]);

                _testing.Add(_allObject[i],element);
            }
        }


        private void ChangeAlphaMaterial(float alpha)
        {
            for(int i = 0; i < _allObject.Count;i++)
            {
                if(_allObject[i].IsSelected == true)
                {
                    Color currentColor = _allObject[i].Render.material.color;
                    currentColor.a = alpha;
                   _allObject[i].Render.material.color = currentColor; 
                }
                
            }
        }

        private void SelectAllElement(bool state)
        {
            for(int i = 0; i < _allObject.Count; i++)
            {
                _testing[_allObject[i]].SwitchState.isOn = state;
                _testing[_allObject[i]].SwitchState.onValueChanged?.Invoke(state);
            }
        }

        private void VisibleElement()
        {
            for(int i = 0; i < _allObject.Count;i++)
            {
                if(_allObject[i].IsSelected == true)
                {
                    _allObject[i].VisibleElement();
                    _testing[_allObject[i]].OnSwitchColorImage(_allObject[i].IsVisible);
                }
                
            }
        }
    }

}
            //_prefabsElement.SwitchState.onValueChanged.AddListener();