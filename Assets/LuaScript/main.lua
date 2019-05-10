print("Hello lua~")

local Game = {}

function main()
	return Game
end

function Game.Update()
	print("----------hello -> update")
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