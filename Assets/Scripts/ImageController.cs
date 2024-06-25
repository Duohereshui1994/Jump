using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ImageController : MonoBehaviour
{
    [SerializeField] GameObject image;
    public void CloseImage()
    {
        image.SetActive(false);
    }
}
