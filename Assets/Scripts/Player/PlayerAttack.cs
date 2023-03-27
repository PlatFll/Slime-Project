using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] slimeBalls;
    private Animator anim;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1) && cooldownTimer > attackCooldown)
        {
            Debug.Log("Right click!");
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }


    private void Attack()
    {
        if(!slimeBalls[FindSlimeBall()].activeInHierarchy)
        {
            anim.SetTrigger("Attack");
            cooldownTimer = 0;
            //pool slimeballs

            slimeBalls[FindSlimeBall()].transform.position = firePoint.position;
            slimeBalls[FindSlimeBall()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        }
    }

    private int FindSlimeBall()
    {
        for(int i = 0; i < slimeBalls.Length; i++)
        {
            if(!slimeBalls[i].activeInHierarchy)
                return i;
        }
        
        return 0;
    }
    
}
