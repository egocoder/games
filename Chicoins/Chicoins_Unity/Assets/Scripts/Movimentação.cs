using UnityEngine;

public class se_mexe_porra : MonoBehaviour
{
    public Rigidbody2D rb;
    public int moveSpeed;
    public Animator animator;

    public bool taNoChao;
    public Transform detectaChao;
    public LayerMask oQueEhChao;

    private GameController gcPlayer;
    private Vector3 facingRight;
    private Vector3 facingLeft;

    private int pulosExtras = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = -facingLeft.x;

        // Encontra o GameController na cena
        GameObject gameControllerObj = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObj != null)
        {
            gcPlayer = gameControllerObj.GetComponent<GameController>();
        }
        else
        {
            Debug.LogError("GameController n�o encontrado na cena!");
        }

        if (gcPlayer != null)
        {
            gcPlayer.coins = 0;
        }
        else
        {
            Debug.LogWarning("gcPlayer � null! Verifique se o GameController est� configurado corretamente na cena.");
        }
    }

    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        // Define a anima��o de acordo com a dire��o
        animator.SetBool("taCorrendo", direction != 0);

        // Verifica se est� no ch�o
        taNoChao = Physics2D.OverlapCircle(detectaChao.position, 0.2f, oQueEhChao);

        // L�gica de pulo
        if (Input.GetButtonDown("Jump"))
        {
            if (taNoChao)
            {
                rb.velocity = new Vector2(rb.velocity.x, 12f);
            }
            else if (pulosExtras > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 12f);
                pulosExtras--;
            }
        }

        // Restaura os pulos extras quando est� no ch�o
        if (taNoChao)
        {
            pulosExtras = 1;
        }

        // Inverte a escala do sprite conforme a dire��o
        if (direction > 0)
        {
            transform.localScale = facingRight;
        }
        else if (direction < 0)
        {
            transform.localScale = facingLeft;
        }

        // Aplica a velocidade horizontal
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
            Destroy(collision.gameObject);

            // Verifica se gcPlayer n�o � null antes de acessar suas propriedades
            if (gcPlayer != null)
            {
                gcPlayer.coins++;

                // Verifica se gcPlayer.coinsText n�o � null antes de atualizar o texto
                if (gcPlayer.coinsText != null)
                {
                    gcPlayer.coinsText.text = gcPlayer.coins.ToString();
                }
                else
                {
                    Debug.LogWarning("coinsText n�o est� atribu�do no GameController.");
                }
            }
            else
            {
                Debug.LogWarning("gcPlayer � null ao tentar adicionar moeda.");
            }
        }
    }

}
