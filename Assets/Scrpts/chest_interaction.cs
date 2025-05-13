using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public GameObject pressEUI;
    public float wiggleDistance = 10f;
    public float wiggleRotation = 10f;
    public float wiggleDuration = 0.1f;

    private bool playerInRange = false;
    private bool isWiggling = false;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        if (pressEUI != null)
            pressEUI.SetActive(false);

        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !isWiggling)
        {
            StartCoroutine(WiggleChestThenDisappear());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && pressEUI != null)
        {
            pressEUI.SetActive(true);
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && pressEUI != null)
        {
            pressEUI.SetActive(false);
            playerInRange = false;
        }
    }

    private System.Collections.IEnumerator WiggleChestThenDisappear()
    {
        isWiggling = true;

        transform.position = originalPosition + Vector3.right * wiggleDistance;
        transform.rotation = Quaternion.Euler(wiggleRotation, 0f, 0f);
        yield return new WaitForSeconds(wiggleDuration);

        transform.position = originalPosition - Vector3.right * wiggleDistance;
        transform.rotation = Quaternion.Euler(-wiggleRotation, 0f, 0f);
        yield return new WaitForSeconds(wiggleDuration);

        transform.position = originalPosition;
        transform.rotation = originalRotation;
        yield return new WaitForSeconds(0.1f);
        ChestUIManager.Instance.ShowNextChestImage();

        Destroy(gameObject);
    }
}
