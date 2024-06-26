using UnityEngine;
using UnityEngine.UI;

public class EstrelaBotao : MonoBehaviour
{
    [HideInInspector] public int casa;
    [HideInInspector] public Main main;
    public Button[] button;

    void Start()
    {
        casa = 7;
        main = GameObject.Find("Tabuleiro").GetComponent<Main>();
    }

    void Update()
    {
        if (!main.pegouEstrela)
        {
            for (int i = 0; i <= 11; i++)
            {
                button[i].enabled = false;
            }
        }

        else
        {
            for (int i = 0; i <= 11; i++)
            {
                button[i].enabled = true;
            }
        }

        if (main.gameOver)
        {
            for (int i = 0; i <= 11; i++)
            {
                button[i].enabled = false;
            }
        }
    }

    public void Casa0()
    {
        if (main.pos0 != new Vector3(-6, 2, 0) && main.pos1 != new Vector3(-5, 2, 0) && main.pos2 != new Vector3(-6, 1, 0) && main.pos3 != new Vector3(-5, 1, 0) && main.pos4 != new Vector3(-6, 0, 0) && main.pos5 != new Vector3(-5, 0, 0))
        {
            casa = 0;
            main.pegouEstrela = false;
            main.jogadorX++;
        }
    }

    public void Casa1()
    {
        if (main.pos0 != new Vector3(-4, 2, 0) && main.pos1 != new Vector3(-3, 2, 0) && main.pos2 != new Vector3(-4, 1, 0) && main.pos3 != new Vector3(-3, 1, 0) && main.pos4 != new Vector3(-4, 0, 0) && main.pos5 != new Vector3(-3, 0, 0))
        {
            casa = 1;
            main.pegouEstrela = false;
            main.jogadorX++;
        }
    }

    public void Casa2()
    {
        if (main.pos0 != new Vector3(-2, 2, 0) && main.pos1 != new Vector3(-1, 2, 0) && main.pos2 != new Vector3(-2, 1, 0) && main.pos3 != new Vector3(-1, 1, 0) && main.pos4 != new Vector3(-2, 0, 0) && main.pos5 != new Vector3(-1, 0, 0))
        {
            casa = 2;
            main.pegouEstrela = false;
            main.jogadorX++;
        }
    }

    public void Casa3()
    {
        if (main.pos0 != new Vector3(0, 2, 0) && main.pos1 != new Vector3(1, 2, 0) && main.pos2 != new Vector3(0, 1, 0) && main.pos3 != new Vector3(1, 1, 0) && main.pos4 != new Vector3(0, 0, 0) && main.pos5 != new Vector3(1, 0, 0))
        {
            casa = 3;
            main.pegouEstrela = false;
            main.jogadorX++;
        }
    }

    public void Casa4()
    {
        if (main.pos0 != new Vector3(2, 2, 0) && main.pos1 != new Vector3(3, 2, 0) && main.pos2 != new Vector3(2, 1, 0) && main.pos3 != new Vector3(3, 1, 0) && main.pos4 != new Vector3(2, 0, 0) && main.pos5 != new Vector3(3, 0, 0))
        {
            casa = 4;
            main.pegouEstrela = false;
            main.jogadorX++;
        }
    }

    public void Casa5()
    {
        if (main.pos0 != new Vector3(4, 2, 0) && main.pos1 != new Vector3(5, 2, 0) && main.pos2 != new Vector3(4, 1, 0) && main.pos3 != new Vector3(5, 1, 0) && main.pos4 != new Vector3(4, 0, 0) && main.pos5 != new Vector3(5, 0, 0))
        {
            casa = 5;
            main.pegouEstrela = false;
            main.jogadorX++;
        }
    }

    public void Casa6()
    {
        if (main.pos0 != new Vector3(4, -1, 0) && main.pos1 != new Vector3(5, -1, 0) && main.pos2 != new Vector3(4, -2, 0) && main.pos3 != new Vector3(5, -2, 0) && main.pos4 != new Vector3(4, -3, 0) && main.pos5 != new Vector3(5, -3, 0))
        {
            casa = 6;
            main.pegouEstrela = false;
            main.jogadorX++;
        }
    }

    public void Casa7()
    {
        if (main.pos0 != new Vector3(2, -1, 0) && main.pos1 != new Vector3(3, -1, 0) && main.pos2 != new Vector3(2, -2, 0) && main.pos3 != new Vector3(3, -2, 0) && main.pos4 != new Vector3(2, -3, 0) && main.pos5 != new Vector3(3, -3, 0))
        {
            casa = 7;
            main.pegouEstrela = false;
            main.jogadorX++;
        }
    }

    public void Casa8()
    {
        if (main.pos0 != new Vector3(0, -1, 0) && main.pos1 != new Vector3(1, -1, 0) && main.pos2 != new Vector3(0, -2, 0) && main.pos3 != new Vector3(1, -2, 0) && main.pos4 != new Vector3(0, -3, 0) && main.pos5 != new Vector3(1, -3, 0))
        {
            casa = 8;
            main.pegouEstrela = false;
            main.jogadorX++;
        }
    }

    public void Casa9()
    {
        if (main.pos0 != new Vector3(-2, -1, 0) && main.pos1 != new Vector3(-1, -1, 0) && main.pos2 != new Vector3(-2, -2, 0) && main.pos3 != new Vector3(-1, -2, 0) && main.pos4 != new Vector3(-2, -3, 0) && main.pos5 != new Vector3(-1, -3, 0))
        {
            casa = 9;
            main.pegouEstrela = false;
            main.jogadorX++;
        }
    }

    public void Casa10()
    {
        if (main.pos0 != new Vector3(-4, -1, 0) && main.pos1 != new Vector3(-3, -1, 0) && main.pos2 != new Vector3(-4, -2, 0) && main.pos3 != new Vector3(-3, -2, 0) && main.pos4 != new Vector3(-4, -3, 0) && main.pos5 != new Vector3(-3, -3, 0))
        {
            casa = 10;
            main.pegouEstrela = false;
            main.jogadorX++;
        }
    }

    public void CasaMenos3()
    {
        if (main.pos0 != new Vector3(-6, -1, 0) && main.pos1 != new Vector3(-5, -1, 0) && main.pos2 != new Vector3(-6, -2, 0) && main.pos3 != new Vector3(-5, -2, 0) && main.pos4 != new Vector3(-6, -3, 0) && main.pos5 != new Vector3(-5, -3, 0))
        {
            casa = -3;
            main.pegouEstrela = false;
            main.jogadorX++;
        }
    }
}