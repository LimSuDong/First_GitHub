using UnityEngine;
using System.Collections;

[AddComponentMenu("Effects/MyCompnent Script")] // Effects메뉴에 스크립트 추가메뉴 추가
public class MyComponent : MonoBehaviour {

    public int intVariable;
    public float floatVariable;
    public GameObject[] gameObjectsList;

    [SerializeField]
    private int _intVar;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }


    /// <summary>
    /// 외부에서 볼때는 변수처럼 보이나 함수처럼 동작함
    /// </summary>
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
