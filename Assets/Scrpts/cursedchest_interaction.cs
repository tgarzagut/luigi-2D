using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CursedChestInteraction : MonoBehaviour
{
    public GameObject pressEUI;
    public TMP_Text messageText;
    public float messageDuration = 2f;
    public GameObject winPanel;
    public GameObject loseNoLivesPanel;

    private bool playerInRange = false;
    private GameObject player;

    void Start()
    {
        if (pressEUI != null)
            pressEUI.SetActive(false);

        if (messageText != null)
            messageText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && ChestUIManager.Instance.AllChestsOpened())
        {
            if (pressEUI != null)
                pressEUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
                if (playerHealth != null && playerHealth.CurrentLives == playerHealth.MaxLives)
                {
                    Debug.Log("E pressed - You Win!");
                    player.SetActive(false);

                    if (winPanel != null)
                        winPanel.SetActive(true);
                }
                else
                {
                    Debug.Log("E pressed - Not full health. You lose.");
                    player.SetActive(false);

                    if (loseNoLivesPanel != null)
                        loseNoLivesPanel.SetActive(true);
                }
            }
        }
        else
        {
            if (pressEUI != null)
                pressEUI.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            player = other.gameObject;

            if (!ChestUIManager.Instance.AllChestsOpened() && messageText != null)
            {
                StartCoroutine(ShowMessage("Open all chests first"));
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (pressEUI != null)
                pressEUI.SetActive(false);
        }
    }

    System.Collections.IEnumerator ShowMessage(string message)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(messageDuration);
        messageText.gameObject.SetActive(false);
    }
}
