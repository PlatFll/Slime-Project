using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private float lifeTime;

    private CircleCollider2D circleCollider;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if(hit) return;
        float movementSpeed = -speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if(lifeTime > 7) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player")
        {
            hit = true;
            circleCollider.enabled = false;
            anim.SetTrigger("Explode");

            if(collision.tag == "Enemy")
            {
                collision.GetComponent<Health>().TakeDamage(1);
            }
        }
    }

    public void SetDirection(float _direction)
    {
        lifeTime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        circleCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if(Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y,
        transform.localScale.z);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
