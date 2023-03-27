using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private Animator anim;
    private bool dead;

    [Header ("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    private Material originalMaterial;
    [SerializeField] private Material flashMaterial;


    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRend.material;
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if(currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            //IFrames
            StartCoroutine(Invulnerability());
        }

        else
        {
            if(!dead)
            {
                anim.SetTrigger("Die");

                //Player
                if(GetComponent<DragAndMove>() != null && GetComponent<LineRenderer>() != null)
                {
                    GetComponent<DragAndMove>().enabled = false;
                    GetComponent<LineRenderer>().enabled = false;
                }

                //Enemy
                if(GetComponentInParent<EnemyPatrol>() != null)
                {
                    GetComponentInParent<EnemyPatrol>().enabled = false;
                }

                if(GetComponent<MeleeEnemy>() != null)
                {  
                    GetComponent<MeleeEnemy>().enabled = false;
                }



                dead = true;
            }
        }
    }

    public void AddHealth(float healthValue)
    {
        if(!dead)
        {
            currentHealth = Mathf.Clamp(currentHealth + healthValue, 0, startingHealth);
        }
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        for(int i = 0; i < numberOfFlashes; i++)
        {
            //spriteRend.color = new Color(0, 0, 0, 1);
            spriteRend.material = flashMaterial;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            //spriteRend.color = Color.white;
            spriteRend.material = originalMaterial;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);

    }

}

