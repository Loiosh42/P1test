﻿using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace P1test.Tiles
{
	// This example shows how to have a tile that is cut by weapons, like vines and grass.
	// This example also shows how to spawn a projectile on death like Beehive and Boulder trap.
	internal class GLOOtile : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			//Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			//Main.tileLighted[Type] = true;
			Main.tileCut[Type] = true;
		}
		

		public override void HitWire(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			WorldGen.KillTile(i, j, false, false, false);
		}

		public override bool RightClick(int i,int j)
        {
			Tile tile = Main.tile[i, j];
			WorldGen.KillTile(i, j, false, false, false);
			return true;
		}
		public override bool AutoSelect(int i, int j, Item item)
		{

			return true;
		}


	}
}
