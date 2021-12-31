using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioActor : MonoBehaviour
{
    AudioSource myAudio;
    float alpha = 1f;

    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Busy.OnSwipRight += rightSound;
        Busy.OnSwipLeft += leftSound;
        StartCoroutine(Roppullstart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void rightSound()
    {
        Debug.Log("working");
        myAudio.panStereo = 1.0f;
    }
    void leftSound()
    {
        myAudio.panStereo = -1.0f;
        alpha += .1f;
    }

    IEnumerator Roppullstart()
    {
        
        while (alpha >= 0.0f)
        {

            Debug.Log(alpha);
            alpha -= .1f;
            if (alpha < 0.0f)
            {
                Debug.Log("Game Over");
                Time.timeScale = 0;
            }
            yield return new WaitForSeconds(.5f);
        }


    }
}