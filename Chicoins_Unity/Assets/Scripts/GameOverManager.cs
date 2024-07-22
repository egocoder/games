using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Text coinsCollectedText;

    void Start()
    {
        // Mostra o n�mero de moedas coletadas na tela de Game Over
        coinsCollectedText.text = "Moedas coletadas: " + GameController.gc.coins.ToString();
    }
}
