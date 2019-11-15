using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class : MonoBehaviour
{
    public string ClassName {set; get;}
    //Distance from origin
    public float OffsetX { set; get; }
    public float OffsetY { set; get; }
    public List<Attribute> attributes;
    public List<Method> methods;
    public Class() { }
    public Class(string name, List<Attribute> attributes, List<Method> methods)
    {
        ClassName = name;
        this.attributes = attributes;
        this.methods = methods;
        OffsetX = 0f;
        OffsetY = 0f;
    }
    public Class(string name, List<Attribute> attributes, List<Method> methods, float offsetX, float offsetY)
    {
        ClassName = name;
        this.attributes = attributes;
        this.methods = methods;
        this.OffsetX = offsetX;
        this.OffsetY = offsetY;
    }
}
