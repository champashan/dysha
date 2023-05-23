using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButBl2Level : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;

    public GameObject wall;

    public bool close = false;
    private void Update()
    {
        if (close == true && wall.transform.position.x > 13.4f)
        {
            wall.transform.Translate(Vector2.up * Time.deltaTime);
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
        if (collision.tag == "Player2" && transform.position.y > 2.9f)
        {
            transform.Translate(Vector2.down * Time.deltaTime);
        }
        else if (collision.tag == "Player2" && wall.transform.position.x < 18f)
        {
            wall.transform.Translate(Vector2.down * Time.deltaTime);
        }
        close = false;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        transform.position = new Vector2(transform.position.x, 3.19f);
        close = true;
    }
}
