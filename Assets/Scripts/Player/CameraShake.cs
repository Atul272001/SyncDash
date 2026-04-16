using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float shakeDuration;
    float magnitude;

    Vector3 orignalPos;

    private void Awake()
    {
        orignalPos = transform.localPosition;
    }

    private void Update()
    {
        if(shakeDuration > 0)
        {
            Vector3 radomOffset = Random.insideUnitCircle * magnitude;
            transform.localPosition = orignalPos + radomOffset;

            shakeDuration -= Time.deltaTime;
        }
        else
        {
            ResetCamera();
        }
    }

    public void ResetCamera()
    {
        shakeDuration = 0;
        transform.localPosition = orignalPos;
    }

    public void ShakeCamera(float duration, float mag)
    {
        shakeDuration = duration;
        magnitude = mag;
    }

}