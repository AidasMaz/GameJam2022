using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
    HEALTHY,
    CORRUPTED
}

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    public CharacterType type;
    [SerializeField]
    private float MovementSpeed = 5f;
    public Rigidbody2D rigidbody;
    private delegate Vector2 MovePlayer();
    MovePlayer movement;
    public Animator animator;

    public RuntimeAnimatorController healthyAnim;
    public RuntimeAnimatorController coruptedAnim;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        if (type.Equals(CharacterType.HEALTHY))
        {
            movement = GetHealthyPlayerMovement;
            animator.runtimeAnimatorController = healthyAnim;
        }
        else
        {
            movement = GetCorruptPlayerMovement;
            animator.runtimeAnimatorController = coruptedAnim;
        }
    }

    public Vector2 GetHealthyPlayerMovement()
    {
        float vertAxis = 0f;
        float horizAxis = 0f;

        if(Input.GetKey(KeyCode.W))
        {
            vertAxis = 1f;
            animator.SetFloat("IdleState", 2);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vertAxis = -1f;
            animator.SetFloat("IdleState", 0);
        }
        if(Input.GetKey(KeyCode.A))
        {
            horizAxis = -1f;
            animator.SetFloat("IdleState", 1);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            horizAxis = 1f;
            animator.SetFloat("IdleState", 3);
        }
        SetSpeeds(horizAxis, vertAxis);
        return new Vector2(horizAxis, vertAxis);
    }

    public Vector2 GetCorruptPlayerMovement()
    {
        float vertAxis = 0f;
        float horizAxis = 0f;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vertAxis = 1f;
            animator.SetFloat("IdleState", 2);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            vertAxis = -1f;
            animator.SetFloat("IdleState", 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizAxis = -1f;
            animator.SetFloat("IdleState", 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizAxis = 1f;
            animator.SetFloat("IdleState", 3);
        }
        SetSpeeds(horizAxis, vertAxis);
        return new Vector2(horizAxis, vertAxis);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Slohodown")
        {
            MovementSpeed = 2f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        MovementSpeed = 5f;
    }

    void SetSpeeds(float horizontal,float vertical)
    {
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetBool("IsIdle", horizontal == 0f && vertical == 0f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody.MovePosition( rigidbody.position + movement() * MovementSpeed * Time.fixedDeltaTime);
    }

}
