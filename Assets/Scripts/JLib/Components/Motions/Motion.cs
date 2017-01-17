using UnityEngine;

public class Motion : MonoBehaviour
{
    public int FrameCount = -1;
    public int FrameDelay = 0;

    public bool ActiveFrame
    {
        get
        {
            if (FrameCount > 0)
                FrameCount--;
            if (FrameDelay > 0)
                FrameDelay--;
            return FrameCount != 0 && FrameDelay <= 0;
        }
    }

    public void ResetCount()
    {
        FrameCount = -1;
    }
}
