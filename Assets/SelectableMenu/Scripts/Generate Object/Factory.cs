using Generate.Elements;
using Generate.TypeElements;
using Generate.ScriptableObjectElements;

using UnityEngine;

public abstract class Factory : ScriptableObject
{
    public Element Get(TypeElement type)
    {
        var config = GetConfig(type);

        Element element = Instantiate(config.ElementToGenerate);
        element.Initialize();

        return element;
    }
    protected abstract GenerateElement GetConfig(TypeElement type);
}
