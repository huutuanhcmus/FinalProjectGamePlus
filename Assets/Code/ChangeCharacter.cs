using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    public GameObject MainChar;
    public GameObject bar;
    public GameObject inforMainText;
    public GameObject inforBaseStatsText;
    public GameObject nextBack;
    public GameObject mainCharacter;
    public GameObject[] subCharacter;
    public int numNext;
    public int indexCur = 0;
    string[] inforMain;
    int[,] inforBaseStats;
    Vector4[] scale;
    // Start is called before the first frame update
    public void changeChar()
    {
        if (indexCur + numNext >= 0 && indexCur + numNext <= 10)
        {
            Destroy(MainChar);
            indexCur = indexCur + numNext;
            MainChar = Instantiate(subCharacter[indexCur], MainChar.transform.parent);
            MainChar.GetComponent<Transform>().localScale = new Vector3(scale[indexCur].y, scale[indexCur].z, scale[indexCur].w);
            MainChar.GetComponent<Transform>().rotation = Quaternion.Euler(0, scale[indexCur].x+77.6f, 0);
            inforMainText.GetComponent<UnityEngine.UI.Text>().text = inforMain[indexCur];
            inforBaseStatsText.GetComponent<UnityEngine.UI.Text>().text = "HP: " + inforBaseStats[indexCur, 0] + "\nAttack: " + inforBaseStats[indexCur, 1] + "\nDefense: " + inforBaseStats[indexCur, 2] + "\nSp.Atk: " + inforBaseStats[indexCur, 3] + "\nSp.Def: " + inforBaseStats[indexCur, 4] + "\nSpeed: " + inforBaseStats[indexCur, 5] + "\nTotal: " + (inforBaseStats[indexCur, 0] + inforBaseStats[indexCur, 1] + inforBaseStats[indexCur, 2] + inforBaseStats[indexCur, 3] + inforBaseStats[indexCur, 4] + inforBaseStats[indexCur, 5]).ToString();
            for (int i = 0; i < 6; i++)
                bar.gameObject.transform.GetChild(i).GetChild(1).GetComponent<Transform>().localScale = new Vector3(inforBaseStats[indexCur, i] / 150.0f, 1, 1);
            nextBack.GetComponent<ChangeCharacter>().indexCur = indexCur;
            nextBack.GetComponent<ChangeCharacter>().MainChar = MainChar;
        }
        
    }
    void Start()
    {
        inforMain = new string[11];
        inforMain[0] = "National No: 032\nType: POISON\nSpecies: 	Poison Pin Pokémon\nHeight: 	0.5 m(1′08″)\nWeight: 9.0 kg(19.8 lbs)\nAbilities: 1.Poison Point\n2.Rivalry\nHustle(hidden ability)\nLocal No:	032(Red / Blue / Yellow)\n098(Gold / Silver / Crystal)\n032(FireRed / LeafGreen)\n098(HeartGold / SoulSilver)\n107(X / Y — Coastal Kalos)\n032(Let's Go Pikachu/Let's Go Eevee)";
        inforMain[1] = "National No: 033\nType: POISON\nSpecies: 	Poison Pin Pokémon\nHeight: 	0.9 m (2′11″)\nWeight: 19.5 kg (43.0 lbs)\nAbilities: 1. Poison Point\n2. Rivalry\nHustle(hidden ability)\nLocal No:	033 (Red/Blue/Yellow)\n099 (Gold/Silver/Crystal)\n033 (FireRed/LeafGreen)\n099 (HeartGold/SoulSilver)\n108 (X/Y — Coastal Kalos)\n033 (Let's Go Pikachu/Let's Go Eevee)";
        inforMain[2] = "National No: 034\nType: POISON, GROUND\nSpecies: 	Drill Pokémon\nHeight: 	1.4 m (4′07″)\nWeight: 62.0 kg (136.7 lbs)\nAbilities: 1. Poison Point\n2. Rivalry\nSheer Force (hidden ability)\nLocal No:	034 (Red/Blue/Yellow)\n100 (Gold/Silver/Crystal)\n034 (FireRed/LeafGreen)\n100 (HeartGold/SoulSilver)\n109 (X/Y — Coastal Kalos)\n034 (Let's Go Pikachu/Let's Go Eevee)";
        inforMain[3] = "National No: 035\nType: FAIRY\nSpecies: 	Fairy Pokémon\nHeight: 	0.6 m (2′00″)\nWeight: 7.5 kg (16.5 lbs)\nAbilities: 1. Cute Charm\n2.Magic Guard\nFriend Guard(hidden ability)\nLocal No:	035 (Red/Blue/Yellow)\n041(Gold / Silver / Crystal)\n035(FireRed / LeafGreen)\n100(Diamond / Pearl)\n100(Platinum)\n041(HeartGold / SoulSilver)\n089(Black 2 / White 2)\n211(Sun / Moon — Alola dex)\n273(U.Sun / U.Moon — Alola dex)\n035(Let's Go Pikachu/Let's Go Eevee)";
        inforMain[4] = "National No: 036\nType: FAIRY\nSpecies: 	Fairy Pokémon\nHeight: 	1.3 m (4′03″)\nWeight: 40.0 kg (88.2 lbs)\nAbilities: 1. Cute Charm\n2.Magic Guard\nUnaware(hidden ability)\nLocal No:	036 (Red/Blue/Yellow)\n042(Gold / Silver / Crystal)\n0036(FireRed / LeafGreen)\n0101(Diamond / Pearl)\n0101(Platinum)\n0042(HeartGold / SoulSilver)\n0090(Black 2 / White 2)\n0212(Sun / Moon — Alola dex)\n0274(U.Sun / U.Moon — Alola dex)\n0036(Let's Go Pikachu/Let's Go Eevee)";
        inforMain[5] = "National No: 037\nType: FIRE\nSpecies: 		Fox Pokémon\nHeight: 	0.6 m (2′00″)\n9.9 kg (21.8 lbs)\nAbilities: 1. Flash Fire\nDrought(hidden ability)\nLocal No:	037 (Red/Blue/Yellow)\n125(Gold / Silver / Crystal)\n153(Ruby / Sapphire / Emerald)\n037(FireRed / LeafGreen)\n127(HeartGold / SoulSilver)\n248(Black 2 / White 2)\n160(Omega Ruby / Alpha Sapphire)\n253(Sun / Moon — Alola dex)\n330(U.Sun / U.Moon — Alola dex)\n037(Let's Go Pikachu/Let's Go Eevee)";
        inforMain[6] = "National No: 038\nType: FIRE\nSpecies: 		Fox Pokémon\nHeight: 	1.1 m (3′07″)\nWeight: 19.9 kg (43.9 lbs)\nAbilities: 1. Flash Fire\nDrought(hidden ability)\nLocal No:	038 (Red/Blue/Yellow)\n126(Gold / Silver / Crystal)\n154(Ruby / Sapphire / Emerald)\n038(FireRed / LeafGreen)\n128(HeartGold / SoulSilver)\n249(Black 2 / White 2)\n161(Omega Ruby / Alpha Sapphire)\n254(Sun / Moon — Alola dex)\n331(U.Sun / U.Moon — Alola dex)\n038(Let's Go Pikachu/Let's Go Eevee)";
        inforMain[7] = "National No: 039\nType: NORMAL, FAIRY\nSpecies: 	Balloon Pokémon\nHeight: 	0.5 m (1′08″)\nWeight: 5.5 kg (12.1 lbs)\nAbilities: 1. Cute Charm\n2.Competitive\nFriend Guard(hidden ability)\nLocal No:	039 (Red/Blue/Yellow)\n044(Gold / Silver / Crystal)\n138(Ruby / Sapphire / Emerald)\n039(FireRed / LeafGreen)\n044(HeartGold / SoulSilver)\n282(Black 2 / White 2)\n120(X / Y — Mountain Kalos)\n143(Omega Ruby / Alpha Sapphire)\n135(Sun / Moon — Alola dex)\n168(U.Sun / U.Moon — Alola dex)\n039(Let's Go Pikachu/Let's Go Eevee)";
        inforMain[8] = "National No: 040\nType: NORMAL, FAIRY\nSpecies: 	Balloon Pokémon\nHeight: 	1.0 m (3′03″)\nWeight: 12.0 kg (26.5 lbs)\nAbilities: 1. Cute Charm\n2.Competitive\nFrisk(hidden ability)\nLocal No:	040 (Red/Blue/Yellow)\n045(Gold / Silver / Crystal)\n139(Ruby / Sapphire / Emerald)\n040(FireRed / LeafGreen)\n045(HeartGold / SoulSilver)\n283(Black 2 / White 2)\n121(X / Y — Mountain Kalos)\n144(Omega Ruby / Alpha Sapphire)\n136(Sun / Moon — Alola dex)\n169(U.Sun / U.Moon — Alola dex)\n040(Let's Go Pikachu/Let's Go Eevee)";
        inforMain[9] = "National No: 041\nType: POISON, FLYING\nSpecies: 	Bat Pokémon\nHeight: 	0.8 m (2′07″)\nWeight: 7.5 kg (16.5 lbs)\nAbilities: 1. Inner Focus\nInfiltrator(hidden ability)\nLocal No:	041 (Red/Blue/Yellow)\n037(Gold / Silver / Crystal)\n063(Ruby / Sapphire / Emerald)\n041(FireRed / LeafGreen)\n028(Diamond / Pearl)\n028(Platinum)\n037(HeartGold / SoulSilver)\n061(Black 2 / White 2)\n145(X / Y — Central Kalos)\n065(Omega Ruby / Alpha Sapphire)\n068(Sun / Moon — Alola dex)\n080(U.Sun / U.Moon — Alola dex)\n041(Let's Go Pikachu/Let's Go Eevee)";
        inforMain[10] = "National No: 042\nType: POISON, FLYING\nSpecies: 	Bat Pokémon\nHeight: 	1.6 m (5′03″)\nWeight: 55.0 kg (121.3 lbs)\nAbilities: 1. Inner Focus\nInfiltrator(hidden ability)\nLocal No:	042 (Red/Blue/Yellow)\n038(Gold / Silver / Crystal)\n064(Ruby / Sapphire / Emerald)\n042(FireRed / LeafGreen)\n029(Diamond / Pearl)\n029(Platinum)\n038(HeartGold / SoulSilver)\n062(Black 2 / White 2)\n146(X / Y — Central Kalos)\n066(Omega Ruby / Alpha Sapphire)\n069(Sun / Moon — Alola dex)\n081(U.Sun / U.Moon — Alola dex)\n042(Let's Go Pikachu/Let's Go Eevee)";
        inforBaseStats = new int[11, 6];
        inforBaseStats[0, 0] = 46;
        inforBaseStats[0, 1] = 57;
        inforBaseStats[0, 2] = 40;
        inforBaseStats[0, 3] = 40;
        inforBaseStats[0, 4] = 40;
        inforBaseStats[0, 5] = 50;
        inforBaseStats[1, 0] = 61;
        inforBaseStats[1, 1] = 72;
        inforBaseStats[1, 2] = 57;
        inforBaseStats[1, 3] = 55;
        inforBaseStats[1, 4] = 55;
        inforBaseStats[1, 5] = 65;
        inforBaseStats[2, 0] = 81;
        inforBaseStats[2, 1] = 102;
        inforBaseStats[2, 2] = 77;
        inforBaseStats[2, 3] = 85;
        inforBaseStats[2, 4] = 75;
        inforBaseStats[2, 5] = 85;
        inforBaseStats[3, 0] = 46;
        inforBaseStats[3, 1] = 57;
        inforBaseStats[3, 2] = 40;
        inforBaseStats[3, 3] = 40;
        inforBaseStats[3, 4] = 40;
        inforBaseStats[3, 5] = 50;
        inforBaseStats[4, 0] = 95;
        inforBaseStats[4, 1] = 70;
        inforBaseStats[4, 2] = 73;
        inforBaseStats[4, 3] = 95;
        inforBaseStats[4, 4] = 90;
        inforBaseStats[4, 5] = 60;
        inforBaseStats[5, 0] = 38;
        inforBaseStats[5, 1] = 41;
        inforBaseStats[5, 2] = 40;
        inforBaseStats[5, 3] = 50;
        inforBaseStats[5, 4] = 65;
        inforBaseStats[5, 5] = 65;
        inforBaseStats[6, 0] = 73;
        inforBaseStats[6, 1] = 76;
        inforBaseStats[6, 2] = 75;
        inforBaseStats[6, 3] = 81;
        inforBaseStats[6, 4] = 100;
        inforBaseStats[6, 5] = 100;
        inforBaseStats[7, 0] = 115;
        inforBaseStats[7, 1] = 45;
        inforBaseStats[7, 2] = 20;
        inforBaseStats[7, 3] = 45;
        inforBaseStats[7, 4] = 25;
        inforBaseStats[7, 5] = 20;
        inforBaseStats[8, 0] = 140;
        inforBaseStats[8, 1] = 70;
        inforBaseStats[8, 2] = 45;
        inforBaseStats[8, 3] = 85;
        inforBaseStats[8, 4] = 50;
        inforBaseStats[8, 5] = 45;
        inforBaseStats[9, 0] = 40;
        inforBaseStats[9, 1] = 45;
        inforBaseStats[9, 2] = 35;
        inforBaseStats[9, 3] = 30;
        inforBaseStats[9, 4] = 40;
        inforBaseStats[9, 5] = 55;
        inforBaseStats[10, 0] = 75;
        inforBaseStats[10, 1] = 80;
        inforBaseStats[10, 2] = 70;
        inforBaseStats[10, 3] = 65;
        inforBaseStats[10, 4] = 75;
        inforBaseStats[10, 5] = 90;
        for (int i = 0; i < 6; i++)
            bar.gameObject.transform.GetChild(i).GetChild(1).GetComponent<Transform>().localScale = new Vector3(inforBaseStats[indexCur, i] / 200.0f, 1, 1);
        scale = new Vector4[11];
        scale[0] = new Vector4(0, 1, 1, 1);
        scale[1] = new Vector4(0, 0.7f, 0.7f, 0.7f);
        scale[2] = new Vector4(0, 0.4f, 0.4f, 0.4f);
        scale[3] = new Vector4(182, 2, 2, 2);
        scale[4] = new Vector4(0, 0.4f, 0.4f, 0.4f);
        scale[5] = new Vector4(0, 1, 1, 1);
        scale[6] = new Vector4(0, 0.5f, 0.5f, 0.5f);
        scale[7] = new Vector4(0, 1f, 1f, 1f);
        scale[8] = new Vector4(0, 0.5f, 0.5f, 0.5f);
        scale[9] = new Vector4(182, 1.7f, 1.7f, 1.7f);
        scale[10] = new Vector4(182, 0.7f, 0.7f, 0.7f);






    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
