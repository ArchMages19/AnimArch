using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute
{
    public string Type { get; set; }
    public string Name { get; set; }
    public Attribute(string type, string name)
    {
        this.Type = type;
        this.Name = name;
    }
    public Attribute() { }

}
