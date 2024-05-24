using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float health = 2;
    [SerializeField] private Rigidbody2D rb;
    private float distance;
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            rb.AddForce(transform.right * 10f,ForceMode2D.Impulse);
            health = health - 1f;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            
        }
    } 
}
