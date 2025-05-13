using UnityEngine;
using UnityEngine.UI;

public class ChestUIManager : MonoBehaviour
{
    public static ChestUIManager Instance;

    public Image[] chestImages;
    private int currentIndex = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (var img in chestImages)
        {
            img.gameObject.SetActive(false);
        }
    }

    public void ShowNextChestImage()
    {
        if (currentIndex < chestImages.Length)
        {
            chestImages[currentIndex].gameObject.SetActive(true);
            currentIndex++;
        }
    }

    public bool AllChestsOpened()
    {
        return currentIndex >= chestImages.Length;
    }   

}

