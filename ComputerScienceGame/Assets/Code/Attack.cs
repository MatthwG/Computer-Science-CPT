using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Movement Movey;
    public float Speed = 4.5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime*Speed;

        
    }

    private void OnCollision2D(Collision collision)
    {
        Destroy(gameObject);
    } 
}
