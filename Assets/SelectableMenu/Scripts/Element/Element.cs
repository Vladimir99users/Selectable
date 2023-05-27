using UnityEngine;
using UnityEngine.Events;

namespace Generate.Elements
{
    using TypeElements;
    public abstract class Element : MonoBehaviour, IManipulation
    {
        [SerializeField] protected TypeElement _typeElement;
        [SerializeField] protected Material _defualtMaterial;
        [SerializeField] protected Material _selectedMaterial;
        [SerializeField] protected GameObject _gameObject;

        public TypeElement TypeElement {get => _typeElement; }
        public UnityAction<bool> OnSelectedElement { get; set ; }
        public MeshRenderer Render { get; set; }
        
        public bool IsSelected { get; set; }
        public bool IsVisible { get ; set ; }

        public virtual void Initialize()
        {
            IsSelected = false;
            IsVisible = true;

            Render = _gameObject.GetComponent<MeshRenderer>();
        }

        private void OnEnable() 
        {    
            OnSelectedElement += SelectElement;
        }

        private void OnDisable() 
        {
            OnSelectedElement -= SelectElement;
        }

        public virtual void SelectElement(bool state)
        {
            IsSelected = state;

            if(state == true)
            {
                Color currentColor = Render.material.color;
                currentColor = new Color(_selectedMaterial.color.r,_selectedMaterial.color.g,_selectedMaterial.color.b,currentColor.a);
                Render.material.color = currentColor;
            } else 
            {
                Color currentColor = Render.material.color;
                currentColor = new Color(_defualtMaterial.color.r,_defualtMaterial.color.g,_defualtMaterial.color.b,currentColor.a);
                Render.material.color = currentColor;
            }

            
        }

        public virtual void VisibleElement()
        {
            IsVisible = !IsVisible;
            _gameObject.SetActive(IsVisible);
        }
    }
}
