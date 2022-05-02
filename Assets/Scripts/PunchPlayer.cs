using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchPlayer : MonoBehaviour
{
    public Transform obj;
    public float xMove = 0.5f;

    private bool isTouch = false;

    private void OnTriggerEnter2D(Collider2D collision) { if (collision.gameObject.tag == "Player") isTouch = true; }
    private void OnTriggerExit2D(Collider2D collision) { isTouch = false; }

    private void Update()
    {
        if (isTouch && Input.GetKeyDown("f"))
            obj.position = new Vector2(obj.position.x + xMove, 0);
    }
}
