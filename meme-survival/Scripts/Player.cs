using Godot;
using System;

namespace MemeSurvival.Scripts;

public partial class Player : CharacterBody2D
{
    private const float Speed = 300.0f;
    
    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        // Získá směr na základě pohybu
        // To do: Zaměnit UI akce za vlastní inputy
        Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        if (direction != Vector2.Zero)
        {
            velocity = direction * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}