local Time = Class()

local unity_time = UnityEngine.Time

function Time:_init()
	self.now_time = 0
	self.delta_time = 0
	self.real_time = 0
end

function Time:_delete()

end

function Time:Update()
	self.delta_time = unity_time.deltaTime
	self.now_time = unity_time.time
	self.real_time = unity_time.realtimeSinceStartup
end

game.Time = Time.New()