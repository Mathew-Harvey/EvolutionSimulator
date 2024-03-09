void OnTriggerEnter(Collider col)
{
    //if the agent collides with a food object, it will eat it and gain energy.
    if (col.gameObject.tag == "Food")
    {
        energy += energyGained;
        reproductionEnergy += reproductionEnergyGained;
        Destroy(col.gameObject);
    }
}