using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ARPGDemo.Character//命名空间（一般格式 域名.项目名.模块）
{
    public class EnemyStatus:CharacterStatus
    {
        public override void Death()
        {
            base.Death();
            Destroy(gameObject, 10);
        }

    }

}