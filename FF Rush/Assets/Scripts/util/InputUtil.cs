using UnityEngine;
class InputUtil
{
    public static bool touchOnce()
    {
        return (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space);
    }
}