using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Method
 {
    public string Name { get; set; }
    public string ReturnValue { get; set; }
    public List<string> arguments;
    public Method(string name,List<string> arguments, string returnValue)
    {
        this.Name = name;
        this.ReturnValue = returnValue;
        this.arguments = arguments;
    }
    public Method() { }
    
}

