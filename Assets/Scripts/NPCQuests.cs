using TMPro;
using UnityEngine;


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
                    questText.text = "Hi im john go collect my collectibles";
                } else {
                    
                    questTextObject.SetActive(true);
                    displayingText = true;
                    questText.text = "You collected my wonderful colectibles!";
                }
            }
            
        }
    }
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
