# Cities Skylines 2 Modding
Mod for Cities Skylines 2

城市：天际线2 组模Mod, 每个子项目是一个独立的Mod

## Mods

| Mod Name                  | Feature                                               |
| --------                  | -------                                               |
| EnableDeveloperMode       | Activates the DevMode by default                      |
| ChangeWeather             | Toggle precipitation by hotkey `ctrl+shift+r`         |

| 组模名称                  | 功能                                                                                                          |
| --------                  | -------                                                                                                       |
| EnableDeveloperMode       | 默认打开开发者模式, 进游戏后按tab进入开发者模式菜单                                                           |
| ChangeWeather             | 快捷键 `ctrl+shift+r` 打开/关闭下雨或下雪(冬天), 注意!! 天气切换后并不是马上消失, 雨量逐渐变化 (3-5秒)        |

## Pre-Install
Only do this for first time.
1. Download the [BepInEx_x64_5.4.22.0.zip](https://github.com/BepInEx/BepInEx/releases/tag/v5.4.22)
2. Extract the contents to the root directory of Cities Skylines 2.
3. Run the game once to ensure that BepInEx initializes and creates its config folder.

## Install Mod
1. Download the latest version of this mod [XXXX.zip](https://github.com/pangliang/Cities-Skyline2-Mods/releases)
2. Extract the contents to the `${GameRootDir}/BepInEx/plugins`.

## 安装前准备
安装插件基础包, 只需要操作一次
1. 下载 [BepInEx_x64_5.4.22.0.zip](https://github.com/BepInEx/BepInEx/releases/tag/v5.4.22)
2. 解压到游戏根目录
3. 运行一次游戏, 以让 BepInEx 初始化它自己的目录

## 安装mod
1. 根据你的需要, 下载对应mod的压缩包 [XXXX.zip](https://github.com/pangliang/Cities-Skyline2-Mods/releases)
2. 解压到`${游戏根目录}/BepInEx/plugins`下

## Lib Dependencies 版本依赖
| Mod      | Game       | UnityEngine.Modules   | BepInEx       | HarmonyX  |
| -------- | -------    | -------               | -------       | -------   |
| 1.0.0    | 1.0.11.0   | 2022.3.7              | 5.4.22        | 2.10.2    |
