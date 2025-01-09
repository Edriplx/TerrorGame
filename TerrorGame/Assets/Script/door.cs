using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject intText, key, lockedText;
    public bool interactable;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!key.activeSelf)
                {
                    intText.SetActive(false);
                    interactable = false;

                    // Destruir la puerta si el jugador tiene la llave
                    Destroy(gameObject);
                }
                else
                {
                    lockedText.SetActive(true);
                    StopCoroutine("DisableText");
                    StartCoroutine("DisableText");
                }
            }
        }
    }

    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(2.0f);
        lockedText.SetActive(false);
    }
}
