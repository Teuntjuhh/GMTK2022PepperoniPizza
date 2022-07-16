using UnityEngine;

public class NrTwoScissors : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Alpha2))
        {
            animator.SetTrigger("IsPressingTwo");
        }
        else
        {
            animator.ResetTrigger("IsPressingTwo");
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
