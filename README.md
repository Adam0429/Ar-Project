# ar-project
###用Vuforia制作的一款赛道游戏，主要运用ImageTarget接口，障碍物可自行拼接完成，障碍物为实体，其中石头可被导弹破坏，一些物体不能被破坏，飞机可以飞行，前进，发射导弹，当飞机飞入停机坪，游戏胜利
###A track game made with Vuforia mainly uses the ImageTarget interface. The obstacles can be stitched together. The obstacles are solid. The stones can be destroyed by missiles. Some objects can not be destroyed. The aircraft can fly, advance, launch missiles. The plane flew into the tarmac and the game triumphed

## some bugs

### vuforia如果在安装unity就勾选内置的话，需要移除才能导入unity外部包，unity外部包使用方便，两者不能共存
### unity兼容性并不友好，有些方法已经摒弃却因为版本原因依然存在，需要手动从报错中修改
### unity中Animator controller无法给动作添加motion，只需要在这个动作的上级模型里修改Rig参数Animation Type为generic即可
### 导入插件时，两个不同版本的插件不能共存。如easytouch移除了多余的一个版本，才能正常使用。
### Has Exit Time的作用 如果我们勾选了该项，在动画转换时会等待当前动画播放完毕才会转换到下一个动画，如果当前动画是循环动画会等待本次播放完毕时转换，所以对于需要立即转换动画的情况时记得要取消勾选。还有一种情况时，当我当前的动画播放完毕后就自动转换到箭头所指的下一个状态（没有其他跳转条件），此时必须勾选该选项，否则动画播放完毕后就会卡在最后一帧，如果是循环动画就会一直循环播放。
### ar-camera里，collider是可用的，只不过坐标有时候判断不准
### collider碰撞检测时，其中一个物体必须带有rig

## reference links
https://blog.csdn.net/qinyuanpei/article/details/26204177

https://blog.csdn.net/qwe161819/article/details/76869231

https://blog.csdn.net/ChinarCSDN/article/details/81437311

https://ke.qq.com/course/318440

https://blog.csdn.net/Evan_love/article/details/80391292?utm_source=blogxgwz1

https://www.iqiyi.com/w_19rstilnn9.html

https://www.cnblogs.com/hammerc/p/4828774.html

https://blog.csdn.net/weixin_42513339/article/details/82386	009

https://blog.csdn.net/qq_28849871/article/details/77914922

http://www.cnblogs.com/hont/p/5099213.html?utm_source=tuicool&utm_medium=referral

https://blog.csdn.net/zzxiang1985/article/details/79418550 血条bug

https://blog.csdn.net/Exclaiming/article/details/80520552 Vuforia移除识别图后，模型还保留在原来的位置。误触了image target里面Extended Tracking

https://blog.csdn.net/qq_36612824/article/details/83341600 已过时的方法，导致不能正确导包

http://tieba.baidu.com/p/4573360927 esaytouch On_JoystickMove不触发，把interaction type 换成Event Notification就可以了
