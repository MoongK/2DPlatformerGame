using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print(other.gameObject.name);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            print(other.gameObject.name);
            Destroy(other.gameObject);
        }



    }

}
