using System.Threading.Tasks;
using Godot;

namespace MemeSurvival.Scripts;
	
public partial class BasicEnemy : CharacterBody2D
{
	public Player PlayerChar;
	private ShaderMaterial _shaderMaterial;
	
	private float _speed = 150.0f;
	private int _damage = 20;
	public int Health = 100;
	private bool _isDead;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// To do: Získat path k player
		PlayerChar = GetNode<Player>("../../Player");
		var sprite = GetNode<Sprite2D>("Sprite2D");
		_shaderMaterial = sprite.Material as ShaderMaterial;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		if (_isDead)
			return;
		
		var distance = PlayerChar.GlobalPosition - GlobalPosition;
		var direction = distance.Normalized();
		
		var velocity = direction * _speed;
		Velocity = velocity;

		MoveAndSlide();
	}

	public override void _Process(double delta)
	{
		if (Health <= 0)
			Die();

		if (_isDead)
			return;
	}

	// To do: Vytvořit signál pro Hitbox
	private void HitboxBodyEntered(Node2D body)
	{
		if (_isDead)
			return;
		
		if (body is not Player)
			return;
		
		var player = (Player)body; // Změníme typ body na třídu Player, abychom mohli použít metodu TakeDamage.
		player.TakeDamage(_damage);
	}
	
	public async Task FlashRed()
	{
		if (_shaderMaterial == null) return;

		// Turn the shader flash on
		_shaderMaterial.SetShaderParameter("active", true);

		// Wait for 0.1 seconds
		await Task.Delay(100);

		// Turn the shader flash off
		// Check if the node is still valid (not destroyed) before setting parameter
		if (IsInstanceValid(this))
		{
			_shaderMaterial.SetShaderParameter("active", false);
		}
	}

	private void Die()
	{
		// Momentálně je _isDead k ničemu, ale mohlo by se hodit kdybychom chtěli spustit třeba Death Animation
		_isDead = true;
		QueueFree();
	}
}
