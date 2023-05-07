using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Collect : MonoBehaviour
{
    public Text KiwiScore;
    int KiwiCounter = 0;

    [SerializeField] private AudioSource collectionSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Kiwi"))
        {
           
            Destroy(other.gameObject);
            KiwiCounter++;
            KiwiScore.text = ("KIWI : " + KiwiCounter).ToString();
        }
    }
}
