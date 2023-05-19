using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Collect : MonoBehaviour
{
    private PlayerManager player;
    private int KiwiCounter = 0;

    private void Start()
    {
        player = GetComponent<PlayerManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Kiwi"))
        {
           
            Destroy(other.gameObject);
            KiwiCounter++;
            player.KiwiScore.text = ("KIWI : " + KiwiCounter).ToString();
            player.CollectionSound.Play();
        }
    }
}
