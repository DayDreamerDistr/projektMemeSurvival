using Godot;
using System;

namespace MemeSurvival.Scripts;
	
public partial class BasicEnemy : CharacterBody2D
{
    private float _speed = 150.0f;
    [Export] private Player _player;
	
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
    {
        var playerPos = _player.GlobalPosition;
        var myPos = GlobalPosition;

        var distance = playerPos - myPos;
        var direction = distance.Normalized();
		
        var velocity = direction * _speed;
        Velocity = velocity;

        MoveAndSlide();
    }
}