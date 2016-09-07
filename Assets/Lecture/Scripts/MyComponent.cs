using UnityEngine;
using System.Collections;

public class MyComponent : MonoBehaviour {

    public int intVariable;
    public float floatVariable;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public int IntVar //함수 내 변수처럼 존재 - 프로퍼티(Property)
    {
        get // read only
        {
            return intVariable;
        }
        set // white only
        {
            intVariable = value;
        }
    }

    public void DoSomething()
    {
        intVariable++;
    }
}
