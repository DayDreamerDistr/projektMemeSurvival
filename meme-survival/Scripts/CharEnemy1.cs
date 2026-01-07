using Godot;
using System;

namespace MemeSurvival.Scripts;
	
public partial class CharEnemy1 : CharacterBody2D
{
	[Export] private Player _player;
	
	private float _speed = 150.0f;
	public int Damage = 20;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		var distance = _player.GlobalPosition - GlobalPosition;
		var direction = distance.Normalized();
		
		var velocity = direction * _speed;
		Velocity = velocity;

		MoveAndSlide();
	}

	// To do: Vytvořit signál pro Hitbox
	public void HitboxBodyEntered(Node2D body)
	{
		if (body is not Player)
			return;
		
		var player = body as Player; // Změníme typ body na třídu Player, abychom mohli použít metodu TakeDamage.
		player.TakeDamage(Damage);
	}
}
