using UnityEngine;

public class GhostPlayer : MonoBehaviour
{
    PlayerState previousState;
    PlayerState nextState;

    bool hasState = false;

    private void Update()
    {
        if(SyncSystem.instance.TryGetState(out PlayerState state))
        {
            previousState = nextState;
            nextState = state;

            hasState = true;
        }
        if (!hasState)
            return;

        float totalTime = nextState.timeStamp - previousState.timeStamp;

        if(totalTime <= 0.0001f)
            return;

        float currentTime = Time.time - nextState.timeStamp;

        float t = 1f - (currentTime / totalTime);
        t = Mathf.Clamp01(t);

        transform.position = Vector3.Lerp(previousState.position, nextState.position, t);
    }
}
