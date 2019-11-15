using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextHighlighter : MonoBehaviour
{
    string startColorTag= "<color=#FF0000>";
    string endColorTag = "</color>";
    [SerializeField]
    private TMP_Text methodsText;
    string text;
    public void HighlightLine(string line)
    {
        //TODO REWORK
        text=methodsText.text;
        Debug.Log(text);
        int start, end=0;
        if (text.Contains(line))
        {
            start = text.IndexOf(line, 0);
            end = start + line.Length;
            if (end != -1)
                text=text.Insert(end, endColorTag);
            if (start != -1)
                text=text.Insert(start, startColorTag);
            methodsText.text = text;
        }
    }
    public void UnHighlightLine(string line)
    {
        //TODO REWROK
        text= methodsText.text;
        text=text.Replace(startColorTag, "");
        text=text.Replace(endColorTag, "");
        methodsText.text = text;
    }

}

