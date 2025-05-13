using UnityEngine;
using UnityEngine.UI; 

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;


    public Image[] hearts;
    public GameObject died;

    void Start()
    {
        currentLives = maxLives;
        UpdateHeartsUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("curse"))
        {
            LoseLife();
        }
    }

    void LoseLife()
    {
        if (currentLives <= 0) return;

        currentLives--;
        Debug.Log("Player hit! Lives left: " + currentLives);

        UpdateHeartsUI();

        if (currentLives <= 0)
        {
            Die();
        }
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentLives;
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        gameObject.SetActive(false);
        died.SetActive(true);
    }
    public int CurrentLives => currentLives;
    public int MaxLives => maxLives;
}
