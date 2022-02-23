using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimBoard : MonoBehaviour
{
    public float health=100;
    public GameObject knife;
    public knife obj;
    public float value;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(knife,new Vector3(0,-4,0),transform.rotation);
        value=obj.value;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,1,Space.Self);
    }

    void Damage(){
        health-=value;
        if(health<=0){
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision collision){
        if(collision.collider.tag=="knife"){
            Damage();
        }
    }
}
