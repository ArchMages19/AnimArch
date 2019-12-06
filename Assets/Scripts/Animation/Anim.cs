using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    public string Code { set; get; }
    public string NameTyped { set; get; }
    public Anim(string name, string code)
    {
        Code = code;
        NameTyped = name;
    }
    public Anim() { }

}
