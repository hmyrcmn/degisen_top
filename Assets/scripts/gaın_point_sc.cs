using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gaın_point_sc : MonoBehaviour
{
     [SerializeField]
    private float speed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if(transform.position.y < -5.4f){
            float randomx =  Random.Range(-14f, 14f);
            transform.position = new Vector3(randomx, 7.4f, 0);
        }
    }

}
