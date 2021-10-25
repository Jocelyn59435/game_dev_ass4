using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject item;
    public AudioSource audioClip;
    private Tweener tweener;
    private float interval = 0.25f;
    private float passedTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
        audioClip = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        passedTime += Time.deltaTime;

        if (passedTime >= interval)
        {
            audioClip.Play();
            passedTime = 0.0f;
        }
        
       
    }
}

