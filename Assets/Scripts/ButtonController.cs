using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject panel;

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
