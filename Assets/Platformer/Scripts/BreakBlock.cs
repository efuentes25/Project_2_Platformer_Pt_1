using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

// https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
public class BreakBlock : MonoBehaviour
{
    public TextMeshProUGUI coinsCounter;
    public TextMeshProUGUI pointsCounter;

    public float maxHeight;
    public float minHeight;
    public float speed;
    public string inputAxis;

    public int coinScore = 0;
    public int pointScore= 0;

    public AudioSource audioSource;
   // public AudioClip coinSound;
   void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // clicks to destroy the objects
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit click;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out click))
            {
                BoxCollider bc = click.collider as BoxCollider;
                if (bc != null)
                {
                    if (click.transform.tag == "GoldBlock")
                    {
                        //audioSource.clip = coinSound;
                        audioSource.Play();
                        Destroy(bc.gameObject);
                        coinScore++;
                        pointScore += 200;
                        //Debug.Log($"hit");
                    }
                    else if (click.transform.tag == "BrickBlock")
                    {
                        Destroy(bc.gameObject);
                        pointScore += 100;
                    }
                }
            }
        }
        
        // prints to the UI text for the coins and points
        coinsCounter.text = "Coins \n" + coinScore.ToString();
        pointsCounter.text = "Score \n" + pointScore.ToString();

        
        // Code to move the camera
        float direction = Input.GetAxis(inputAxis);
        Vector3 newPos = transform.position + new Vector3(direction, 0, 0f) * (speed * Time.deltaTime);
        newPos.z = Mathf.Clamp(newPos.z, minHeight, maxHeight);

        transform.position = newPos;
    }
}
