﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : Singleton<ToolManager>
{
    //CameraMovement, DiagramMovement, Record 
    public string SelectedTool { set; get; }
    public bool ZoomingIn { set; get; } = false;
    public bool ZoomingOut { set; get; } = false;
    public Color SelectedColor { set; get; }
    [SerializeField]
    private string startingSelectedColor;
    public void SelectTool(string toolName)
    {
        SelectedTool = toolName;
    }
    public void ZoomIn(bool enabled)
    {
        ZoomingIn = enabled;
    }
    public void Start()
    {
        SelectColor(startingSelectedColor);
    }
    public void ZoomOut(bool enabled)
    {
        ZoomingOut = enabled;
    }
    public void SelectColor(string colorID)
    {
        Color c;
        ColorUtility.TryParseHtmlString("#"+colorID+"ff", out c);
        SelectedColor = c;
    }
}
