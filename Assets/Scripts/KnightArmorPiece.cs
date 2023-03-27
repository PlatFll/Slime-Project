using System.Collections;
using UnityEngine;


public class KnightArmorPiece : MonoBehaviour
{
    public bool isActive = false;
    public float fireDelay = 1f;
    public string playerTag = "Player";
    public float projectileSpeed = 10f;
    public float destroyTimer = 2f;
    private GameObject player;
    private Rigidbody2D rb;
    private bool isShot = false;

    void Start()
    {
        player = GameObject.FindWithTag(playerTag);
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    void Update()
    {
        if (isActive)
        {
            fireDelay -= Time.deltaTime;
            if(fireDelay <= 0f)
            {
                if (player != null)
                {
                    Fire();
                    fireDelay = 1f;
                }
            }
        }
    }

    void Fire()
    {
        rb.isKinematic = false;
        // Calculate the direction of the player
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        rb.velocity = direction * projectileSpeed;
        isShot = true;
        // Start the destroy timer
        StartCoroutine(DestroyTimer());
    }

    IEnumerator DestroyTimer()
    {
        if(gameObject != null)
        {
            yield return new WaitForSeconds(destroyTimer);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            if(gameObject != null && isShot)
            {
                Destroy(gameObject);
            }
        }
    }
}





















/*using UnityEngine;

public class KnightArmorPiece : MonoBehaviour
{
    public bool isActive = false;
    public float speed = 5f;
    public string playerTag = "Player";

    void Update()
    {
        if (isActive)
        {
            GameObject player = GameObject.FindWithTag(playerTag);
            if(player != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
    }
}
*/

