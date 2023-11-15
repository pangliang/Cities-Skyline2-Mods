# Cities Skylines 2 Modding
Mod for Cities Skylines 2

城市：天际线2 组模Mod, 每个子项目是一个独立的Mod

## Mods

| Mod Name                    | Feature                                                                                                                                                                                                                                  |
|-----------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| EnableDeveloperMode         | Activates the DevMode by default                                                                                                                                                                                                         |
| ChangeWeather               | Toggle precipitation by hotkey `ctrl+shift+r`                                                                                                                                                                                            |
| Cities1Unit                 | When creating a road, tip adds a new unit of length (a grid) just like Cities 1                                                                                                                                                          |
| TrafficReduction            | Removing the coefficient factor that reduces the weight of population travel in large cities can make the probability of people going out to work and go to school consistent, regardless of whether it is a large city or a small city. !!! Attention !!! Big cities definitely need more performance|

## Pre-Install
Only do this for first time.
1. Download the newest [BepInEx-Unity.Mono-win-x64-6.0.0-be.XXX+xxxxxxx.zip](https://builds.bepinex.dev/projects/bepinex_be)
2. Extract the contents to the root directory of Cities Skylines 2.
3. Run the game once to ensure that BepInEx initializes and creates its config folder.

## Install Mod
1. Download the latest version of this mod [XXXX.zip](https://github.com/pangliang/Cities-Skyline2-Mods/releases)
2. Extract the contents to the `${GameRootDir}/BepInEx/plugins`.

## 组模

| 组模名称             | 功能                                                                         |
|---------------------|----------------------------------------------------------------------------|
| EnableDeveloperMode | 默认打开开发者模式, 进游戏后按tab进入开发者模式菜单                                               |
| ChangeWeather       | 快捷键 `ctrl+shift+r` 打开/关闭下雨或下雪(冬天), 注意!! 天气切换后并不是马上消失, 雨量逐渐变化 (3-5秒)        |
| Cities1Unit         | 创建道路时, 长度提示增加一个新的单位(单元格), 类似Cities1                                        |
| TrafficReduction    | 移除大城市中人口出行降权的系数因子, 无论是大城市还是小城市,可以使出门工作和上学的人的概率一致.  !!! 注意 !!! 大城市肯定需要跟多的性能 |

## 安装前准备
安装插件基础包, 只需要操作一次
1. 下载最新的 [BepInEx-Unity.Mono-win-x64-6.0.0-be.XXX+xxxxxxx.zip](https://builds.bepinex.dev/projects/bepinex_be)
2. 解压到游戏根目录
3. 运行一次游戏, 以让 BepInEx 初始化它自己的目录

## 安装mod
1. 根据你的需要, 下载对应mod的压缩包 [XXXX.zip](https://github.com/pangliang/Cities-Skyline2-Mods/releases)
2. 解压到`${游戏根目录}/BepInEx/plugins`下

## Lib Dependencies 版本依赖
| Mod      | Game       | UnityEngine.Modules   | BepInEx    | HarmonyX  |
| -------- | -------    | -------               |------------| -------   |
| 1.0.0    | 1.0.11.0   | 2022.3.7              | 6.0.0-be.* | 2.10.2    |

## 参考资料
* [harmony 文档](https://harmony.pardeike.net/articles/intro.html)
* [BepInEx builds](https://builds.bepinex.dev/projects/bepinex_be)