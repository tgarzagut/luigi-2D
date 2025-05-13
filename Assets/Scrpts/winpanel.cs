using UnityEngine;

public class WinPanelController : MonoBehaviour
{
    public GameObject winPanel; 

    void Update()
    {
        if (ChestUIManager.Instance != null && ChestUIManager.Instance.AllChestsOpened())
        {
            if (winPanel != null && !winPanel.activeSelf)
            {
                winPanel.SetActive(true);
            }
        }
    }
}
