using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winFInal : MonoBehaviour
{
    public string sceneName;
    public int levelNumber;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("level", levelNumber);
            PlayerPrefs.Save();
            SceneManager.LoadScene(sceneName);
        }
    }
}
