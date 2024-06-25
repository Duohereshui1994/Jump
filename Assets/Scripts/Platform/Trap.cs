using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    PullingJump player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PullingJump>(out player))
        {
            player.Death();
        }
    }
}