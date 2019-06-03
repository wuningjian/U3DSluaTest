local Scene = Class(game.BaseCtrl)

game.Scene = Scene

function Scene:_init()
	if Scene.instance ~= nil then
		error("Scene Init Twice")
	end
	Scene.instance = self
	self.map = require("game/scene/map").New()
end

function Scene:_delete()
	if self.map then
		self.map:DeleteMe()
		self.map = nil
	end
end

function Scene:Update(now_time, delta_time)

end

return Scene