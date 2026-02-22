using UnityEngine;

public class CameraFOVScaler : MonoBehaviour
{
    public float baseFOV = 60f;
    public float baseAspect = 16f / 9f;

    void Start()
    {
        float currentAspect = (float)Screen.width / Screen.height;
        Camera.main.fieldOfView =
            Mathf.Rad2Deg * 2f *
            Mathf.Atan(Mathf.Tan(baseFOV * Mathf.Deg2Rad / 2f) * (currentAspect / baseAspect));
    }
}
