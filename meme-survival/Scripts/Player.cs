using Godot;

namespace MemeSurvival.Scripts;

public partial class Player : CharacterBody2D
{
	[Export] private Label _hpLabel;
	// To do: Vytvořit signál
	[Signal] public delegate void PlayerDiedEventHandler();
	
	private const float Speed = 300.0f;
	public int Health = 100;
	public bool IsDead = false;
	public int Score = 0;
	private Vector2 _addKnockback;

	public override void _Ready()
	{
		_hpLabel.Text = "HP: " + Health;
	}
	
	public override void _PhysicsProcess(double delta)
	{
		if (IsDead)
			return;
		
		Vector2 velocity = Velocity;
		
		// To do: Změnit systémové akce na naše vlastní inputy
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
		
		Velocity = velocity + _addKnockback;
		_addKnockback = Vector2.Zero;
		MoveAndSlide();
	}

	public override void _Process(double delta)
	{
		if (Health <= 0)
			Die();
	}

	public void TakeDamage(int amount)
	{
		if (amount > Health)
			Health = 0;
		else
			Health -= amount;
		
		_hpLabel.Text = "HP: " + Health;
	}
	
	public void ProcessKnockback(Vector2 enemyPos, float force)
	{
		Vector2 knockbackDirection = (GlobalPosition - enemyPos).Normalized();
		_addKnockback = knockbackDirection * force;
	}

	private void Die()
	{
		// To do: Otevřít Game Over screen
		IsDead = true;
		EmitSignal(SignalName.PlayerDied);
	}
}
