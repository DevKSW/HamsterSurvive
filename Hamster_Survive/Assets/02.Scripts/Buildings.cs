using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    private SpriteRenderer renderer = new SpriteRenderer();
    private Color mBackColor = new Color(0.5f,0.5f,0.5f,0.5f);
    private float mNowColor = 1.0f;
    private Color _mColor = Color.white;
    private Color mColor
    {
        get { return _mColor; }
        set
        {
            _mColor = value;
            renderer.color = _mColor;
        }
    }


    private bool NoOtherObject = true;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NoOtherObject = false;
        //renderer.color = mBackColor;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        mNowColor = Mathf.Lerp(mNowColor, 0.5f, 0.1f);
        mColor = new Color(mNowColor, mNowColor, mNowColor, mNowColor);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        NoOtherObject = true;
        mColor = Color.white ;
        mNowColor = 1.0f;
    }

    
    private void OnCollisionStay2D(Collision2D collision)
    {
        mColor = mBackColor;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (NoOtherObject)
        {
            mColor = Color.white;
            mNowColor = 1.0f;
            Debug.Log("Out" + collision.gameObject.name);
        }
    }

}
