using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject animationScreen;
    [SerializeField]
    private GameObject mainScreen;
    [SerializeField]
    private GameObject savePanel;
    [SerializeField]
    private TMP_InputField  saveInputField;
    [SerializeField]
    private Button saveBtn;
    [SerializeField]
    private TMP_Dropdown animationsDropdown;
    [SerializeField]
    private TMP_InputField scriptCode;

    public void UpdateAnimations()
    {
        List<string> options = new List<string>();
        foreach (Anim anim in Animation.Instance.animations)
        {
            options.Add(anim.NameTyped);
        }
        animationsDropdown.ClearOptions();
        animationsDropdown.AddOptions(options);
    }
    public void StartAnimate()
    {
        //TODO interactive start
        animationScreen.SetActive(true);
        mainScreen.SetActive(false);
    }
    public void EndAnimate()
    {
        //TODO interactive end
        animationScreen.SetActive(false);
        mainScreen.SetActive(true);
        saveBtn.interactable = false;
    }
    public void SaveExit()
    {
        saveInputField.text = "";
        savePanel.SetActive(false);
    }

    public void CheckScript() {
        //TODO CHECK SCRIPT
        saveBtn.interactable = true;       
    }
    public void UnCheckScript()
    {
        saveBtn.interactable = false;
    }
    public void SaveEnter()
    {
        savePanel.SetActive(true);
    }
    public void SaveAnimation()
    {
        Anim newAnim = new Anim(saveInputField.text, scriptCode.text);
        Animation.Instance.animations.Add(newAnim);
        
        UpdateAnimations();
        SaveExit();
        EndAnimate();
    }
}
