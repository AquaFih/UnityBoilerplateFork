using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;


public class NPCQuests : MonoBehaviour
{
    private bool playerInRange;
    private bool displayingText;
    public bool questComplete = false;
    public GameObject questTextObject;
    public TextMeshProUGUI questText;
    public GameObject collectible;
    public PlayerMovement Player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (((Player.canInteract) && (playerInRange)) || displayingText))
        {
            if (displayingText)
            {

                questTextObject.SetActive(false);
                displayingText = false;
            }
            else
            {
                if (!questComplete)
                {
                    questTextObject.SetActive(true);
                    displayingText = true;
                    collectible.SetActive(true);
                    questText.text = "Hi I'm John."; // first text
                    StartCoroutine(ChangeTextRoutine()); // finishes the text in coroutine
                } 
                else 
                {
                    questTextObject.SetActive(true);
                    displayingText = true;
                    questText.text = "You collected my wonderful star!";
                    StartCoroutine(ChangeTextRoutine());
                }
            }
            
        }
    }

    // NPC LINES
    IEnumerator ChangeTextRoutine()
    {
        if (!questComplete)
        {
            // Wait for 1 second
            yield return new WaitForSeconds(1.5f);
            questText.text = "Go find my star and I'll show you a cool trick.";
        }
        else
        {
            // Wait for 1 second
            yield return new WaitForSeconds(3f);
            questText.text = "Yeah so you can hold LMB to activate wavedash";
            yield return new WaitForSeconds(3f);
            questText.text = "And then rotate in the direction you wanna dash before releasing";
            yield return new WaitForSeconds(4f);
            questText.text = "Bye now";
        }
        
    }

    // COLLISIONS WITH NPC
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player.canInteract = true;
            playerInRange = true;
            print("In range");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player.canInteract = false;
            playerInRange = false;
            print("Out of range");

            // Hides text when player goes out of range
            questTextObject.SetActive(false);
            displayingText = false;
        }
    }
}
