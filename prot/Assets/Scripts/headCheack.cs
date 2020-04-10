using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headCheack : MonoBehaviour
{
    private bool isHead = false;
    private bool isHeadEnter, isHeadStay, isHeadExit;

    public bool IsHead()
    {
        if (isHeadEnter || isHeadStay)
        {
            isHead = true;
        }
        else if (isHeadExit)
        {
            isHead = false;
        }

        isHeadEnter = false;
        isHeadStay = false;
        isHeadExit = false;

        return isHead;
    }

    public bool IsHeadEnter()
    {
        return isHeadEnter;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {
            isHeadEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {
            isHeadStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {
            isHeadExit = true;
        }
    }
}
