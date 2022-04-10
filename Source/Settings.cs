﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;

namespace UseBedrolls
{
	public class Settings : ModSettings
	{
		public bool reclaimAggresively = false;
		public bool unassignOnExit = true;
		public bool distanceCheck = false;
		public bool alsoColonies = false;

		public float distance = 100f;

		public void DoWindowContents(Rect wrect)
		{
			var options = new Listing_Standard();
			options.Begin(wrect);

			options.Label("TD.ExplainHomeBeds".Translate());
			options.CheckboxLabeled("TD.SettingReclaimAggresively".Translate(), ref reclaimAggresively, "TD.SettingReclaimAggresivelyDesc".Translate());
			options.CheckboxLabeled("TD.SettingUnAssignOnExit".Translate(), ref unassignOnExit, "TD.SettingUnAssignOnExitDesc".Translate());

			options.GapLine();
			options.CheckboxLabeled("TD.SettingFarFromBed".Translate(), ref distanceCheck);
			if (distanceCheck)
			{
				options.Label("TD.SettingFarFromBedAmount".Translate() + $" {distance:0.}");
				distance = options.Slider(distance, 0, 300);
			}
			options.CheckboxLabeled("TD.SettingAlsoColonies".Translate(), ref alsoColonies, "TD.SettingAlsoColoniesDesc".Translate());

			options.End();
		}
		
		public override void ExposeData()
		{
			Scribe_Values.Look(ref reclaimAggresively, "reclaimAggresively", false);
			Scribe_Values.Look(ref unassignOnExit, "unassignOnExit", true);
			Scribe_Values.Look(ref distanceCheck, "distanceCheck", false);
			Scribe_Values.Look(ref alsoColonies, "alsoColonies", false);
			Scribe_Values.Look(ref distance, "distance", 100f);
		}
	}
}