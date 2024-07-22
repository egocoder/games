using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    private static TimerManager instance;
    private float timeValue;
    [SerializeField] private TMP_Text txtTime;

    public static TimerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("TimerManager").AddComponent<TimerManager>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    private void Start()
    {
        // Carrega o tempo salvo se existir
        timeValue = PlayerPrefs.GetFloat("SavedTime", 0f);

        // Inicia o contador de tempo
        InvokeRepeating("IncreaseTime", 1f, 1f);
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
        PlayerPrefs.SetFloat("SavedTime", timeValue);
        PlayerPrefs.Save(); // Salva explicitamente o tempo

        Debug.Log("Time Value Saved: " + timeValue); // Debug para verificar o valor salvo
    }

    public void ResetTime()
    {
        timeValue = 0f;
        DisplayTime(timeValue);
    }
}
