using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{

    //����

    [SerializeField] private float speed;//�������� ��� �������� � unity
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float JumpForce;

    private Rigidbody2D body;
    private Animator anim;

   
    private bool player;
    private BoxCollider2D boxCollider;
    private float canJump = 0f;


    private void Awake()
    {
        //��� ��� ������ ������� �������� ������ ��� ������ rigidbody � animator 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        //��� �� ������ ��������
        //����� ��� horizontal2 � ����

        //����������� �� ������� a d

        float horizontalInput = Input.GetAxis("Horizontal2");

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(4, 4, 4);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-4, 4, 4);

        //������
        if ((Input.GetKey(KeyCode.W) && isGrounded() && Time.time > canJump) || (Input.GetKey(KeyCode.W) && player && Time.time > canJump))
            Jump();
        

        anim.SetBool("run2", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, JumpForce);
        anim.SetTrigger("jump2");
        canJump = Time.time + 1f;
        player = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            
            player = true;

        }
    }
    
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

   
}
