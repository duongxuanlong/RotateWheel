﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour {
	public GameObject m_Player;

	private List<GameObject> m_Objects;

	private bool m_IsGrowth = true;

	public int m_Total;

	void OnEnable()
	{
		EventManager.GetAvailableCallback += GetAvailablePlayer;
	}

	void OnDisable()
	{
		EventManager.GetAvailableCallback -= GetAvailablePlayer;
	}

	void Awake () {
		if (m_Total == 0)
			m_Total = 50;

		if (m_Objects == null)
			m_Objects = new List<GameObject> ();

		for (int i = 0; i < m_Total; i++) {
			GameObject obj = Instantiate (m_Player) as GameObject;
			obj.SetActive (false);
			m_Objects.Add (obj);
		}
	}
	
	private GameObject GetAvailablePlayer ()
	{
		for (int i = 0; i < m_Total; i++)
			if (!m_Objects [i].activeInHierarchy)
				return m_Objects [i];

		if (m_IsGrowth) {
			GameObject obj = Instantiate (m_Player) as GameObject;
			m_Objects.Add (obj);
			m_Total++;
			return obj;
		}

		return null;
	}
}
