local _class = {} --所有类都保存在这个table里，索引是类的地址

--由于继承的特点，某些方法在子类中没有定义(不存在)，那子类就去调用父类的方法。
--元表满足“不存在方法，就调用其他地方的方法”这个特性，于是用来实现继承顺理成章

--继承父类创建对象的方法
function Class(super)
	local class_type = {}
	class_type._init = false
	class_type._delete = false
	class_type.super = super

	local vtbl = {}
	_class[class_type] = vtbl

	class_type.New = function(...)
		local obj = {}
		obj._class_type = class_type

		setmetatable(obj, {
			__index = vtbl
			})

		do 
			local create
			create = function(c, ...)
				if c.super then
					create(c.super, ...)
				end
				if c._init then
					c._init(obj, ...)
				end
			end
			create(class_type, ...)
		end

		obj.DeleteMe = function(self)
			local now_super = self._class_type
			while now_super ~= nil do
				if now_super._delete then
					now_super._delete(self)
				end
				now_super = now_super.super
			end
		end

		return obj
	end

	--把类设为元表
	setmetatable(class_type, {
		__newindex = function(t,k,v)
			vtbl[k] = v
		end,
		__index = vtbl
		})

	--把父类设为元表的元表
	if super then
		local super_class = _class[super]
		setmetatable(vtbl, {
			__index = function(t,k)
				local ret = super_class[k]
				return ret
			end
			})
	end

	return class_type
end