print("Hello lua~")
game = game or {}

require("global/init")
require("game/init")

local Game = {}

function main()
	return Game
end

local _timer = game.Time
local _runner = game.Runner

function Game.Update()
	_timer:Update()
	_runner:Update(_timer.now_time, _timer.detla_time)
end

function Game.GetTest()
	local test = require("other")
	print("---GetTest----", test)
end

function Game.CreateGameObj()
	local obj = UnityEngine.GameObject()
	obj.name = "test_obj"
	local app_root = UnityEngine.GameObject.Find("app_root")
	obj.transform:SetParent(app_root.transform)
end