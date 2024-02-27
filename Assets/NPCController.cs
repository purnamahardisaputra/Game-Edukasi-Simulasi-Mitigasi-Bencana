using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Animator NPCPeneliti;
    public Animator NPCBmkg;
    public Animator NPCPemadamKebakaran;
    public Animator NPCIbuKota;
    public static NPCController Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        NPCPeneliti = GameObject.Find("NPC Peneliti").GetComponentInChildren<Animator>();
        NPCBmkg = GameObject.Find("NPC BMKG").GetComponentInChildren<Animator>();
        NPCPemadamKebakaran = GameObject.Find("NPC Pemadam").GetComponentInChildren<Animator>();
        NPCIbuKota = GameObject.Find("NPC Ibu Kota").GetComponentInChildren<Animator>();
    }
}
