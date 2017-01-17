using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JRender : JBehaviour
{
    public JList<Sprite> sprites;
    private int sprite_index = -1;

    public void SetScale(int x, int y, int z)
    {
        SetScale((v) => new Vector3(x, y, z));
    }

    public void SetScale(Func<Vector3,Vector3> newScale)
    {
        transform.localScale = newScale(transform.localScale);
    }

    public void SetPos(int x, int y, int z)
    {
        SetPos((v) => new Vector3(x, y, z));
    }

    public void SetPos(Func<Vector3, Vector3> newPos)
    {
        transform.localPosition = newPos(transform.localPosition);
    }

    void Update()
    {
        
    }

    public Sprite sprite
    {
        get
        {
            if (GetComponent<SpriteRenderer>()) {
                return GetComponent<SpriteRenderer>().sprite;
            }
            if (GetComponent<Image>()) {
                return GetComponent<Image>().sprite;
            }
            Debug.Log("JRender: No Image or SpriteRenderer component");
            Debug.Break();
            return null;
        }

        set
        {
            if (GetComponent<SpriteRenderer>()) {
                GetComponent<SpriteRenderer>().sprite = value;
            }
            if (GetComponent<Image>()) {
                GetComponent<Image>().sprite = value;
            }
        }
    }

    public Color color
    {
        get
        {
            if (GetComponent<SpriteRenderer>()) {
                return GetComponent<SpriteRenderer>().color;
            }
            if (GetComponent<Image>()) {
                return GetComponent<Image>().color;
            }
            return GetComponent<Text>().color;
        }

        set
        {
            if (GetComponent<SpriteRenderer>()) {
                GetComponent<SpriteRenderer>().color = value;
            }
            if (GetComponent<Image>()) {
                GetComponent<Image>().color = value;
            }
            if (GetComponent<Text>()) {
                GetComponent<Text>().color = value;
            }
        }
    }

    public int spriteIndex
    {
        get
        {
            if (sprites.Count == 0) {
                Debug.Log("JRender: no sprites to set");
                Debug.Break();
            }

            return sprite_index;
        }

        set
        {
            if (sprites.Count == 0) {
                Debug.Log("JRender: no sprites to set");
                Debug.Break();
                sprite_index = -1;
                return;
            } else if (value < 0 || value > sprites.Count) {
                Debug.Log("JRender: index [" + value + "] out of sprites' range");
                Debug.Break();
                return;
            }

            sprite_index = value;
            sprite = sprites[sprite_index];
        }
    }
    
}

