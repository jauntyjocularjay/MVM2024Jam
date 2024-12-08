using UnityEngine;

public class BeamBarrier : MonoBehaviour
{
    public Beam[] beams;
    public bool generatorInTact;
    public GameObject generator;
    void Start()
    {
        beams = gameObject.GetComponentsInChildren<Beam>();
        generatorInTact = true;
    }
    bool Collision()
    {
        

        return false;
    }
    bool GeneratorInTact()
    {
        return generatorInTact;
    }
    void GeneratorDestruction()
    {
        foreach(Beam beam in beams)
        {
            beam.Deactivate();
        }
    }

}
