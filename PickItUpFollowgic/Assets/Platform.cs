using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Card" || other.gameObject.tag == "RareCard")
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene("GameOver");
        }    
    }
}
