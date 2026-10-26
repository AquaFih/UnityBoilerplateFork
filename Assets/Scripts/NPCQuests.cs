using UnityEngine;


public class NPCQuests : MonoBehaviour
{
    private bool playerInRange;
    private bool displayingText;
    public GameObject questText;
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
                
                questText.SetActive(false);
                displayingText = false;
            }
            else
            {
                questText.SetActive(true);
                displayingText = true;
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
            print("Out range");
        }
    }
}
