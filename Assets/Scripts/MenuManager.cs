using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject animationScreen;
    [SerializeField]
    private GameObject mainScreen;
    public void StartAnimate()
    {
        animationScreen.SetActive(true);
        mainScreen.SetActive(false);
    }
    public void EndAnimate()
    {
        animationScreen.SetActive(false);
        mainScreen.SetActive(true);
    }

}
