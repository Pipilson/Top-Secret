﻿using UnityEngine;

public class MovimentoJ5 : MonoBehaviour
{
    Grid grid;
    [HideInInspector] public Main main;

    void Start()
    {
        grid = FindObjectOfType<Grid>();
        main = GameObject.Find("Tabuleiro").GetComponent<Main>();
    }

    public void OnMouseDown()
    {
        if (main.dado > 0)
        {
            //Anda para baixo
            if (grid.LocalToCell(transform.position).x == 5 && grid.LocalToCell(transform.position).y != -3)
            {
                transform.position += grid.CellToLocal(new Vector3Int(0, -3, 0));
                transform.localScale = new Vector3(-1, 1, 1);
            }

            //Anda para a esquerda
            else if (grid.LocalToCell(transform.position).y == -3 && grid.LocalToCell(transform.position).x != -5)
            {
                transform.position += grid.CellToLocal(new Vector3Int(-2, 0, 0));
            }

            //Anda para cima
            else if (grid.LocalToCell(transform.position).y == -3)
            {
                transform.position += grid.CellToLocal(new Vector3Int(0, 3, 0));
                transform.localScale = new Vector3(1, 1, 1);
            }

            //Anda pra a direita
            else
            {
                transform.position += grid.CellToLocal(new Vector3Int(2, 0, 0));
            }

            main.dado--;

            if (main.dado == 0)
            {
                main.jogadorX++;
            }
        }
    }
}