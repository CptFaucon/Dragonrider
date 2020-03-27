using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearParticleManager : MonoBehaviour
{
    public ParticleSystem particle;
    private List<ParticleSystem> list = new List<ParticleSystem>();
    private int index = 0;

    public void PlayParticle(Vector3 position)
    {
        if (list.Count > 0 && !list[0].isPlaying) {
            list[index].Play();
        }
        else {
            list.Insert(index, InstantiateParticle());
        }
        list[index].transform.localPosition = position + new Vector3(0, 2, 0);
        index = (index + 1) % list.Count;
    }

    public ParticleSystem InstantiateParticle()
    {
        return Instantiate(particle, transform);
    }
}
