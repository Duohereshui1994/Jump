using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [SerializeField] AudioClip pickUpSFX;
    Animator animator;

    new Collider collider;
    MeshRenderer meshRenderer;
    [SerializeField] float resetTime = 3.0f;
    WaitForSeconds waitResetTime;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        waitResetTime = new WaitForSeconds(resetTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("Get");
            //Destroy(gameObject);
        }
        if (other.TryGetComponent<PullingJump>(out PullingJump player))
        {
            player.jumpCount ++;
            SFXPlayer.AudioSource.PlayOneShot(pickUpSFX);
        }
    }

    private void Close()
    {
        collider.enabled = false;//关闭碰撞体
        meshRenderer.enabled = false;//关闭渲染器
    }
    private void Reset()
    {
        collider.enabled = true;//开启碰撞体
        meshRenderer.enabled = true;//开启渲染器
    }
    private void OnGetItem()
    {
        StopAllCoroutines();
        StartCoroutine(nameof(CloseAndResetCoroutine));
    }
    IEnumerator CloseAndResetCoroutine()
    {
        Close();
        yield return waitResetTime;
        Reset();
        animator.SetTrigger("Reset");
    }
}