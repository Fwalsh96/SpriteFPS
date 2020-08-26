using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInteractionController : MonoBehaviour
{
    public int id;
    public SpriteRenderer render;
    public Sprite baseSprite;
    public Sprite transitionSprite;

    // Start is called before the first frame update
    void Start()
    {
        render = gameObject.GetComponent<SpriteRenderer>();

        GameEvents.current.onSpriteActivate += onSpriteActivate;
    }



    private void onSpriteActivate(int id) {

        if (id == this.id) {
            // Current Test Function, will likely use a switch case later.
            activateLampSwitch(id);
        }
    }

    public void activateLampSwitch(int id)
    {
        render.sprite = transitionSprite;
    }
}
