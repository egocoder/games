using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallAlt : MonoBehaviour
{
    // Script Morte de queda

    [SerializeField] private Collider2D playerCollider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerCollider != null && playerCollider == collision)
        {
            // Certeza de funcionamento
            Debug.Log("Player caiu.");
            SceneManager.LoadScene(2);
        }
    }
}
