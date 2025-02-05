using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{
    public float tiempo_start; //Los segundos por los quales comienza i la variable que utilizaremos para que vaya contando segundos.
    public float tiempo_end;//Segundos que queremos que pasen para que cambie de escena
                            // Update is called once per frame
    public float escena;

    public Animator transition;

    public float transitionTime = 1f;

    void Update()
    {
        tiempo_start += Time.deltaTime;//Función para que la variable tiempo_start vaya contando segundos.
        if (tiempo_start >= tiempo_end) //Si pasan los segundos que hemos puesto antes...
        {
            LoadNextLevel();
        }  
    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(3));
            }
        IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("start");
        //wait
        yield return new WaitForSeconds(transitionTime);

        //load scene
        SceneManager.LoadScene(levelIndex);
    }
}
