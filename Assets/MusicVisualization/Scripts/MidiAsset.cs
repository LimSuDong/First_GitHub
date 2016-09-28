using UnityEngine;
using System.Collections;

public class MidiAsset : ScriptableObject
{
    [SerializeField]
    private MidiFile _midFile;

    public void FileLoad(string path)
    {
        _midFile = new MidiFile(path);
    }

    public string fileName
    {
        get
        {
            return _midFile.FileName;
        }
    }

    public float pulseTime
    {
        get
        {
            return (_midFile.Time.Tempo / _midFile.Time.Quarter / 1000000f); // PPQN   //마이크로세컨드 단위 따라서 나누기 1000000f
        }
    }

    public float totalTime
    {
        get
        {
            return _midFile.TotalPulses * pulseTime;
        }
    }

    public int numerator
    {
        get
        {
            return _midFile.Time.Numerator;
        }
    }

    public int denominator
    {
        get
        {
            return _midFile.Time.Denominator;
        }
    }

    public int PPQN
    {
        get
        {
            return _midFile.Time.Quarter;
        }
    }

    public int BPM
    {
        get
        {
            return (int)(60000000/_midFile.Time.Tempo);
        }
    }
}
