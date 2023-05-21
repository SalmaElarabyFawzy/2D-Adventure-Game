using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Collect : MonoBehaviour
{
    private PlayerManager player;
    private int KiwiCounter = 0;
    private AudioSource CollectSound;
    private Text KiwiScore;
    private void Awake()
    {
        player = GetComponent<PlayerManager>();
        CollectSound = player.CollectionSound;
        KiwiScore = player.KiwiScore;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Kiwi"))
        {
           
            Destroy(other.gameObject);
            KiwiCounter++;
            KiwiScore.text = ("KIWI : " + KiwiCounter).ToString();
            CollectSound.Play();
        }
    }
}
