using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextInfo : MonoBehaviour
{
    public TMP_Text m_TextComponent;

    private Transform m_Transform;
    private void Start()
    {
        TMP_TextInfo textInfo = m_TextComponent.textInfo;
        
    }
}
