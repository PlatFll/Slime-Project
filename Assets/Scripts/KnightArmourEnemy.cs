using UnityEngine;
using System.Collections;

public class KnightArmourEnemy : MonoBehaviour
{
    public bool isActive = false;
    public float detectionRadius = 10f;
    public GameObject[] pieces;
    public string playerTag = "Player";
    private int currentPiece = 0;

    void Update()
    {
        GameObject player = GameObject.FindWithTag(playerTag);

        if(player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < detectionRadius && !isActive)
            {
                isActive = true;
                StartCoroutine(ShootPieces());
            }
        }
    }

    IEnumerator ShootPieces()
    {
        //while (currentPiece < pieces.Length)
        for(int i = 0; i < pieces.Length; i++)
        {
            if(pieces[currentPiece] != null)
            {
                pieces[currentPiece].GetComponent<KnightArmorPiece>().isActive = true;
                currentPiece++;
                yield return new WaitForSeconds(0.7f);
            }
        }
    }
}

