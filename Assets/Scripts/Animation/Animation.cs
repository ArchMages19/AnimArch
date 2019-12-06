using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Animation : Singleton<Animation>
{
    public List<Anim> animations;
    [SerializeField]
    private float animationSpeed=2f;
    private ClassDiagram classDiagram;
    [SerializeField]
    private TMP_InputField input;
    [SerializeField]
    private Slider speedSlider;
    [SerializeField]
    private TMP_Text speedLabel;
    private void Awake()
    {
        classDiagram = GameObject.Find("ClassDiagram").GetComponent<ClassDiagram>();
        animations = new List<Anim>();
        UpdateAnimationSpeed();
    }
     public IEnumerator Animate()
     {
        yield return StartCoroutine(ResolveCallFunct("ElementA", "OperationA() :void", "Visitor", "OperationA() :void", animationSpeed));
        StartCoroutine(ResolveCallFunct("Visitor", "OperationB() :void", "ElementB", "OperationB() :void", animationSpeed));

     }


    public void StartAnimation()
    {
        StartCoroutine("Animate");
    }
    public IEnumerator AnimateClass(string className, float animationLength)
    {
        HighlightClass(className, true);
        yield return new WaitForSeconds(animationLength);
        HighlightClass(className, false);

    }

    public IEnumerator AnimateMethod(string className, string methodName, float animationLength)
    {
        HighlightMethod(className, methodName, true);
        yield return new WaitForSeconds(animationLength);
        HighlightMethod(className, methodName, false);

    }
    public IEnumerator AnimateEdge(string classA, string classB, float animationLength)
    {
        HighlightEdge(classA, classB, true);
        yield return new WaitForSeconds(animationLength);
        HighlightEdge(classA, classB, false);
    }
    public void HighlightClass(string className, bool isToBeHighlighted)
    {
        GameObject node = classDiagram.FindNode(className);
        BackgroundHighlighter bh = null;
        if (node != null)
        {
            bh = node.GetComponent<BackgroundHighlighter>();
        }
        else
        {
            Debug.Log("Node " + className + " not found");
        }
        if (bh != null)
        {
            if (isToBeHighlighted)
            {
                bh.HighlightBackground();
            }
            else
            {
                bh.UnhighlightBackground();
            }
        }
        else
        {
            Debug.Log("Highligher component not found");
        }
    }
    public void HighlightMethod(string className, string methodName, bool isToBeHighlighted)
    {
        GameObject node = classDiagram.FindNode(className);
        TextHighlighter th = null;
        if (node != null)
        {
            th = node.GetComponent<TextHighlighter>();
        }
        else
        {
            Debug.Log("Node " + className + " not found");
        }
        if (th != null)
        {
            if (isToBeHighlighted)
            {
                th.HighlightLine(methodName);
            }
            else
            {
                th.UnHighlightLine(methodName);
            }

        }
        else
        {
            Debug.Log("TextHighligher component not found");
        }
    }
    public void HighlightEdge(string classA, string classB, bool isToBeHighlighted)
    {
        GameObject edge = classDiagram.FindEdge(classA, classB);
        if (edge != null)
        {
            if (isToBeHighlighted)
            {
                edge.GetComponent<UEdge>().ChangeColor(Color.red);
            }
            else
            {
                edge.GetComponent<UEdge>().ChangeColor(Color.white);
            }
        }
        else
        {
            Debug.Log(classA + " NULL Edge " + classB);
        }
    }
    public IEnumerator ResolveCallFunct(string classA,string methodA, string classB, string methodB, float speedPerAnim)
    {
        StartCoroutine(AnimateClass(classA,speedPerAnim*5));
        yield return new WaitForSeconds(speedPerAnim);
        StartCoroutine(AnimateMethod(classA,methodA,speedPerAnim*4));
        yield return new WaitForSeconds(speedPerAnim);
        StartCoroutine(AnimateEdge(classA, classB, speedPerAnim *4));
        yield return new WaitForSeconds(speedPerAnim);
        StartCoroutine(AnimateClass(classB, speedPerAnim * 4));
        yield return new WaitForSeconds(speedPerAnim);
        StartCoroutine(AnimateMethod(classB, methodB, speedPerAnim*3));
        yield return new WaitForSeconds(speedPerAnim*4);

    }
    public void UpdateAnimationSpeed()
    {
        animationSpeed =speedSlider.value;
        speedLabel.text = speedSlider.value + "s";
    }
}