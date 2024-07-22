using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// box collider fim do mapa

public class Final_Mapa : MonoBehaviour
{
    [SerializeField] private Collider2D playerCollider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerCollider != null && playerCollider == collision)
        {
            Debug.Log("Player bateu");
            SceneManager.LoadScene(3);
        }
    }


}




