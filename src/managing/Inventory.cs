using Godot;
using System;
using System.Collections.Generic;

public partial class Inventory : Node {
    public enum ressourceTypes {
        worms, 
        wood
    }
    private Dictionary<ressourceTypes, int> ressources = new();

    public Inventory() {
        ressources.Add(ressourceTypes.worms, 0);
        ressources.Add(ressourceTypes.wood, 0);
    }

    private object locker = new ();
    public void addRessource(ressourceTypes type, int amount) {
        lock (locker) {
            ressources[type]+= amount;
        }
    }

    private double coolDown = 5;
    public override void _Process(double delta) {
        coolDown -= delta;
        if (coolDown > 0) {
            return;
        }

        coolDown = 5;
        GD.Print("Worms: " + ressources[ressourceTypes.worms]);
    }




    private Raven selectedRaven;
    
    public void clickedOn(Node node) {
        if (node.IsInGroup("Raven")) {
            selectedRaven = (Raven)node;
            return;
        }

        if (node.IsInGroup("Building") ) {

            if (selectedRaven != null) {
                ((Building)node).employ(selectedRaven);
                selectedRaven = null;
                return;
            }
            
            ((Building) node).unemployAll();
        }
        
        
        
    }
}
