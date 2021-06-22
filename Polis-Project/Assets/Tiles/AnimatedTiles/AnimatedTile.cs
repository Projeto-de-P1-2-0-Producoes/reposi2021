using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Tile.../Animated FallingGround Tile", fileName = "New Animated Tile")]

public class AnimatedTile : TileBase
{
    public Sprite[] sprites;
    // sprites que serão utilizados na animção
    public Tile.ColliderType colliderType;
    // adiciona ao tile colisão
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        if(sprites != null && sprites.Length > 0)
        {
            tileData.sprite = sprites[0];
            tileData.colliderType = colliderType;
        }
    }
    public override bool GetTileAnimationData(Vector3Int position, ITilemap tilemap, ref TileAnimationData tileAnimationData)
    {
        if(sprites.Length > 0)
        {   
            tileAnimationData.animatedSprites = sprites;
            tileAnimationData.animationSpeed = 1;
            //tileAnimationData.animationStartTime = 0;
             
            return true;
        }
        return false;
    }
}
