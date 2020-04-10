using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seachArea : MonoBehaviour
{
    private bool isSeach = false;
    private bool isSeachEnter, isSeachStay, isSeachExit;
    private Vector2 dir = Vector2.zero;
    private List<Transform> firel;

    private void Start()
    {
        dir = Vector2.zero;
        firel = new List<Transform>();
    }

    public Vector2 SeachDir()
    {
        Debug.Log(dir);
        return dir.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "fire"|| collision.tag == "TorchFire")
        {
            isSeachEnter = true;
            firel.Add(collision.transform);
            dir = collision.transform.position - transform.position;
        }
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "fire")
    //    {
    //        isSeachStay = true;
    //        dir = collision.transform.position - transform.position;
    //    }
    //}

        //追加。複数search対象に対応
    private void Update()
    {
        if (firel.Count == 0)
        {
            dir = Vector2.zero;
        }
        else
        {
            Transform fire = firel[0];

            foreach (var f in firel)
            {
                if (Vector2.Distance(f.position, transform.position) < Vector2.Distance(f.position, transform.position))
                {
                    fire = f;
                }
            }
            //dir = collision.transform.position - transform.position;
            dir = fire.position - transform.position;
        }

        
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "fire" || collision.tag == "TorchFire")
        {
            isSeachExit = true;
            //dir = Vector2.zero;
            firel.Remove(collision.transform);
        }
    }
}
