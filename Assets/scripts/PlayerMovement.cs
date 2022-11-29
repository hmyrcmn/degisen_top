using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [SerializeField] float speed;
    float startSpeed;

    Vector3 direction;
    
    [SerializeField] Rigidbody rb;
    #endregion

    private void Start()
    {
        startSpeed = speed;
    }
    
    void Update()
    {
        if (speed < startSpeed) speed += Time.deltaTime;

        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));        
        if(direction.z < .0f == false) transform.Translate(direction * speed * Time.deltaTime);

        #region Henuz Kullanilmiyor
        float zipla = Input.GetAxis("Jump");

        if (Input.GetAxis("Jump") > 0)
        {
            rb.velocity = new Vector3(0, 5, 0);
        }

        //platform dısına cıkınca
        if (transform.position.x > 7.0f)
        {
            transform.position =new Vector3(transform.position.x-7.0f, transform.position.y, transform.position.z); 
            speed *= .5f;
            
             
        }
        else if (transform.position.x < -7.0f)
        {
            transform.position =new Vector3(transform.position.x+7.0f, transform.position.y, transform.position.z); 
             speed *= .5f;
            
        }
        #endregion
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("blok"))
        {
            //transform.position -= Vector3.forward*10;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z-3.0f);
            speed *= .5f;
        }        
    }
}
