using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
