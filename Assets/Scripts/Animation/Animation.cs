using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Animation : Singleton<Animation>
{
    
    [SerializeField]
    private float animationSpeed=2f;
    private ClassDiagram classDiagram;
    [SerializeField]
    private TMP_InputField input; 
    private void Awake()
    {
        classDiagram = GameObject.Find("ClassDiagram").GetComponent<ClassDiagram>();
    }
    public IEnumerator Animate()
    {
        yield return StartCoroutine(AnimateClass("ElementA"));
        yield return new WaitForSeconds(animationSpeed);

        StartCoroutine(AnimateClass("ElementA"));
        yield return StartCoroutine(AnimateMethod("ElementA", "OperationA() :void"));
        yield return new WaitForSeconds(animationSpeed);

        StartCoroutine(AnimateClass("ElementA"));
        StartCoroutine(AnimateClass("Visitor"));
        StartCoroutine(AnimateMethod("ElementA", "OperationA() :void"));
        StartCoroutine(AnimateMethod("Visitor", "OperationA() :void"));
        yield return StartCoroutine(AnimateEdge("ElementA", "Visitor"));

    }


    public void StartAnimation()
    {
        StartCoroutine("Animate");
    }
    public IEnumerator AnimateClass(string className)
    {
        Debug.Log("Animating");
        GameObject node = classDiagram.FindNode(className);
        BackgroundHighlighter bh=null;
        if (node != null)
        {
            bh = node.GetComponent<BackgroundHighlighter>();
            Debug.Log("Node found");
        }
        else
            Debug.Log("Node " + className + " not found");
        if (bh != null)
        {
            bh.HighlightBackground();
          
        }
        else
            Debug.Log("Highligher not found");
        yield return new WaitForSeconds(animationSpeed);
        if (bh != null)
        {
            bh.UnhighlightBackground();
        }
    }

    public IEnumerator AnimateMethod(string className, string methodName)
    {
        Debug.Log("Animating");
        GameObject node = classDiagram.FindNode(className);
        TextHighlighter th = null;
        if (node != null)
        {
            th = node.GetComponent<TextHighlighter>();
            Debug.Log("Node found");
        }
        else
            Debug.Log("Node " + className + " not found");
        if (th != null)
        {
            Debug.Log("Highlighting method");
            th.HighlightLine(methodName);

        }
        else
            yield return null;
        yield return new WaitForSeconds(animationSpeed);
        th.UnHighlightLine(methodName);
    }
    public IEnumerator AnimateEdge(string classA, string classB)
    {
        GameObject edge = classDiagram.FindEdge(classA, classB);
        if (edge != null)
        {
            edge.GetComponent<UEdge>().ChangeColor(Color.red);
            yield return new WaitForSeconds(animationSpeed);
            edge.GetComponent<UEdge>().ChangeColor(Color.white);
        }
        else
            Debug.Log("null edge");
    }
}
