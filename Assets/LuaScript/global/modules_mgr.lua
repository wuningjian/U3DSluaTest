local ModuleMgr = Class()

function ModuleMgr:_init()
    self.module_list = {}
    self.module_map = {}
    self.stopping_all_modules = false
end

function ModuleMgr:_delete()
    self:StopAllModule()
end

function ModuleMgr:LoadAllModule()
    require("game/scene/scene")
end

function ModuleMgr:StartAllModule()    
    self:AddModule("scene", game.Scene.New())
end

function ModuleMgr:StopAllModule()
    self.stopping_all_modules = true
    for i = #self.module_list, 1, -1 do
        self.module_list[i]:DeleteMe()
    end
    self.stopping_all_modules = false
    self.module_list = {}
    self.module_map = {}
end

function ModuleMgr:AddModule(name, model)
    if self.module_map[name] then
        error("Module Has Exist " .. name)
    end
    self.module_map[name] = model
    table.insert(self.module_list, model)
end

function ModuleMgr:GetModule(name)
    return self.module_map[name]
end

game.ModuleMgr = ModuleMgr.New()