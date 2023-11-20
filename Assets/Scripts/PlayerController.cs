using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float jumpPower = 300.0f;
    [SerializeField] GameObject rightFire;
    [SerializeField] GameObject leftFire;
    [SerializeField] float fireTime = 0.5f;
    [SerializeField] bool movePlayer = true;
    [SerializeField] string groundTag = "Ground";
    [SerializeField] string enemyTag = "Ground";
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject dieEffect;
    [SerializeField] AudioClip dieSound;
    public int life = 3;
    bool isGrounded = false;
    bool isAtacking = false;
    float holizontal = 0.0f;
    float dir = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        holizontal = Input.GetAxis("Horizontal");
        if ( holizontal > 0.1f)
        {
            dir = 1.0f;
        }
        else if (holizontal < -0.1f ){
            dir = -1.0f;
        }
        float jump = Input.GetAxis("Jump");
        float fire1 = Input.GetAxis("Fire1");

        if (!isAtacking && fire1 > 0.3f)
        {
            StartCoroutine(fire());
        }

        if ( movePlayer )
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed * holizontal;
            if (jump > 0 && isGrounded)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == groundTag)
        {
            isGrounded = true;
        }
        if ( collision.gameObject.tag == enemyTag)
        {
            Destroy(collision.gameObject);
            life--;
            if ( life <= 0 )
            {
                if (dieEffect  != null )
                {
                    GameObject effect = Instantiate(dieEffect);
                    effect.transform.position = collision.transform.position;
                    effect.transform.rotation = Quaternion.identity;
                }
                if (dieSound != null)
                {
                    gameObject.GetComponent<AudioSource>().PlayOneShot(dieSound);
                }
                gameOver.SetActive(true);
                movePlayer = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == groundTag)
        {
            isGrounded = false;
        }
    }

    IEnumerator fire()
    {
        if (dir > 0.0f)
        {
            isAtacking = true;
            rightFire.SetActive(true);
        }else if (dir < 0.0f)
        {
            isAtacking = true;
            leftFire.SetActive(true);
        }
        
        yield return new WaitForSeconds(fireTime);

        if ( rightFire.activeSelf )
        {
            rightFire.SetActive(false);
        }
        if ( leftFire.activeSelf)
        {
            leftFire.SetActive(false);
        }

        isAtacking = false;
        
    }
}
