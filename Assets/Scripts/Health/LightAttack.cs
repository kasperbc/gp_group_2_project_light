using UnityEngine;

public class LightAttack : MonoBehaviour
{
    private Animator animator;
    private GameObject player;
    private bool collideWithPlayer;

    [SerializeField] public float damage = 10;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnCollisionStay2D(Collision2D other)
    {
        GameObject hit = other.gameObject;
        PlayerHealth health = hit.GetComponent<PlayerHealth>();
        if (other.gameObject == player && health != null)
        {
            collideWithPlayer = true;
            health.TakeDamage(damage * Time.deltaTime);
        }
        Debug.Log("Enter collision with player");
    }
}


    // Start is called before the first frame update
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject == player)
    //    {
    //        animator.SetBool("IsDying", true);
    //    }
    //    Debug.Log("Enter trigger with player");
    //}

    //void OnCollisionExit(Collision other)
    //{
    //    if (other.gameObject == player)
    //    {
    //        collideWithPlayer = false;
    //    }
    //    Debug.Log("Exit collision with player");
    //}

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject == player)
    //    {
    //        animator.SetBool("IsDying", false);
    //    }
    //    Debug.Log("Exit trigger with player");
    //}

    //private void Attack()
    //{
    //    if (collideWithPlayer)
    //    {
    //        player.GetComponent<PlayerHealth>().TakeDamage(damage * Time.deltaTime);
    //    }
    //}


