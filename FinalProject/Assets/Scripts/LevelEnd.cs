using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] string nextLevel;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tate"))
        {
            Debug.Log("Level Complete");
            SceneManager.LoadScene(nextLevel);
        }
    }
}
