using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundHighlighter : MonoBehaviour {

	public Color highlightColor;
	private Color defaultColor;

	private void Awake()
	{
		defaultColor = GetComponentInChildren<Image>().color;
	}

	public void HighlightOutline()
	{
		GetComponentInChildren<Outline>().enabled = true;
	}

	public void HighlightBackground()
	{
        highlightColor = ToolManager.Instance.SelectedColor;
		GetComponentInChildren<Image>().color = highlightColor;
	}

	public void UnhighlightOutline()
	{
		GetComponentInChildren<Outline>().enabled = false;
	}

	public void UnhighlightBackground()
	{
		GetComponentInChildren<Image>().color = defaultColor;
	}

}
