using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Lean.Gui.LeanJoystick leanJoystick;

    public float acceleration = 2000f;

    public float maxSpeed = 0.6f;

    private new Rigidbody2D rigidbody2D = null;

    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (leanJoystick != null)
        {
            // Le vecteur n'est pas normaliser pour que l'utilisateur puisse choisir la vitesse avec le joystick.
            movement = new Vector3(leanJoystick.ScaledValue.x, leanJoystick.ScaledValue.y, 0);
        }
    }

    // FixedUpdate may be called multiple times per frame
    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    public void MoveCharacter(Vector3 direction)
    {
        if(rigidbody2D != null)
        {
            float speed = acceleration * Time.fixedDeltaTime;
            Vector3 dir = direction * Mathf.Min(speed, maxSpeed);

            rigidbody2D.velocity += new Vector2(dir.x, dir.y);
            
            //Debug.Log("Speed: " + dir.magnitude.ToString());
            //Debug.Log(rigidbody2D.velocity);
        }
    }
}
