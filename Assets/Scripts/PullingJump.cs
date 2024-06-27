using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    AudioSource audioSource;
    Animator animator;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] ParticleSystem jumpVFX;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject[] hintText;
    Rigidbody rb;
    Vector3 clickPosition;
    float jumpPower = 10f;
    float deadAnimeTime = 2f;

    public bool isCanJump;
    public bool isClear;
    public bool isDead;
    public int jumpCount = 0;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        isCanJump = false;
        isClear = false;
        isDead = false;
    }


    void Update()
    {
        if (jumpCount <= 0)
        {
            isCanJump = false;
        }
        else
        {
            isCanJump = true;
        }

        if (!isClear && !isDead) { Jump(); }

        ChangeHintText(jumpCount);
    }

    private void Jump()
    {
        if (jumpCount > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                clickPosition = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                Vector3 dist = clickPosition - Input.mousePosition;     //两点间的距离，也是方向
                if (dist.sqrMagnitude == 0) { return; }                 //如果两点间的距离为0，则不做任何操作
                jumpCount--;
                rb.velocity = dist.normalized * jumpPower;              //计算速度
                Instantiate(jumpVFX, transform.position, Quaternion.identity);//播放跳跃特效
                audioSource.PlayOneShot(jumpSound);
            }
        }
    }

    public void Death()
    {
        StopCoroutine(nameof(WaitForDeathAnimation));
        StartCoroutine(nameof(WaitForDeathAnimation));
    }

    public void PlayDeathAnimation()
    {
        animator.SetTrigger("Dead");
    }

    public IEnumerator WaitForDeathAnimation()
    {
        PlayDeathAnimation();

        yield return new WaitForSeconds(deadAnimeTime);

        OnDead();
    }

    public void OnDead()
    {
        isDead = true;
        panel.SetActive(true);
    }

    public void ChangeHintText(int index)
    {
        for (int i = 0; i < hintText.Length; i++)
        {
            if (i == index)
            {
                hintText[i].SetActive(true);
            }
            else
            {
                hintText[i].SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ContactPoint[] contacts = collision.contacts;
            Vector3 otherNormal = contacts[0].normal;
            Vector3 upVector = new Vector3(0, 1, 0);
            float dotUN = Vector3.Dot(upVector, otherNormal);
            float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;

            if (dotDeg <= 45)
            {
                jumpCount = 2;
            }
        }
    }
}
