using Generate.TypeElements;
using Generate.ScriptableObjectElements;

using UnityEngine;

[CreateAssetMenu(menuName ="Generate Factory element", fileName = "new Factory")]
public class GeneralElementFactory : Factory
{
    [SerializeField] private GenerateElement _cubeElement, _sphereElement;
    protected override GenerateElement GetConfig(TypeElement type)
    {
        switch (type)
        {
            case TypeElement.Cube:
                return _cubeElement;
            case TypeElement.Sphere:
                return _sphereElement;
            default:
                throw new System.Exception("не существующий типа объекта");
                //return null;
        }
    }
}