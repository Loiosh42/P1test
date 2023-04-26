using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace P1test
{
    public class PathfindRod : ModItem
    {
        
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("makes a sparkly path to cursor from player, wip");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.useStyle = 1;
            Item.useTime = 20;
            Item.useAnimation = 20;
        }
        //use pathfinding in projectile AI or in Shoot, was looking at variation of A*


        //public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        //{


        //    Projectile.N
        //    return false;
        //    //return base.Shoot(player, source, position, velocity, type, damage, knockback);
        //}
    }
}