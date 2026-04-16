using System.Collections.Generic;
using UnityEngine;

public class SyncSystem : MonoBehaviour
{
    public static SyncSystem instance;

    public float delay = 0.2f;
    private Queue<PlayerState> buffer = new Queue<PlayerState>();

    Vector3 offset = new Vector3(-22f, 0f, 0f);

    private void Awake()
    {
        instance = this;
    }

    public void SendState(Vector3 pos, bool jumped)
    {
        PlayerState state = new PlayerState
        {
            position = pos + offset,
            jump = jumped,
            timeStamp = Time.time
        };
        buffer.Enqueue(state);
    }

    public bool TryGetState(out PlayerState state)
    {
        if(buffer.Count > 0)
        {
            if(Time.time - buffer.Peek().timeStamp > delay)
            {
                state = buffer.Dequeue();
                return true;
            }
        }

        state = default;
        return false;
    }
}
