using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    [SerializeField] string enemyTag = "Enemy";
    [SerializeField] AudioClip hitSound;
    [SerializeField] GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == enemyTag)
        {
            if ( hitSound != null )
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot( hitSound );
            }
            if ( hitEffect != null )
            {
                GameObject effect = Instantiate(hitEffect);
                effect.transform.position = collision.transform.position;
                effect.transform.rotation = Quaternion.identity;
            }
            Destroy(collision.gameObject);
        }
    }
}
