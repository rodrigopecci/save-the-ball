using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject goPauseMenuUI;

    public void LoadPauseMenu()
    {
        goPauseMenuUI.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
