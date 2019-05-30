local Runner = Class()

function Runner:_init()
	self.all_update_objs = {}

end

function Runner:_delete()

end

function Runner:Update(now_time, elapse_time)
	print("runner update")
	self.is_updating = true
	for _,v in pairs(self.all_update_objs) do
		v:Update(now_time, elapse_time)
	end
	self.is_updating = false
end

function Runner:AddRunnerObj(obj, priority)

end

function Runner:RemoveRunnerObj(obj)

end

game.Runner = Runner.New()