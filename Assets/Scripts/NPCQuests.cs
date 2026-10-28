using UnityEngine;


public class NPCQuests : MonoBehaviour
{
    private bool playerInRange;
    private bool displayingText;
    public bool questComplete = false;
    public GameObject questText;
    public GameObject questText2;
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
                
                questText.SetActive(false);
                questText2.SetActive(false);
                displayingText = false;
            }
            else
            {
                if (!questComplete)
                {
                    questText.SetActive(true);
                    displayingText = true;
                    collectible.SetActive(true);
                } else {
                    questText2.SetActive(true);
                    displayingText = true;
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
            print("Out range");
        }
    }
}
