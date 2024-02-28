using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;

class QTE : MonoBehaviour
{
    enum Note
    {
        C,
        CSharp,
        D,
        DSharp,
        E,
        F,
        FSharp,
        G,
        GSharp,
        A,
        ASharp,
        B
    }

    [SerializeField] private GameObject text;
    [SerializeField] private GameObject colour;
    private int playedNote;
    private int currentNote;
    [SerializeField] private float timeOut = 5.0f;
    private float timer = 0.0f;


    void Start()
    {
        InputSystem.onDeviceChange += (device, change) =>
        {
            if (change != InputDeviceChange.Added) return;

            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) return;

            midiDevice.onWillNoteOn += (note, velocity) => {
                //StartTimer(); //when note played, start timer
                playedNote = note.noteNumber;
            };
        };
        StartTimer();
    }

    void StartTimer()
    {
        //pick a note
        currentNote = Random.Range(0, 11);
        text.GetComponent<TextMeshProUGUI>().text = ((Note)currentNote).ToString();
        //colour.GetComponent<SpriteRenderer>().color = Color.grey;
        timer = Time.time + timeOut;
        Debug.Log("timer started");
    }

    private void Update()
    {
        if (Time.time > timer && timer != 0f)
        {
            Debug.Log("times up");
            colour.GetComponent<SpriteRenderer>().color = Color.red;
            timer = 0f; //reset timer
            StartTimer(); //start timer again + pick new note
        }
        if(playedNote % 12 == currentNote)
        {
            Debug.Log("woohoo");
            colour.GetComponent<SpriteRenderer>().color = Color.green;
            StartTimer(); //start timer again + pick new note
        }
    }
}