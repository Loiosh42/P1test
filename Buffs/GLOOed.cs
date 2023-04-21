using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace P1test.Buffs
{
	// Ethereal Flames is an example of a buff that causes constant loss of life.
	// See ExamplePlayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
	public class GLOOed : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("GLOOed!");
			Description.SetDefault("NO movement for YOU!");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;

		}


		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<P1testPlayer>().GLOOed = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<P1testGlobalNPC>().GLOOed = true;
		}

	}
}