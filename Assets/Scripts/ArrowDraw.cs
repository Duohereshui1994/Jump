using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{
    [SerializeField] private Image arrowImage;                                                        //箭头图片
    private Vector3 clickPosition;                                                                    //鼠标点击位置

    private void Start()
    {
        arrowImage.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            arrowImage.rectTransform.sizeDelta = new Vector2(0, 0);
            arrowImage.gameObject.SetActive(true);
            clickPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {

            Vector3 dist = clickPosition - Input.mousePosition;                                     //鼠标点击位置与鼠标松开位置的距离

            float size = dist.magnitude;                                                            //鼠标点击位置与鼠标松开位置的距离的大小

            float angleRad = Mathf.Atan2(dist.y, dist.x);                                           //鼠标点击位置与鼠标松开位置的角度

            arrowImage.rectTransform.position = clickPosition;                                      //箭头图片的位置

            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);   //箭头图片的角度

            arrowImage.rectTransform.sizeDelta = new Vector2(size, size);                            //箭头图片的大小

        }
        else if (Input.GetMouseButtonUp(0))
        {
            arrowImage.gameObject.SetActive(false);
        }
    }
}