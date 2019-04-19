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

    readonly static string za_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(11)</color>";
    readonly static string za_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(6)</color>";
    readonly static string za_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string za_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(6)</color>";
    readonly static string za_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(7)</color>";
    readonly static string za_calories = "<color=#3ea6f2>caloric_intake</color> == pending";
    string[] za_array = { za_brands, za_weight, za_location_history, za_narcotic_use, za_age, za_calories };

    readonly static string zb_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(11)</color>";
    readonly static string zb_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(6)</color>";
    readonly static string zb_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string zb_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(6)</color>";
    readonly static string zb_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(7)</color>";
    readonly static string zb_calories = "<color=#3ea6f2>caloric_intake</color> == <color=#b4353c>sold(1)</color>";
    string[] zb_array = { zb_brands, zb_weight, zb_location_history, zb_narcotic_use, zb_age, zb_calories };

    readonly static string zc_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(11)</color>";
    readonly static string zc_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(6)</color>";
    readonly static string zc_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string zc_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(6)</color>";
    readonly static string zc_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(7)</color>";
    readonly static string zc_calories = "<color=#3ea6f2>caloric_intake</color> == <color=#b4353c>sold(2)</color>";
    string[] zc_array = { zc_brands, zc_weight, zc_location_history, zc_narcotic_use, zc_age, zc_calories };

    readonly static string zd_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(11)</color>";
    readonly static string zd_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(6)</color>";
    readonly static string zd_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string zd_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(6)</color>";
    readonly static string zd_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zd_calories = "<color=#3ea6f2>caloric_intake</color> == <color=#b4353c>sold(2)</color>";
    string[] zd_array = { zd_brands, zd_weight, zd_location_history, zd_narcotic_use, zd_age, zd_calories };

    readonly static string ze_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(12)</color>";
    readonly static string ze_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(6)</color>";
    readonly static string ze_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string ze_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(6)</color>";
    readonly static string ze_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(8)</color>";
    readonly static string ze_calories = "<color=#3ea6f2>caloric_intake</color> == <color=#b4353c>sold(2)</color>";
    string[] ze_array = { ze_brands, ze_weight, ze_location_history, ze_narcotic_use, ze_age, ze_calories };

    readonly static string zf_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(12)</color>";
    readonly static string zf_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(7)</color>";
    readonly static string zf_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string zf_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(6)</color>";
    readonly static string zf_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zf_calories = "<color=#3ea6f2>caloric_intake</color> == <color=#b4353c>sold(2)</color>";
    string[] zf_array = { zf_brands, zf_weight, zf_location_history, zf_narcotic_use, zf_age, zf_calories };

    readonly static string zg_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(13)</color>";
    readonly static string zg_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(7)</color>";
    readonly static string zg_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string zg_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(6)</color>";
    readonly static string zg_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zg_calories = "<color=#3ea6f2>caloric_intake</color> == <color=#b4353c>sold(2)</color>";
    string[] zg_array = { zg_brands, zg_weight, zg_location_history, zg_narcotic_use, zg_age, zg_calories };

    readonly static string zh_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(13)</color>";
    readonly static string zh_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(7)</color>";
    readonly static string zh_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string zh_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(7)</color>";
    readonly static string zh_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zh_calories = "<color=#3ea6f2>caloric_intake</color> == <color=#b4353c>sold(2)</color>";
    readonly static string zh_height = "<color=#3ea6f2>height</color> == pending";
    string[] zh_array = { zh_brands, zh_weight, zh_location_history, zh_narcotic_use, zh_age, zh_calories, zh_height };

    readonly static string zi_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(13)</color>";
    readonly static string zi_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(7)</color>";
    readonly static string zi_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string zi_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(7)</color>";
    readonly static string zi_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zi_calories = "<color=#3ea6f2>caloric_intake</color> == <color=#b4353c>sold(2)</color>";
    readonly static string zi_height = "<color=#3ea6f2>height</color> == <color=#b4353c>sold(1)</color>";
    string[] zi_array = { zi_brands, zi_weight, zi_location_history, zi_narcotic_use, zi_age, zi_calories, zi_height };

    readonly static string zj_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(14)</color>";
    readonly static string zj_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(7)</color>";
    readonly static string zj_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string zj_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(7)</color>";
    readonly static string zj_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zj_calories = "<color=#3ea6f2>caloric_intake</color> == <color=#b4353c>sold(2)</color>";
    readonly static string zj_height = "<color=#3ea6f2>height</color> == <color=#b4353c>sold(1)</color>";
    string[] zj_array = { zj_brands, zj_weight, zj_location_history, zj_narcotic_use, zj_age, zj_calories, zj_height };

    readonly static string zk_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(14)</color>";
    readonly static string zk_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(7)</color>";
    readonly static string zk_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string zk_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zk_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zk_calories = "<color=#3ea6f2>caloric_intake</color> == <color=#b4353c>sold(2)</color>";
    readonly static string zk_height = "<color=#3ea6f2>height</color> == <color=#b4353c>sold(1)</color>";
    string[] zk_array = { zk_brands, zk_weight, zk_location_history, zk_narcotic_use, zk_age, zk_calories, zk_height };

    readonly static string zl_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(14)</color>";
    readonly static string zl_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(7)</color>";
    readonly static string zl_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string zl_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zl_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zl_calories = "<color=#3ea6f2>caloric_intake</color> == <color=#b4353c>sold(2)</color>";
    readonly static string zl_height = "<color=#3ea6f2>height</color> == <color=#b4353c>sold(2)</color>";
    readonly static string zl_current_location = "<color=#3ea6f2>current_location</color> == pending";
    string[] zl_array = { zl_brands, zl_weight, zl_location_history, zl_narcotic_use, zl_age, zl_calories, zl_height, zl_current_location };

    readonly static string zm_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(14)</color>";
    readonly static string zm_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(7)</color>";
    readonly static string zm_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string zm_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zm_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zm_calories = "<color=#3ea6f2>caloric_intake</color> == <color=#b4353c>sold(2)</color>";
    readonly static string zm_height = "<color=#3ea6f2>height</color> == <color=#b4353c>sold(2)</color>";
    readonly static string zm_current_location = "<color=#3ea6f2>current_location</color> == <color=#b4353c>sold(1)</color>";
    string[] zm_array = { zm_brands, zm_weight, zm_location_history, zm_narcotic_use, zm_age, zm_calories, zm_height, zm_current_location };

    readonly static string zn_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(14)</color>";
    readonly static string zn_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zn_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string zn_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zn_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zn_calories = "<color=#3ea6f2>caloric_intake</color> == <color=#b4353c>sold(2)</color>";
    readonly static string zn_height = "<color=#3ea6f2>height</color> == <color=#b4353c>sold(2)</color>";
    readonly static string zn_current_location = "<color=#3ea6f2>current_location</color> == <color=#b4353c>sold(1)</color>";
    string[] zn_array = { zn_brands, zn_weight, zn_location_history, zn_narcotic_use, zn_age, zn_calories, zn_height, zn_current_location };

    readonly static string zo_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(14)</color>";
    readonly static string zo_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zo_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string zo_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zo_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zo_calories = "<color=#3ea6f2>caloric_intake</color> == <color=#b4353c>sold(3)</color>";
    readonly static string zo_height = "<color=#3ea6f2>height</color> == <color=#b4353c>sold(2)</color>";
    readonly static string zo_current_location = "<color=#3ea6f2>current_location</color> == <color=#b4353c>sold(1)</color>";
    string[] zo_array = { zo_brands, zo_weight, zo_location_history, zo_narcotic_use, zo_age, zo_calories, zo_height, zo_current_location };

    readonly static string zp_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(14)</color>";
    readonly static string zp_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zp_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string zp_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zp_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zp_calories = "<color=#3ea6f2>caloric_intake</color> == <color=#b4353c>sold(4)</color>";
    readonly static string zp_height = "<color=#3ea6f2>height</color> == <color=#b4353c>sold(2)</color>";
    readonly static string zp_current_location = "<color=#3ea6f2>current_location</color> == <color=#b4353c>sold(1)</color>";
    string[] zp_array = { zp_brands, zp_weight, zp_location_history, zp_narcotic_use, zp_age, zp_calories, zp_height, zp_current_location };

    readonly static string zq_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(14)</color>";
    readonly static string zq_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zq_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string zq_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zq_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zq_calories = "<color=#3ea6f2>caloric_intake</color> == <color=#b4353c>sold(4)</color>";
    readonly static string zq_height = "<color=#3ea6f2>height</color> == <color=#b4353c>sold(3)</color>";
    readonly static string zq_current_location = "<color=#3ea6f2>current_location</color> == <color=#b4353c>sold(2)</color>";
    string[] zq_array = { zq_brands, zq_weight, zq_location_history, zq_narcotic_use, zq_age, zq_calories, zq_height, zq_current_location };

    readonly static string zr_brands = "<color=#3ea6f2>sport_brand</color> == <color=#b4353c>sold(14)</color>";
    readonly static string zr_weight = "<color=#3ea6f2>weight</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zr_location_history = "<color=#3ea6f2>location_history</color> == <color=#b4353c>sold(9)</color>";
    readonly static string zr_narcotic_use = "<color=#3ea6f2>narcotic_use</color> == <color=#b4353c>sold(9)</color>";
    readonly static string zr_age = "<color=#3ea6f2>age</color> == <color=#b4353c>sold(8)</color>";
    readonly static string zr_calories = "<color=#3ea6f2>caloric_intake</color> == <color=#b4353c>sold(4)</color>";
    readonly static string zr_height = "<color=#3ea6f2>height</color> == <color=#b4353c>sold(3)</color>";
    readonly static string zr_current_location = "<color=#3ea6f2>current_location</color> == <color=#b4353c>sold(2)</color>";
    string[] zr_array = { zr_brands, zr_weight, zr_location_history, zr_narcotic_use, zr_age, zr_calories, zr_height, zr_current_location };

    //the idea here is to replace substrings within the Auction screen. The first set of substrings is defined in '_array". It is then
    //subsequently replaced by arrays 'a_array' - 'z_array', each time the timer expires.

    public TMP_Text textObject;

    float timeLeft = 4.5f;
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
                if (stage == 26) replaceAllSubStrings(z_array, za_array);
                if (stage == 27) replaceAllSubStrings(za_array, zd_array);
                if (stage == 28) replaceAllSubStrings(zb_array, zc_array);
                if (stage == 29) replaceAllSubStrings(zc_array, zd_array);
                if (stage == 30) replaceAllSubStrings(zd_array, ze_array);
                if (stage == 31) replaceAllSubStrings(ze_array, zf_array);
                if (stage == 32) replaceAllSubStrings(zf_array, zg_array);
                if (stage == 33) replaceAllSubStrings(zg_array, zh_array);
                if (stage == 34) replaceAllSubStrings(zh_array, zi_array);
                if (stage == 35) replaceAllSubStrings(zi_array, zj_array);
                if (stage == 36) replaceAllSubStrings(zj_array, zk_array);
                if (stage == 37) replaceAllSubStrings(zk_array, zl_array);
                if (stage == 38) replaceAllSubStrings(zl_array, zm_array);
                if (stage == 39) replaceAllSubStrings(zm_array, zn_array);
                if (stage == 40) replaceAllSubStrings(zn_array, zo_array);
                if (stage == 41) replaceAllSubStrings(zo_array, zp_array);
                if (stage == 42) replaceAllSubStrings(zp_array, zq_array);
                if (stage == 43) replaceAllSubStrings(zq_array, zr_array);
                                                                           
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
        origTimeLeft = origTimeLeft - .07f;
        timeLeft = origTimeLeft;
        ping_audio.Play();
    }

    public void stopAuction() {
        stage = 50;
    }

}
