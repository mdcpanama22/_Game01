//Original File by Ben
//used by Unknown
//used for holding information about a spell.

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public struct SpellNew {
	public string name, description;
	public string[] cost, effects;

	public SpellNew(string n, string d, string[] c, string[] e) {
		name = n;
		description = d;
		cost = c;
		effects = e;
	}
}