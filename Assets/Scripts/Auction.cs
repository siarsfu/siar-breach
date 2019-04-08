using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Auction : MonoBehaviour {
    //Class takes care of the auction process (timing it, replacing the text, playing audio)

    //////////////////////////////////////////////////////////////////////////// FIELDS ///////////////////////////////////////////////////////////////////////
    readonly static string _brands = "<color=#3ea6f2>sport_brand</color> == pending";
    readonly static string _weight = "<color=#3ea6f2>weight</color> == pending";
    readonly static string _location_history = "<color=#3ea6f2>location_history</color> == pending";
    readonly static string _narcotic_use = "<color=#3ea6f2>narcotic_use</color> == pending";
    readonly static string _age = "<color=#3ea6f2>age</color> == pending";
    string[] _array = { _brands, _weight, _location_history, _narcotic_use, _age };

    readonly static string a_brands = "<color=#3ea6f2>sport_brand</color> == pending";
    readonly static string a_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(1)</color>";
    readonly static string a_location_history = "<color=#3ea6f2>location_history</color> == pending";
    readonly static string a_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(1)</color>";
    readonly static string a_age = "<color=#3ea6f2>age</color> == pending";
    string[] a_array = { a_brands, a_weight, a_location_history, a_narcotic_use, a_age };

    readonly static string b_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(1)</color>";
    readonly static string b_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(2)</color>";
    readonly static string b_location_history = "<color=#3ea6f2>location_history</color> == pending";
    readonly static string b_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(1)</color>";
    readonly static string b_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(1)</color>";
    string[] b_array = { b_brands, b_weight, b_location_history, b_narcotic_use, b_age };

    readonly static string c_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(1)</color>";
    readonly static string c_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(2)</color>";
    readonly static string c_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(1)</color>";
    readonly static string c_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(1)</color>";
    readonly static string c_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(3)</color>";
    string[] c_array = { c_brands, c_weight, c_location_history, c_narcotic_use, c_age };

    readonly static string d_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(2)</color>";
    readonly static string d_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(3)</color>";
    readonly static string d_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(2)</color>";
    readonly static string d_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(1)</color>";
    readonly static string d_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(4)</color>";
    string[] d_array = { d_brands, d_weight, d_location_history, d_narcotic_use, d_age };

    readonly static string e_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(2)</color>";
    readonly static string e_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(3)</color>";
    readonly static string e_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(2)</color>";
    readonly static string e_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(2)</color>";
    readonly static string e_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(4)</color>";
    string[] e_array = { e_brands, e_weight, e_location_history, e_narcotic_use, e_age };

    readonly static string f_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(3)</color>";
    readonly static string f_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(3)</color>";
    readonly static string f_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(2)</color>";
    readonly static string f_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(2)</color>";
    readonly static string f_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(4)</color>";
    string[] f_array = { f_brands, f_weight, f_location_history, f_narcotic_use, h_age };

    readonly static string g_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(3)</color>";
    readonly static string g_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(3)</color>";
    readonly static string g_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(3)</color>";
    readonly static string g_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(2)</color>";
    readonly static string g_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(4)</color>";
    string[] g_array = { g_brands, g_weight, g_location_history, g_narcotic_use, g_age };

    readonly static string h_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(4)</color>";
    readonly static string h_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(3)</color>";
    readonly static string h_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(3)</color>";
    readonly static string h_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(3)</color>";
    readonly static string h_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(4)</color>";
    string[] h_array = { h_brands, h_weight, h_location_history, h_narcotic_use, h_age };

    readonly static string i_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(4)</color>";
    readonly static string i_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(3)</color>";
    readonly static string i_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(3)</color>";
    readonly static string i_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(4)</color>";
    readonly static string i_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(4)</color>";
    string[] i_array = { i_brands, i_weight, i_location_history, i_narcotic_use, i_age };

    readonly static string j_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(5)</color>";
    readonly static string j_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(4)</color>";
    readonly static string j_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(3)</color>";
    readonly static string j_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(4)</color>";
    readonly static string j_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(4)</color>";
    string[] j_array = { j_brands, j_weight, j_location_history, j_narcotic_use, j_age };

    readonly static string k_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(5)</color>";
    readonly static string k_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(4)</color>";
    readonly static string k_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(4)</color>";
    readonly static string k_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(4)</color>";
    readonly static string k_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(4)</color>";
    string[] k_array = { k_brands, k_weight, k_location_history, k_narcotic_use, k_age };

    readonly static string l_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(5)</color>";
    readonly static string l_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(4)</color>";
    readonly static string l_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(4)</color>";
    readonly static string l_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(5)</color>";
    readonly static string l_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(4)</color>";
    string[] l_array = { l_brands, l_weight, l_location_history, l_narcotic_use, l_age };

    readonly static string m_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(6)</color>";
    readonly static string m_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(4)</color>";
    readonly static string m_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(4)</color>";
    readonly static string m_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(5)</color>";
    readonly static string m_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(4)</color>";
    string[] m_array = { m_brands, m_weight, m_location_history, m_narcotic_use, m_age };

    readonly static string n_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(6)</color>";
    readonly static string n_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(4)</color>";
    readonly static string n_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(4)</color>";
    readonly static string n_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(5)</color>";
    readonly static string n_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(4)</color>";
    string[] n_array = { n_brands, n_weight, n_location_history, n_narcotic_use, n_age };

    readonly static string o_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(7)</color>";
    readonly static string o_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(4)</color>";
    readonly static string o_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(4)</color>";
    readonly static string o_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(5)</color>";
    readonly static string o_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(4)</color>";
    string[] o_array = { o_brands, o_weight, o_location_history, o_narcotic_use, o_age };

    readonly static string p_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(7)</color>";
    readonly static string p_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(4)</color>";
    readonly static string p_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(5)</color>";
    readonly static string p_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(5)</color>";
    readonly static string p_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(4)</color>";
    string[] p_array = { p_brands, p_weight, p_location_history, p_narcotic_use, p_age };

    readonly static string q_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(8)</color>";
    readonly static string q_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(4)</color>";
    readonly static string q_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(5)</color>";
    readonly static string q_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(5)</color>";
    readonly static string q_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(4)</color>";
    string[] q_array = { q_brands, q_weight, q_location_history, q_narcotic_use, q_age };

    readonly static string r_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(8)</color>";
    readonly static string r_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(4)</color>";
    readonly static string r_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(6)</color>";
    readonly static string r_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(5)</color>";
    readonly static string r_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(4)</color>";
    string[] r_array = { r_brands, r_weight, r_location_history, r_narcotic_use, r_age };

    readonly static string s_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(8)</color>";
    readonly static string s_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(4)</color>";
    readonly static string s_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(7)</color>";
    readonly static string s_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(5)</color>";
    readonly static string s_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(4)</color>";
    string[] s_array = { s_brands, s_weight, s_location_history, s_narcotic_use, s_age };

    readonly static string t_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(9)</color>";
    readonly static string t_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(4)</color>";
    readonly static string t_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(8)</color>";
    readonly static string t_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(5)</color>";
    readonly static string t_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(4)</color>";
    string[] t_array = { t_brands, t_weight, t_location_history, t_narcotic_use, t_age };

    readonly static string u_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(9)</color>";
    readonly static string u_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(4)</color>";
    readonly static string u_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(8)</color>";
    readonly static string u_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(5)</color>";
    readonly static string u_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(4)</color>";
    string[] u_array = { u_brands, u_weight, u_location_history, u_narcotic_use, u_age };

    readonly static string v_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(10)</color>";
    readonly static string v_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(4)</color>";
    readonly static string v_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(8)</color>";
    readonly static string v_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(5)</color>";
    readonly static string v_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(4)</color>";
    string[] v_array = { v_brands, v_weight, v_location_history, v_narcotic_use, v_age };

    readonly static string w_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(10)</color>";
    readonly static string w_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(4)</color>";
    readonly static string w_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string w_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(5)</color>";
    readonly static string w_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(5)</color>";
    string[] w_array = { w_brands, w_weight, w_location_history, w_narcotic_use, w_age };

    readonly static string x_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(11)</color>";
    readonly static string x_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(5)</color>";
    readonly static string x_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string x_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(5)</color>";
    readonly static string x_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(5)</color>";
    string[] x_array = { x_brands, x_weight, x_location_history, x_narcotic_use, x_age };

    readonly static string y_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(11)</color>";
    readonly static string y_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(5)</color>";
    readonly static string y_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string y_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(6)</color>";
    readonly static string y_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(5)</color>";
    string[] y_array = { y_brands, y_weight, y_location_history, y_narcotic_use, y_age };

    readonly static string z_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(11)</color>";
    readonly static string z_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(5)</color>";
    readonly static string z_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string z_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(6)</color>";
    readonly static string z_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(6)</color>";
    string[] z_array = { z_brands, z_weight, z_location_history, z_narcotic_use, z_age };

    //the idea here is to replace substrings within the Auction screen. The first set of substrings is defined in '_array". It is then
    //subsequently replaced by arrays 'a_array' - 'z_array', each time the timer expires.

    public TMP_Text textObject;

    float timeLeft = 5;
    float origTimeLeft;
    int stage = 0;

    bool timerStarted = false;

    public AudioSource ping_audio;

    //////////////////////////////////////////////////////////////////////////// START ///////////////////////////////////////////////////////////////////////
	void Start () {
        origTimeLeft = timeLeft;
	}

    //////////////////////////////////////////////////////////////////////////// UPDATE //////////////////////////////////////////////////////////////////////
    void Update()
    {
        if (timerStarted)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                //timer expires -> show new sale
                if (stage == 0) replaceAllSubStrings(_array, a_array);
                if (stage == 1) replaceAllSubStrings(a_array, b_array);
                if (stage == 2) replaceAllSubStrings(b_array, c_array);
                if (stage == 3) replaceAllSubStrings(c_array, d_array);
                if (stage == 4) replaceAllSubStrings(d_array, e_array);
                if (stage == 5) replaceAllSubStrings(e_array, f_array);
                if (stage == 6) replaceAllSubStrings(f_array, g_array);
                if (stage == 7) replaceAllSubStrings(g_array, h_array);
                if (stage == 8) replaceAllSubStrings(h_array, i_array);
                if (stage == 9) replaceAllSubStrings(i_array, j_array);
                if (stage == 10) replaceAllSubStrings(j_array, k_array);
                if (stage == 11) replaceAllSubStrings(k_array, l_array);
                if (stage == 12) replaceAllSubStrings(l_array, m_array);
                if (stage == 13) replaceAllSubStrings(m_array, n_array);
                if (stage == 14) replaceAllSubStrings(n_array, o_array);
                if (stage == 15) replaceAllSubStrings(o_array, p_array);
                if (stage == 16) replaceAllSubStrings(p_array, q_array);
                if (stage == 17) replaceAllSubStrings(q_array, r_array);
                if (stage == 18) replaceAllSubStrings(r_array, s_array);
                if (stage == 19) replaceAllSubStrings(s_array, t_array);
                if (stage == 20) replaceAllSubStrings(t_array, u_array);
                if (stage == 21) replaceAllSubStrings(u_array, v_array);
                if (stage == 22) replaceAllSubStrings(v_array, w_array);
                if (stage == 23) replaceAllSubStrings(w_array, x_array);
                if (stage == 24) replaceAllSubStrings(x_array, y_array);
                if (stage == 25) replaceAllSubStrings(y_array, z_array);
                stage++;
            }
        }
        if (!ping_audio.isPlaying) {ping_audio.mute = true; } else { ping_audio.mute = false;}
    }

    public void startAuction() {
        timeLeft = origTimeLeft;
        timerStarted = true;
    }

    void replaceAllSubStrings(string[] inArray, string[] outArray) {
        //replace substrings of inArray with substrings of outArray. The changes are applied to the text object.
        for (int i = 0; i < inArray.Length; i++)
        {
            textObject.text = textObject.text.Replace(inArray[i], outArray[i]);
        }
        origTimeLeft = origTimeLeft - .15f;
        timeLeft = origTimeLeft;
        ping_audio.Play();
    }

    public void stopAuction() {
        stage = 50;
    }

}
