using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    private int fruits = 0;
    public Text fruitsText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ödül"))
        {
            Destroy(other.gameObject);

            fruits++;
            fruitsText.text = "You Have To Collect All The Fruits " + fruits +"/9";
        }
    }
    public void FixedUpdate()
    {
        if (fruits >= 9)
        {
            SceneManager.LoadScene("FinishGame");
        }
    }
}
