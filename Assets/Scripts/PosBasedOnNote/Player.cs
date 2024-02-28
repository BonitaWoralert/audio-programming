using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayANote : MonoBehaviour
{
    private int notePlayed;

    //notes 41 - 52
    //newnote = note - 40
    //position = (vertical space / 12) * newnote //set position depending on note? screen.height
    //yea

    // Start is called before the first frame update
    void Start()
    {
        InputSystem.onDeviceChange += (device, change) =>
        {
            if (change != InputDeviceChange.Added) return;

            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) return;

            midiDevice.onWillNoteOn += (note, velocity) =>
            {
                if(note.noteNumber > 40 && note.noteNumber < 53) //between 41 and 52
                {
                    notePlayed = note.noteNumber - 40;
                }
            };
        };
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(-10, notePlayed-6);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");
        Debug.Break();
    }
}
