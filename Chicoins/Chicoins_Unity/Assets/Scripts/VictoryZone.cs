using UnityEngine;

public class VictoryZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Salva o tempo
            FindObjectOfType<TimerManager>().SaveTime();
        }
    }
}
