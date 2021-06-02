using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBuilder : MonoBehaviour
{
    public Transform player;
    public Block[] block;
    public Block firstBlock;
    public Block finalBlock;
    private Block tempFinalBlock;
    public SetActiveWinBlock winBlock;

    private List<Block> spawnBlockDown = new List<Block>();
    private List<Block> spawnBlockUp = new List<Block>();

    public bool isGoDown = true;
    public bool isGetStar = false;
    private bool isFinalBlock = false;

    void Start()
    {
        spawnBlockDown.Add(firstBlock);
    }

    void Update()
    {
        if (isGoDown)
        {
            MovingDown();
        }
        else
        {
            MovingUp();
        }
    }

    /// <summary>
    /// Движение вниз уровня
    /// </summary>
    private void MovingDown()
    {
        if (player.position.y < spawnBlockDown[spawnBlockDown.Count - 1].endPoint.position.y + 15f)
        {
            SpawnBlockWhenMovingDown();
        }
    }

    /// <summary>
    /// Спавн игровых блоков при движении вниз уровня
    /// </summary>
    private void SpawnBlockWhenMovingDown()
    {
        int index = Random.Range(0, block.Length);
        Block newBlock = Instantiate(block[index]);
        newBlock.transform.position = spawnBlockDown[spawnBlockDown.Count - 1].endPoint.position - newBlock.startPoint.localPosition;
        spawnBlockDown.Add(newBlock);

        DestroyUpperBlock();
    }

    /// <summary>
    /// Уничтожение игровых блоков при движенни вниз уровня
    /// </summary>
    private void DestroyUpperBlock()
    {
        if (spawnBlockDown.Count >= 5)
        {
            Destroy(spawnBlockDown[1].gameObject);
            spawnBlockDown.RemoveAt(1);
        }
    }

    /// <summary>
    /// Движение вверх уровня
    /// </summary>
    private void MovingUp()
    {
        SpawnFinalBlock();

        if (player.position.y > spawnBlockUp[spawnBlockUp.Count - 1].endPoint.position.y &&
             Vector3.Distance(firstBlock.transform.position, spawnBlockUp[spawnBlockUp.Count - 1].transform.position) > 10f)
        {
            int index = Random.Range(0, block.Length);
            Block newBlock_1 = Instantiate(block[index]);
            newBlock_1.transform.position = spawnBlockUp[spawnBlockUp.Count - 1].startPoint.position + newBlock_1.startPoint.localPosition;
            spawnBlockUp.Add(newBlock_1);
        }

        DestroyLowerBlock();
    }

    /// <summary>
    /// Спавн нижнего блока
    /// </summary>
    private void SpawnFinalBlock()
    {
        if (!isFinalBlock)
        {
            tempFinalBlock = Instantiate(finalBlock);
            tempFinalBlock.transform.position = spawnBlockDown[spawnBlockDown.Count - 1].endPoint.position + spawnBlockDown[spawnBlockDown.Count - 1].endPoint.localPosition;
            spawnBlockUp.Add(spawnBlockDown[spawnBlockDown.Count - 3]);
            isFinalBlock = true;
            winBlock.Activate();
        }
    }

    /// <summary>
    /// Уничтожение игровых блоков при движенни вверх уровня
    /// </summary>
    private void DestroyLowerBlock()
    {
        if (spawnBlockUp.Count >= 5)
        {
            Destroy(spawnBlockUp[0].gameObject);
            spawnBlockUp.RemoveAt(0);
        }
    }
}
