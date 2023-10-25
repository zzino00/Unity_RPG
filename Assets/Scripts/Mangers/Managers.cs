using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;// 유일성이 보장된다
    static Managers Instance { get { Init();  return s_instance; } }

    InputManger _input = new InputManger();
    ResourceManger _resource = new ResourceManger();
    SoundManager _sound = new SoundManager();
    public static InputManger Input { get { return Instance._input; } }
    public static ResourceManger Resource { get { return Instance._resource; } }

    public static SoundManager Sound { get { return Instance._sound; } }
    void Start()
    {
        Init();
        
    }

  
    void Update()
    {
        _input.OnUpdate();
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();

            s_instance._sound.Init();

        }

    }

}
