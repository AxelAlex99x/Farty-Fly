using UnityEngine;

public class PipeTrigger : MonoBehaviour
{
    [SerializeField] private Animator animator;
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
            animator.SetBool("isTalking", false);
            uiHandler.AddScore();
            gameObject.SetActive(false);
        }
    }
}
