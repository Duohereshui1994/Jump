using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    [SerializeField] Material redMaterial;
    [SerializeField] Material greenMaterial;
    [SerializeField] Material blueMaterial;

    private Renderer playerRenderer;
    private PullingJump pullingJump;
    // Start is called before the first frame update
    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        pullingJump = GetComponent<PullingJump>();
        UpdateMaterial();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMaterial();
    }

    void UpdateMaterial()
    {
        if (pullingJump.isCanJump && pullingJump.jumpCount == 2)
        {
            playerRenderer.material = redMaterial;
        }
        else if (pullingJump.isCanJump && pullingJump.jumpCount == 1)
        {
            playerRenderer.material = greenMaterial;
        }
        else
        {
            playerRenderer.material = blueMaterial;
        }
    }
}
