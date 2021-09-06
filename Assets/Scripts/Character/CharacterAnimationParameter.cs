using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//序列化组件 当前对象：嵌入到脚本后，可以在编译器中显示属性
public class CharacterAnimationParameter //普通c#类没有继承MonoBehaviour
{
    public string run = "run";

    public string death = "death";

    public string idle = "idle";

    public string attack1 = "attack1";

    public string attack2 = "attack2";

    public string attack3 = "attack3";

    public string walk = "walk";
}
