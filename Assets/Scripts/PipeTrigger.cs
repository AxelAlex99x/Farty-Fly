using UnityEngine;

public class PipeTrigger : MonoBehaviour
{
    public UIHandler uiHandler;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiHandler = GameObject.FindGameObjectWithTag("LogicController").GetComponent<UIHandler>();
        audioSource = GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            uiHandler.AddScore();
            gameObject.SetActive(false);
        }
    }
}
