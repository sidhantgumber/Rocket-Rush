using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    public float delayInLoadTime = 1f;
    bool isTransitioning = false;
    public AudioClip crashSound;
    public AudioClip levelCompletedSound;

    public GameObject crashFX;
    public GameObject successFX;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
       
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (isTransitioning) { return; }  // matlab agar transition ho rahi hai to don't execute the lower block of code
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This is friendly");
                break;

            case "Finish":
                StartLevelCompletedSequence();
                Debug.Log("You have finished");
                break;
            default:
                Debug.Log("Boom!");
                StartCrashSequence();
                break;
        
        
        }
    }

    private void StartCrashSequence()
    {
        isTransitioning = true;
        GameObject crashFXclone = Instantiate(crashFX, gameObject.transform.position, Quaternion.identity);
        audioSource.Stop();  // used to stop thrust noise after crash
        audioSource.PlayOneShot(crashSound);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delayInLoadTime);
    }

    private void StartLevelCompletedSequence()
    {
        audioSource.Stop();  // used to stop thrust noise after crash
        GameObject successFXclone = Instantiate(successFX, gameObject.transform.position, Quaternion.identity);
        isTransitioning = true;
        audioSource.PlayOneShot(levelCompletedSound);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delayInLoadTime);
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

    }
    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);

    }
}
