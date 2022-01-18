using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject prefab;
    public Vector3 throwforce;
    public Vector3 pos;
    public bool isActive=true;
    public BoxCollider knifecollider;
    public Transform size;
    public float value=10;
    // Start is called before the first frame update
    void Start()
    {
        isActive=true;
        size.localScale=new Vector3(0.1f,1,0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isActive){
            rb.AddForce(throwforce,ForceMode.Impulse);
        }
    }
    public void OnCollisionEnter(Collision collision){
        if(!isActive){
            return;
        }
            

        isActive=false;    
        if(collision.collider.tag=="Aim"){
            rb.velocity=new Vector3(0,0,0);
            rb.isKinematic=false;
            this.transform.SetParent(collision.collider.transform);
            Instantiate(prefab,pos,transform.rotation);
        }
        if(collision.collider.tag=="knife"){
            rb.useGravity=true;
            Destroy(this.gameObject);
        }
    }
}
