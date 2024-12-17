using UnityEngine;

public class EnemyTorpedoLauncher : EnemyShip
{
    SpriteRenderer spriteRenderer;
    new void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite.rect.Set(spriteRenderer.sprite.rect.x, spriteRenderer.sprite.rect.y, spriteRenderer.sprite.rect.height * 0.9f, spriteRenderer.sprite.rect.width * 0.7f);
    }
    new void Update()
    {
        base.Update();        
    }
}
