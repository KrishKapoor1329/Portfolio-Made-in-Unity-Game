using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementScript : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    float horizontalMove = 0f;

    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    public GameObject[] ignores;
    public void Start()
    {
        ignores = GameObject.FindGameObjectsWithTag("IgnoreColl");
        for (int i = 0; i < ignores.Length; i++)
        {
            Physics.IgnoreCollision(ignores[i].GetComponent<Collider>(), GetComponent<Collider>());
        }
    }

    public void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }


        //if(this.gameObject.GetComponent<Rigidbody2D>().velocity.x>=0.1f|| this.gameObject.GetComponent<Rigidbody2D>().velocity.x <=-0.1f)
        //{
        //    this.gameObject.GetComponent<AudioSource>().loop = true;
        //    this.gameObject.GetComponent<AudioSource>().Play();
            
        //}
        //else
        //{
        //    this.gameObject.GetComponent<AudioSource>().Pause();
        //    this.gameObject.GetComponent<AudioSource>().loop = false;
        //}
    }


    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    private void FixedUpdate()
    {

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;


    }

    void OnCollisionEnter2D(Collision collision)
    {
        if (collision.gameObject.tag == "IgnoreColl")
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }

    }
}
