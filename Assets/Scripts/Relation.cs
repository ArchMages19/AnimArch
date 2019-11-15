using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relation : MonoBehaviour
{
    public GameObject PrefabType { get; set; }
    public string FromClass { get; set; }
    public string ToClass { get; set; }

    public Relation(string fromClassId, string toClassId)
    {
        this.FromClass = fromClassId;
        this.ToClass = toClassId;
        PrefabType = null;
    }
    public Relation(string fromClassId, string toClassId, GameObject prefabType)
    {
        this.FromClass = fromClassId;
        this.ToClass = toClassId;
        this.PrefabType = prefabType;
    }
    public Relation() { }

}
