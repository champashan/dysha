using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GButX : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;

    public GameObject wall;

    public float PositionButton;
    //public float HightButton;
    public float PositionWall;
    public float HightWall;

    public bool close = false;
    private void Update()
    {
        if (close == true && wall.transform.position.y < PositionWall)
        {
            wall.transform.Translate(Vector2.down * Time.deltaTime);
        }
    }
    private void Awake()
    {
        //эти две строки помогут получить ссылки для нашего rigidbody и animator 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.tag == "Player1" && transform.position.x > HightButton)
        //{
        //    transform.Translate(Vector2.down * Time.deltaTime);
        //}
        if (collision.tag == "Player1" && wall.transform.position.x > HightWall)
        {
            wall.transform.Translate(Vector2.up * Time.deltaTime);
        }
        close = false;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        transform.position = new Vector2(transform.position.x, PositionButton);
        close = true;
    }
}
