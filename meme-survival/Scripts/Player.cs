using Godot;

namespace MemeSurvival.Scripts;

public partial class Player : CharacterBody2D
{
	[Export] private Label _hpLabel;
	// To do: Vytvořit signál
	[Signal] public delegate void PlayerDiedEventHandler();
	
	private const float Speed = 300.0f;
	public int Health = 100;
	private bool _isDead = false;

	public override void _Ready()
	{
		_hpLabel.Text = "HP: " + Health;
	}
	
	public override void _PhysicsProcess(double delta)
	{
		if (_isDead)
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
		
		Velocity = velocity;
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

	private void Die()
	{
		// To do: Otevřít Game Over screen
		_isDead = true;
		EmitSignal(SignalName.PlayerDied);
	}
}
