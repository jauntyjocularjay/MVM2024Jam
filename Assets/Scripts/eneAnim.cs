using UnityEngine;

public class eneAnim : MonoBehaviour
{
    private EnemyHealth localHealth;
    private Animator localAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        localHealth = gameObject.GetComponent<EnemyHealth>();
        localAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(localHealth.checkCapture())
        {
            localAnimator.SetBool("damaged", true);
        }
    }
}
