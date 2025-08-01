using UnityEngine;

public class setFPS : MonoBehaviour
{
    [SerializeField] private int fps = 60;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = fps;
        QualitySettings.vSyncCount = 0;
    }

}
