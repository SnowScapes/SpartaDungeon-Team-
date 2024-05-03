using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon_Team_
{
    class Monster
    {
        public int index;
        public int level; //레벨
        public string name; // 이름
        public int hp; // 체력
        public int mp; // 마나
        public int atk; // 공격력
        public int avoid; // 회피율
        public int accuracy; // 명중률
        public bool isDeath;

        public void GetDamage(int _damage)
        {
            hp -= _damage;
            if (hp <= 0)
                isDeath = true;
        }
    }


    class MonsterInfo
    {
        List<Monster> monsters = new List<Monster>
        {
            new Monster {index = 0 , level = 2, name = "미니언", hp = 15, mp = 15, atk = 5, avoid = 1, accuracy = 10 , isDeath = false},
            new Monster {index = 1 , level = 3, name = "공허충", hp = 10, mp = 10, atk = 9, avoid = 1, accuracy = 12 , isDeath = false},
            new Monster {index = 2 , level = 5, name = "대포미니언", hp = 25, mp = 25, atk = 8, avoid = 100, accuracy = 18 , isDeath = false}
        };

        public Monster GetMonsterInfo(int index)
        {
            return monsters[index];
        }
    }


}
