using UnityEngine;
class GameUtil
{
    public static DirectionEnum GetDirection(Vector2 vec2)
    {
        if (vec2.x == 0 && vec2.y == -1)
        {
            //碰撞到上边
            return DirectionEnum.UP;
        }
        else if (vec2.x == 0 && vec2.y == 1)
        {
            //碰撞到下边
            return DirectionEnum.DOWN;
        }
        else if (vec2.x == 1 && vec2.y == 0)
        {
            //碰撞到左边
            return DirectionEnum.LEFT;
        }
        else if (vec2.x == -1 && vec2.y == 0)
        {
            //碰撞到右边
            return DirectionEnum.RIGHT;
        }
        else
        {
            return DirectionEnum.NONE;
        }
    }
}