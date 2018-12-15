using UnityEngine;
using System.Collections;

/// \brief Скрипт кусочка пазла
public class Puzzle : MonoBehaviour {

	public int ID; /// номер соответствующей "костяшки"

	/// Текущая и пустая клетка, меняются местами
	void ReplaceBlocks(int x, int y, int XX, int YY)
	{
		ChessGameControl.grid[x,y].transform.position = ChessGameControl.position[XX,YY];
		ChessGameControl.grid[XX,YY] = ChessGameControl.grid[x,y];
		ChessGameControl.grid[x,y] = null;
		ChessGameControl.GameFinish();
	}

    /// Перемещение по нажатию кнопки
	void OnMouseDown()
	{
		for(int y = 0; y < 4; y++)
		{
			for(int x = 0; x < 4; x++)
			{
				if(ChessGameControl.grid[x,y])
				{
					if(ChessGameControl.grid[x,y].GetComponent<Puzzle>().ID == ID)
					{
						if(x > 0 && ChessGameControl.grid[x-1,y] == null)
						{
							ReplaceBlocks(x,y,x-1,y);
							return;
						}
						else if(x < 3 && ChessGameControl.grid[x+1,y] == null)
						{
							ReplaceBlocks(x,y,x+1,y);
							return;
						}
					}
				}
				if(ChessGameControl.grid[x,y])
				{
					if(ChessGameControl.grid[x,y].GetComponent<Puzzle>().ID == ID)
					{
						if(y > 0 && ChessGameControl.grid[x,y-1] == null)
						{
							ReplaceBlocks(x,y,x,y-1);
							return;
						}
						else if(y < 3 && ChessGameControl.grid[x,y+1] == null)
						{
							ReplaceBlocks(x,y,x,y+1);
							return;
						}
					}
				}
			}
		}
	}
}