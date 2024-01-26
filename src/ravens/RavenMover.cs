using Godot;
using System;

public partial class RavenMover : Node {
	[Export]
	private Raven raven;
	
	private Random rng = new();
	
	public override void _Process(double delta)
	{
		// Move the node randomly
		MoveRandomly();

		// Apply the movement
		raven.MoveAndSlide();
	}
	
	private void MoveRandomly()
	{
		
		// Generate a random direction
		Vector2 randomDirection = new Vector2(rng.Next(-1, 1), rng.Next(-1, 1)).Normalized();

		// Set the velocity based on the random direction and a speed factor
		float speed = 100.0f; // Adjust the speed as needed
		raven.Velocity = randomDirection * speed;
	}
}
