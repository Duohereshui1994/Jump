using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    [SerializeField] Vector3 rotation;

    private void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
