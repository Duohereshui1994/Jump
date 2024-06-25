using UnityEngine;

public class PlatformFollower : MonoBehaviour
{
    private Vector3 previousPlatformPosition;
    private bool playerOnPlatform = false;
    [SerializeField] GameObject player;

    private void Start()
    {
        // 初始化平台的上一次位置
        previousPlatformPosition = transform.position;
    }

    private void Update()
    {
        if (playerOnPlatform && player != null)
        {
            // 计算平台的位移
            Vector3 platformMovement = transform.position - previousPlatformPosition;

            // 更新玩家的位置
            player.transform.position += platformMovement;
        }

        // 更新平台的上一次位置
        previousPlatformPosition = transform.position;
    }

    private void OnTriggerEnter(Collider collision)
    {
        // 当玩家接触平台时，记录玩家并开始跟随
        if (collision.gameObject.name == "Player")
        {
            playerOnPlatform = true;
            player = collision.gameObject;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        // 当玩家离开平台时，停止跟随
        if (collision.gameObject.name == "Player")
        {
            playerOnPlatform = false;
            player = null;
        }
    }
}
