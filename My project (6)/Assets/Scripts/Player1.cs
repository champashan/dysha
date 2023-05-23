using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    //����
    
    [SerializeField] private float speed;//�������� ��� �������� � unity
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float JumpForce;

    private Rigidbody2D body;
    private Animator anim;
    private float canJump = 0f;
    private BoxCollider2D boxCollider;
    




    private void Awake()
    {
        //��� ��� ������ ������� �������� ������ ��� ������ rigidbody � animator 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
       
    }

    private void Update()
    {
        //������ ����� if else - ������� 
        //������� , ���������, ����� ������������ get axis
        //� input manager � �������� horizontal � horizontal2 ��� ���� ������� ��� ��� �� ����� �����

        //���������� ���������
        float horizontalInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //������� ������ ��� �������� ������/�����

        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(6, 6, 6);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-6, 6, 6);

        //������
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded() && Time.time > canJump)
            Jump();

        //��������� ��������
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

       // print(isPlayerAbovePlayer());
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, JumpForce);
        anim.SetTrigger("jump");
        canJump = Time.time + 1f;




    }
    



    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }


}
