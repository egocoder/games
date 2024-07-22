using UnityEngine;
using TMPro;

public class FinalScreenManager : MonoBehaviour
{
    [SerializeField] private TMP_Text txtFinalTime;

    void Start()
    {
        // Recupera o tempo salvo em PlayerPrefs
        float finalTime = PlayerPrefs.GetFloat("SavedTime", 0f);

        // Exibe o tempo na tela final
        DisplayFinalTime(finalTime);

        // Opcional: Limpa PlayerPrefs após usar
        PlayerPrefs.DeleteKey("SavedTime");
        PlayerPrefs.Save();
    }

    private void DisplayFinalTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        txtFinalTime.text = string.Format("Tempo: {0:00}:{1:00}", minutes, seconds);
    }
}
