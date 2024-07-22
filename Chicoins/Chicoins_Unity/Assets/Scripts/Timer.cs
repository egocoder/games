using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text txtTime;
    private float timeValue;

    private const string timeKey = "SavedTime";
    private const string quitKey = "GameQuit";

    void Start()
    {
        ResetTime();

        // Inicia o contador de tempo
        InvokeRepeating("IncreaseTime", 1f, 1f);

        // Mantém este objeto vivo ao mudar de cena, exceto na cena "GameOver"
        if (SceneManager.GetActiveScene().name != "GameOver")
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void IncreaseTime()
    {
        if (timeValue < 0f) return;

        timeValue++;

        DisplayTime(timeValue);
    }

    private void DisplayTime(float TimetoDisplay)
    {
        if (TimetoDisplay < 0f)
        {
            TimetoDisplay = 0f;
        }
        float minutes = Mathf.FloorToInt(TimetoDisplay / 60);
        float seconds = Mathf.FloorToInt(TimetoDisplay % 60);

        txtTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void SaveTime()
    {
        PlayerPrefs.SetFloat(timeKey, timeValue);
        PlayerPrefs.Save(); // Salva explicitamente o tempo

        Debug.Log("Time Value Saved: " + timeValue); // Debug para verificar o valor salvo
    }

    private void ResetTime()
    {
        // Verifica se o jogo foi fechado corretamente da última vez
        if (PlayerPrefs.HasKey(quitKey) && PlayerPrefs.GetInt(quitKey) == 1)
        {
            // Se sim, zera o tempo salvo
            PlayerPrefs.SetFloat(timeKey, 0f);
            PlayerPrefs.SetInt(quitKey, 0); // Reseta o indicador de fechamento correto
        }

        // Carrega o tempo salvo atualizado
        timeValue = PlayerPrefs.GetFloat(timeKey, 0f);
        DisplayTime(timeValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("VictoryZone"))
        {
            SaveTime(); // Salva o tempo quando o jogador atinge o Collider de vitória
            timeValue = 0f; // Reinicia o tempo
            DisplayTime(timeValue); // Atualiza a exibição do tempo na UI
        }
        else if (other.CompareTag("DeathZone"))
        {
            timeValue = 0f; // Reinicia o tempo
            DisplayTime(timeValue); // Atualiza a exibição do tempo na UI
        }
    }

    private void OnApplicationQuit()
    {
        SaveTime(); // Salva o tempo quando o aplicativo é fechado
        PlayerPrefs.SetInt(quitKey, 1); // Define indicador de fechamento correto
    }

    private void OnDisable()
    {
        SaveTime(); // Salva o tempo quando o objeto é desativado (mudança de cena)
    }
}
