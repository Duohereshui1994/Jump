using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    PullingJump player;
    [SerializeField] GameObject clearPanel;

    private void Awake()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            clearPanel.SetActive(true);
            if (other.TryGetComponent<PullingJump>(out player))
            {
                player.isClear = true;
            }
        }
    }
}
