﻿using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class MidiEventTrigger : MonoBehaviour {

    public bool[] instrumentFilter = new bool[129];
    public bool[] noteFilter = new bool[128];

    public UnityEvent eventNoteOn;
    public UnityEvent eventNoteOff;

    private bool _noteOn = false;

    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////
    /// MidiPlayer를 위한 함수들
    /// </summary>

    public void Play()
    {
        _noteOn = false;
        OnPlay();
    }

    public void Pause()
    {
        OnPause();
    }

    public void Resume()
    {
        OnResume();
    }

    public void Stop()
    {
        OnStop();
    }

    public void NoteOn(int instrument, int noteNumber)
    {
        if(_noteOn == false)
        {
            _noteOn = true;

            if (instrumentFilter[instrument] == true && noteFilter[noteNumber] == true)
            {
                OnNoteOn();
            }
        }
    }

    public void NoteOff(int instrument, int noteNumber)
    {
        _noteOn = false;
        if (instrumentFilter[instrument] == true && noteFilter[noteNumber] == true)
        {
            OnNoteOff();
        }
    }

    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////
    /// 파생클래스를 위한 함수들
    /// </summary>

    protected virtual void OnPlay()
    {

    }

    protected virtual void OnPause()
    {

    }

    protected virtual void OnResume()
    {

    }

    protected virtual void OnStop()
    {

    }

    protected virtual void OnNoteOn()
    {

    }

    protected virtual void OnNoteOff()
    {

    }
}

