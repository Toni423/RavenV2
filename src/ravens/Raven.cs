using Godot;
using System;

public partial class Raven : CharacterBody2D {
    public RavenAttributes attributes = new ();
    public string name { get; private set; }
    public Vector2 spawnPoint;

    public void levelUp(RavenAttributes.types type) {
        attributes.levelUp(type);
    }
    
    public int getAttributeLevel(RavenAttributes.types type) {
        return attributes.getAttributeLevel(type);
    }

    public override void _Ready() {
        base._Ready();
        spawnPoint = Position;
    }
}
