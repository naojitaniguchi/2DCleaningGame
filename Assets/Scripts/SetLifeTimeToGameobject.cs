using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLifeTimeToGameobject : MonoBehaviour
{
    [SerializeField] float lifeTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartLife());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartLife()
    {

        //3ïbí‚é~
        yield return new WaitForSeconds(lifeTime);

        Destroy(gameObject);
    }
}
