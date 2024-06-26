using UnityEngine;

public class Dado : MonoBehaviour
{
    Main main;
    GameObject[] dado;

    void Start()
    {
        dado = new GameObject[7];
        main = GameObject.Find("Tabuleiro").GetComponent<Main>();

        for (int i = 0; i <= 6; i++)
        {
            dado[i] = GameObject.Find("dado" + i);
            dado[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void Update()
    {
        for (int i = 0; i <= 6; i++)
        {
            if (i == main.dado)
            {
                dado[i].GetComponent<SpriteRenderer>().enabled = true;
            }

            if (i != main.dado)
            {
                dado[i].GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}