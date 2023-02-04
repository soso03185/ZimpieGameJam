using UnityEngine;


public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T mInstance;

    public static T Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = (T)FindObjectOfType(typeof(T));

                if (mInstance == null)
                {
                    Debug.LogError(typeof(T) + " is nothing");
                }
            }

            return mInstance;
        }
    }

    protected void OnApplicationQuit()
    {
        mInstance = null;
    }

    public virtual void Awake()
    {
        CheckInstance();
    }

    protected bool CheckInstance()
    {
        if (this == Instance)
        {
            return true;
        }

        //Debug.Log("���� ��ũ��Ʈ�� �߰��߽��ϴ� : " + this);
        Destroy(this.gameObject);
        return false;
    }
}