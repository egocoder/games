using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reinicia o tempo
            FindObjectOfType<TimerManager>().SaveTime(); // Salva o tempo antes de reiniciar
            FindObjectOfType<TimerManager>().enabled = false; // Desativa o TimerManager para evitar reinicializações

            // Reinicia o tempo
            FindObjectOfType<TimerManager>().enabled = true; // Reativa o TimerManager
        }
    }
}
