using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscarekiller : MonoBehaviour
{
    public Animator obungaAnim;
    public GameObject player;
    public GameObject enemy; // Asegúrate de asignar el objeto del enemigo en el Inspector
    public float jumpscareTime;
    public string sceneName;

    private int playerLives = 2; // Número de vidas del jugador

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerLives > 0)
        {
            playerLives--;

            if (playerLives == 1)
            {
                // Primera vez que es tocado, regresa al enemigo a su posición original
                StartCoroutine(ResetEnemyPosition());
            }
            else if (playerLives == 0)
            {
                // Segunda vez que es tocado, activa el jumpscare y pierde el juego
                player.SetActive(false);
                // obungaAnim.SetTrigger("camera");
                StartCoroutine(jumpscare());
            }
        }
    }

    IEnumerator ResetEnemyPosition()
    {
        // Puedes personalizar esta parte para que el enemigo regrese a su posición original
        // Por ejemplo, reseteando su posición a una posición inicial predeterminada.
        yield return new WaitForSeconds(2f); // Tiempo de espera antes de resetear al enemigo
        // Restablecer la posición del enemigo a la posición inicial
        enemy.transform.position = new Vector3(0f, 1f, 0f); // Ajusta la posición según tus necesidades
    }

    IEnumerator jumpscare()
    {
        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(sceneName);
    }
}

