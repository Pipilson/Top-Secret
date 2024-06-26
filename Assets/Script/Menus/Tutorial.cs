using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject[] p;
    public Sprite[] dado;
    public SpriteRenderer spriteRenderer;
    float spriteCount;

    void Start()
    {
        p[0].GetComponent<SpriteRenderer>().color = Color.red;
        p[1].GetComponent<SpriteRenderer>().color = Color.blue;
        p[2].GetComponent<SpriteRenderer>().color = Color.green;
        p[3].GetComponent<SpriteRenderer>().color = Color.yellow;
        p[4].GetComponent<SpriteRenderer>().color = Color.cyan;
        p[5].GetComponent<SpriteRenderer>().color = Color.magenta;
    }

    void Update()
    {
        DadoAnim();
    }

    public void Voltar()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void DadoAnim()
    {
        spriteCount += 2 * Time.deltaTime;

        if (spriteCount >= dado.Length)
        {
            spriteCount = 0;
        }

        spriteRenderer.sprite = dado[(int)spriteCount];
    }
}