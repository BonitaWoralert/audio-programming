using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayANote : MonoBehaviour
{
    private int notePlayed;
    private Vector3 startPos;
    private Vector3 targetPos;
    private float travelTime = 1f;
    private float currentTime = 0f;
    //notes 41 - 52
    //newnote = note - 40
    //position = (vertical space / 12) * newnote //set position depending on note? screen.height
    //yea

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        InputSystem.onDeviceChange += (device, change) =>
        {
            if (change != InputDeviceChange.Added) return;

            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) return;

            midiDevice.onWillNoteOn += (note, velocity) =>
            {
                if(note.noteNumber > 40 && note.noteNumber < 53) //between 41 and 52 (fret 1-12 on low E string of a guitar)
                {
                    if(note.noteNumber - 40 != notePlayed) //if different note played
                    {
                        notePlayed = note.noteNumber - 40;
                        startPos = transform.position; //set new start pos
                        currentTime = 0; //restart time
                    }
                }
            };
        };
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(-10, notePlayed - 6, 0);
        currentTime += Time.deltaTime;
        float t = currentTime / travelTime;

        transform.position = Vector3.Lerp(startPos, targetPos, t);

        if(currentTime >= travelTime)
        {
            currentTime = 0f;
            startPos = targetPos;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");
        Debug.Break();
    }
}
