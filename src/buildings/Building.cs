using Godot;
using System;
using System.Collections.Generic;

public abstract partial class Building : Node2D{
    protected List<Raven> employed = new ();
    protected double cooldown = 3f;
    protected double cooldownMax = 3f;
    private int maxEmploy = 1;
    private bool active = false;
    protected Inventory inventory;

    public Building(int maxEmploy, float maxCooldown) {
        this.maxEmploy = maxEmploy;
        this.cooldown = maxCooldown;
        this.cooldownMax = maxCooldown;
        
    }

    public Building() { }


    public override void _Ready() {
        inventory = (Inventory) GetTree().Root.GetChild(0).FindChild("Inventory");
        if (inventory == null) {
            GD.PushWarning("No inventory found!");
        }
    }

    public bool employ(Raven raven) {
        if (employed.Count >= maxEmploy) {
            return false;
        }
        if (employed.Contains(raven)) {
            return false;
        }
        GD.Print("Employing");
        raven.Position = Position;
        employed.Add(raven);
        active = true;
        return true;
    }

    public bool unemploy(Raven raven) {
        bool result = employed.Remove(raven);
        if (employed.Count == 0) {
            active = false;
        }

        if (result) {
            raven.Position = raven.spawnPoint;
        }
        return result;
    }

    public void unemployAll() {
        for (int i = 0; i < employed.Count; i++) {
            employed[i].Position = employed[i].spawnPoint;
        }
        employed.Clear();
        active = false;
        GD.Print("Unemployed all");
    }
    
    public override void _Process(double delta) {
        if (!active) {
            return;
        }
        cooldown -= delta;
        if (cooldown > 0) {
            return;
        }

        cooldown = cooldownMax;
        work(delta);

    }

    protected abstract void work(double delta);
}
