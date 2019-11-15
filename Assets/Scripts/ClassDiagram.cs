using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class ClassDiagram : MonoBehaviour
{
    public GameObject graphPrefab;
    private Graph graph;
    public GameObject classPrefab;
    public GameObject associationPrefab;
    public GameObject dependsPrefab;
    public GameObject generalizationPrefab;
    public GameObject implementsPrefab;

    private List<Class> Classes;
    private List<Relation> Relations;
    private Dictionary<string, GameObject> nodes;
    private Dictionary<string, GameObject> rels;
    private void Awake()
    {
        nodes = new Dictionary<string, GameObject>();
        rels = new Dictionary<string, GameObject>();
        Classes = new List<Class>();
        Relations = new List<Relation>();
    }
    void Start()
    {
        //Instantiate graph
        var go = GameObject.Instantiate(graphPrefab);
        graph = go.GetComponent<Graph>();

        //Generate
        FillTestData();
        Generate();
        ManualLayout();
    }

    //Setup Lists for OOANS EXAMPLE 
    private void FillTestData()
    {
        //Seting up values for Classes OOANS example
        Method accept= new Method("Accept", new List<string> { "aVisitor" }, "void"); 
        Method visitA = new Method("Visit", new List<string> { "ElementA" }, "void");
        Method visitB = new Method("Visit", new List<string> { "ElementB" }, "void");
        Method operationA=new Method("OperationA", null, "void");
        Method operationB = new Method("OperationB", null, "void");
        List<Method> methods;
        Class temp;

        //First Element
        methods = new List<Method>();
        methods.Add(accept);
        temp=new Class("anObjectStructure",null,methods, -93.2f/2, -31.6f/2);
        Classes.Add(temp);

        //Second Element
        methods = new List<Method>();
        methods.Add(accept);
        methods.Add(visitA);
        methods.Add(operationA);
        temp = new Class("ElementA", null, methods, 58.2f/2, 282.7f/2);
        Classes.Add(temp);

        //Third Element
        methods = new List<Method>();
        methods.Add(accept);
        methods.Add(visitB);
        methods.Add(operationB);
        temp = new Class("ElementB", null, methods,94.4f/2,-370.46f/2);
        Classes.Add(temp);

        //Fourth Element
        methods = new List<Method>();
        methods.Add(visitA);
        methods.Add(visitB);
        methods.Add(operationA);
        methods.Add(operationB);
        temp = new Class("Visitor", null, methods,548f/2,-30.8f/2);
        Classes.Add(temp);

        //Seting up values for Relations OOANS example
        Relation objToA = new Relation("anObjectStructure", "ElementA", associationPrefab);
        Relation objToB = new Relation("anObjectStructure", "ElementB", associationPrefab);
        Relation aToVisitor = new Relation("ElementA", "Visitor", associationPrefab);
        Relation bToVisitor = new Relation("ElementB", "Visitor", associationPrefab);
        Relations.Add(objToA);
        Relations.Add(objToB);
        Relations.Add(aToVisitor);
        Relations.Add(bToVisitor);
    }

    //Auto arrange objects in space
    public void AutoLayout()
    {
        //TODO better automatic Layout
        graph.Layout();
    }

    public void ManualLayout()
    {
        foreach(Class c in Classes)
        {
            nodes[c.ClassName].GetComponent<RectTransform>().position = new Vector3(c.OffsetX, c.OffsetY);
        }
    }
    private void Generate()
    {
        //Render classes
        for(int i = 0; i < Classes.Count; i++)
        {
            //Setting up
            var node=graph.AddNode();
            node.name = Classes[i].ClassName;
            var background = node.transform.Find("Background");
            var header = background.Find("Header");
            var attributes = background.Find("Attributes");
            var methods = background.Find("Methods");
            
            // Printing the values into diagram
            header.GetComponent<TextMeshProUGUI>().text = Classes[i].ClassName;
            
            //Attributes
            if (Classes[i].attributes!=null)
                foreach (Attribute attr in Classes[i].attributes)
                {
                    attributes.GetComponent<TextMeshProUGUI>().text += attr.Name +": "+attr.Type+ "\n";
                }


            //Methods
            //TESTUJEM
            //
            if (Classes[i].methods != null)
                foreach (Method method in Classes[i].methods)
                {
                    string arguments="(";
                    if(method.arguments!=null)
                        for(int d = 0; d < method.arguments.Count; d++)
                        {
                            if (d < method.arguments.Count - 1)
                                arguments += (method.arguments[d] + ", ");
                            else arguments += (method.arguments[d]);
                        }
                        arguments += ")";

                    methods.GetComponent<TextMeshProUGUI>().text += method.Name + arguments + " :" + method.ReturnValue+"\n";
                }

            //Add Class to Dictionary 
            nodes.Add(node.name, node);
            
        }

        //Render Relations between classes
        foreach (Relation rel in Relations)
        {
            GameObject prefab = rel.PrefabType;
            if (prefab == null)
                prefab = associationPrefab;
            if (nodes[rel.FromClass] != null && nodes[rel.ToClass] != null)
            {
                GameObject edge=graph.AddEdge(nodes[rel.FromClass], nodes[rel.ToClass], rel.PrefabType);
                rels.Add(rel.FromClass + "/" + rel.ToClass, edge);
            }
            else
                Debug.Log("Cant find specified Edge in Dictionary");
        }
    }

    public Class FindClassByName(String searchedClass)
    {
        Class result=null;
        foreach(Class c in Classes)
        {
            if (c.ClassName.Equals(searchedClass))
            {
                result = c;
                return result;
            }
        }
        Debug.Log("Class " + searchedClass+ " not found");
        return null;
    }
    public Method FindMethodByName(String searchedClass,String searchedMethod)
    {
        Method result = null;
        Class c = FindClassByName(searchedClass);
        if(c==null)
            return null;
        foreach(Method m in c.methods)
        {
            if (m.Name.Equals(searchedMethod))
            {
                result = m;
                return result;
            }
        }
        Debug.Log("Method " + searchedMethod + "not found");
        return null;
    }
    public GameObject FindNode(String className)
    {
        GameObject g;
        g = nodes[className];
        return g;
    }
    public GameObject FindEdge(string classA, string classB)
    {
        GameObject g;
        foreach(Relation relation in Relations)
        {
            if(relation.FromClass.Equals(classA)&&relation.ToClass.Equals(classB))               
            {
                g = rels[classA+"/"+classB];
                return g;
            }
            if (relation.FromClass.Equals(classB) && relation.ToClass.Equals(classA))
            {
                g= rels[classB + "/" + classA];
                return g;
            }
        }
        Debug.Log("Relation between "+classA+" and "+classB+" not found.");
        return null;

    }


}
