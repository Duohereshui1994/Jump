using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    PullingJump player;
    [SerializeField] float resetTime = 1f;
    [SerializeField] float jumpForce = 10f;
    Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb = other.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            StopCoroutine(nameof(RestoreScale));
            StartCoroutine(nameof(RestoreScale));

            if (other.TryGetComponent<PullingJump>(out player))
            {
                player.jumpCount += 1;
                player.jumpCount = Mathf.Clamp(player.jumpCount, 0, 2);
            }
        }
    }

    private IEnumerator RestoreScale()
    {
        //变长
        transform.localScale = new Vector3(3f, 1f, 1f);

        // 等待一段时间
        yield return new WaitForSeconds(resetTime);

        // 恢复原始缩放比例
        transform.localScale = new Vector3(3f, 0.1f, 1f);
    }
}
