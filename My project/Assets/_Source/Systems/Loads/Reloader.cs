using UnityEngine;
using UnityEngine.SceneManagement;

public class Reloader : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Reloader Scene");
        }
    }
}
