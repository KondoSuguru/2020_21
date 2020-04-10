using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] private float maxHp;
    [SerializeField] private float hp;
    private GameObject fire;
    private bool damage=false;
    // Start is called before the first frame update
    void Start()
    {
        fire = transform.GetChild(0).gameObject;
        fire.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(damage)
        {
            hp -= Time.deltaTime;
            if (hp <= 0)fire.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "fire")
        {
            if (!damage)
            {
                fire.SetActive(true);
                hp = maxHp;
            }
        }
        if (collider.tag == "enemy")
        {
            damage = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "enemy")
        {
            damage = false;
        }
    }

}
