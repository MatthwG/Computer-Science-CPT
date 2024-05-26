using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public GameObject ProjectilePrefab2;
    public Movement Movey;
    public ParticleSystem particle;
    public ParticleSystem particle1;
    public float Speed = 4.5f;
    //HAPPY
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime*Speed;
        
        
    }
/*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "All")
        {
            
            Destroy(gameObject);
            
            
        }
        
    } */
}
