using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generate.ScriptableObjectElements
{
    using Elements;
    using TypeElements;

    [CreateAssetMenu(menuName ="Generate element", fileName = "new element")]
    public class GenerateElement : ScriptableObject
    {
        [SerializeField] private Element _elementToGenerate;
        [SerializeField] private TypeElement _typeElement => _elementToGenerate.TypeElement;


        public Element ElementToGenerate {get => _elementToGenerate; }
    }

}

