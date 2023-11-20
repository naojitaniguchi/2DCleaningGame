using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CleanGameEnemy : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";
    [SerializeField] string groundTag = "Ground";
    [SerializeField] float speed = 1.0f;
    GameObject playerObject;
    bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag(playerTag);
    }

    // Update is called once per frame
    void Update()
    {
        float xDir = 0.0f;
        if (playerObject != null)
        {
            xDir = playerObject.transform.position.x - transform.position.x;
            if (xDir > 0)
            {
                xDir = 1.0f;
            }
            else
            {
                xDir = -1.0f;
            }
        }
        if (isGrounded)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * xDir * speed;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == groundTag)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == groundTag)
        {
            isGrounded = false;
        }
    }

}
