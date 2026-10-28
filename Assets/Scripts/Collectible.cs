using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public NPCQuests NPC;
  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindAnyObjectByType<LevelUIController>().Collect();

            //Destroy collectible once collected
            NPC.questComplete = true;
            Destroy(gameObject);
        }
    }





}
