using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sp;
    [SerializeField] float verticalForce;
    [SerializeField] float restartDelay = 1;
    [SerializeField] private Color yellowColor;
    [SerializeField] private Color purpleColor;
    [SerializeField] private Color cyanColor;
    [SerializeField] private Color pinkColor;
    [SerializeField] private ParticleSystem deadAnimation;
    private string currentColor;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3;
        this.ChangeColor();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump()
    {        
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(0, verticalForce));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColorChanger"))
        {
            this.ChangeColor();
            Destroy(collision.gameObject);
            return;
        }

        if (collision.gameObject.CompareTag("FinishLine"))
        {
            gameObject.SetActive(false);
            Instantiate(deadAnimation, transform.position, Quaternion.identity);
            Invoke("nextLvl", restartDelay);
            return;
        }

        if(!collision.gameObject.CompareTag(currentColor))
        {
            gameObject.SetActive(false);
            Instantiate(deadAnimation, transform.position ,Quaternion.identity);
            Invoke("RestartScene", restartDelay);
        }
    }

    void RestartScene()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);        
    }

    void nextLvl()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex + 1);
    }
    void ChangeColor()
    {

            switch (UnityEngine.Random.Range(0, 3))
            {

                case 0:
                    sp.color = yellowColor;
                currentColor = "Yellow";
                    break;
                case 1:
                    sp.color = purpleColor;
                    currentColor = "Purpple";
                    break;
                case 2:
                    sp.color = pinkColor;
                    currentColor = "Pink";
                    break;
                case 3:
                    sp.color = cyanColor;
                    currentColor = "Cyan";
                    break;
            }
        
    }
}
