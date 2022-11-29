using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager_sc : MonoBehaviour
{


    [SerializeField]
    private float z_offset;

     [SerializeField]
    private Transform platform;

    [SerializeField]
    private Transform platform2;

    [SerializeField]
    private GameObject bigger_pf;

    [SerializeField]
    private GameObject block_pf;

    [SerializeField]
    private GameObject smaller_pf;

    [SerializeField]
    private GameObject bonus_pf;

    [SerializeField]
    private GameObject bonus_container;


     [SerializeField]
    private GameObject bigger_container;

     [SerializeField]
    private GameObject smaller_container;

     [SerializeField]
    private GameObject block_container;

    private  float dynamic_z ;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(manager_bigger());
        StartCoroutine(manager_smaller());
        StartCoroutine(manager_block());
        StartCoroutine(manager_bonus());

/*
        platform.transform.position =new Vector3(platform.transform.position.x,platform.transform.position.y,z_offset+transform.position.z);
        platform2.transform.position =new Vector3(platform2.transform.position.x,platform2.transform.position.y,z_offset+transform.position.z);
*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    IEnumerator manager_bigger(){
        while(true){
            dynamic_z+=Random.Range(5,20);
            Vector3 position = new Vector3(Random.Range(-5f, 5f), 0,transform.position.z+dynamic_z );
            GameObject bigger = Instantiate(bigger_pf, position, Quaternion.identity);
            bigger.transform.parent = bigger_container.transform;
            yield return new WaitForSeconds(1.0f);   
        }
    }
    IEnumerator manager_smaller(){
        while(true){
            dynamic_z+=Random.Range(5,15);
            z_offset+=15;
            Vector3 position = new Vector3(Random.Range(-5f, 5f), 0,transform.position.z+dynamic_z );
            GameObject smaller = Instantiate(smaller_pf, position, Quaternion.identity);
            smaller.transform.parent = smaller_container.transform;
            //platform.transform.position =new Vector3(platform.transform.position.x,platform.transform.position.y,z_offset+smaller_pf.transform.position.z);
            //platform2.transform.position =new Vector3(platform2.transform.position.x,platform2.transform.position.y,z_offset+smaller_pf.transform.position.z);

            yield return new WaitForSeconds(0.5f);   
        }
    }
    
    IEnumerator manager_block(){
        while(true){
            dynamic_z+=Random.Range(5,15);
            
            Vector3 position = new Vector3(Random.Range(-4f, 4f), 0,transform.position.z+dynamic_z );
            GameObject block = Instantiate(block_pf, position, Quaternion.identity);
            block.transform.parent = block_container.transform;
            
            yield return new WaitForSeconds(2.5f);   
        }
    }
     IEnumerator manager_bonus(){
        while(true){
            dynamic_z+=Random.Range(5,25);
            
            Vector3 position = new Vector3(Random.Range(-4f, 4f), 0,transform.position.z+dynamic_z );
            GameObject bonus = Instantiate(bonus_pf, position, Quaternion.identity);
            bonus.transform.parent = bonus_container.transform;
            
            yield return new WaitForSeconds(3.5f);   
        }
    }
    


}
