using UnityEngine;

namespace Generate.Elements
{
    public interface ISelectable
    {
        public bool IsSelected {get; set;}
        public MeshRenderer Render {get;set;}
        public void SelectElement(bool state);

    }
}
