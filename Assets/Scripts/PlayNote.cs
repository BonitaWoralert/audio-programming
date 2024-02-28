using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;

class PlayNote : MonoBehaviour
{
    /*
    When note is played:
        start timer
        save note

        If time passes with no note
            stop
        else if more notes
            save note

    once stopped:
    output the string of notes and do whatever the combo thing is :)
    also make a way to save a new string
    */

    List<int> notesPlayed = new();
    [SerializeField]List<int> combo1 = new();
    [SerializeField] private float timeOut = 3.0f;
    private float timer = 0.0f;


    void Start()
    {
        InputSystem.onDeviceChange += (device, change) =>
        {
            if (change != InputDeviceChange.Added) return;

            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) return;

            midiDevice.onWillNoteOn += (note, velocity) => {
                StartTimer(); //when note played, start timer
                notesPlayed.Add(note.noteNumber);
            };

            midiDevice.onWillNoteOff += (note) => {
                //note is off? what to do now
            };
        };
    }

    bool IsCombo()
    {
        if (combo1.Count != notesPlayed.Count) return false;
        for (int i = 0; i < combo1.Count; i++)
        {
            if(combo1[i] != notesPlayed[i]) return false;
        }
        return true;
    }

    void StartTimer()
    {
        timer = Time.time + timeOut;
        Debug.Log("timer started");
    }

    private void Update()
    {
        if (Time.time > timer && timer != 0f)
        {
            Debug.Log("times up");
            OutputPlayedNotes();
            if(IsCombo())
            {
                Debug.Log("COMBO!");
            }
            notesPlayed.Clear(); //reset list
            timer = 0f; //reset timer
        }
    }
    void OutputPlayedNotes()
    {
        Debug.Log("notes played are:");
        foreach (int note in notesPlayed)
            Debug.Log(note);
    }
}