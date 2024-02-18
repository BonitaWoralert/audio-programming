using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;

// NoteCallback.cs - This script shows how to define a callback to get notified
// on MIDI note-on/off events.

class NoteCallback : MonoBehaviour
{
    [SerializeField]GameObject shape = null;
    [SerializeField] GameObject text = null;

    void Start()
    {
        InputSystem.onDeviceChange += (device, change) =>
        {
            if (change != InputDeviceChange.Added) return;

            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) return;

            midiDevice.onWillNoteOn += (note, velocity) => {
                
                ChangeColour(note.shortDisplayName);
            };

            midiDevice.onWillNoteOff += (note) => {
                //note is off? what to do now
            };
        };
    }

    void ChangeColour(string noteName)
    {
        char letterNote = noteName[0];
        Debug.Log(letterNote);
        Color color = Color.white;
        switch (letterNote)
        {
            case 'C':
                color = Color.blue;
                break;
            case 'D':
                color = Color.green;
                break;
            case 'E':
                color = Color.magenta;
                break;
            case 'F':
                color = Color.yellow;
                break;
            case 'G':
                color = Color.gray;
                break;
            case 'A':
                color = Color.cyan;
                break;
            case 'B':
                color = Color.red;
                break;
            default:
                break;
        }

        shape.GetComponent<SpriteRenderer>().color = color;
        text.GetComponent<TextMeshPro>().text = noteName;
    }
}