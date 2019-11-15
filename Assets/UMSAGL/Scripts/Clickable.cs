using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public class GameObjectEvent : UnityEvent<GameObject> { };
public class Clickable : MonoBehaviour
{
    public GameObjectEvent triggerHighlighAction;
    public GameObjectEvent triggerUnhighlighAction;
    private Vector3 screenPoint;
    private Vector3 offset;

    private bool selectedElement = false;


    private void OnMouseDown()
    {
        string temp = ToolManager.Instance.SelectedTool;
        if (temp == "DiagramMovement")
            OnClassSelected();
    }

    private void OnClassSelected()
    {
        selectedElement = true;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseUp()
    {
        selectedElement = false;
    }

    void OnMouseDrag()
    {
        if (selectedElement == false || ToolManager.Instance.SelectedTool != "DiagramMovement")
        {
            return;
        }

        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && ToolManager.Instance.SelectedTool == "Highlighter")
        {
            triggerHighlighAction.Invoke(gameObject);
        }
        if (Input.GetMouseButtonDown(1) && ToolManager.Instance.SelectedTool == "Highlighter")
        {
            triggerUnhighlighAction.Invoke(gameObject);
        }
    }
}