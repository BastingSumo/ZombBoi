using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFaceCursor : MonoBehaviour
{
    Transform Player;

    private void Awake()
    {
        Player = GetComponentInParent<Transform>();
    }

    public void RotateToMouse()
    {
        Vector2 MouseWorldPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Player.position;
        Debug.DrawRay(Player.position, MouseWorldPostion, Color.red);
        float direction = Mathf.Rad2Deg * Mathf.Atan(MouseWorldPostion.y/MouseWorldPostion.x);
        Player.rotation = Quaternion.Euler(0, 0, direction);
    }

    void Update()
    {
        RotateToMouse();
    }
}
